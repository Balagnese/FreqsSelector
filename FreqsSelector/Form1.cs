using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreqsControlls;
using System.Text.RegularExpressions;

namespace FreqsSelector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.WrapContents = false; // Vertical rather than horizontal scrolling
        }

        private void buttonAddRange_Click(object sender, EventArgs e)
        {
            var rangeSelect = new RangeSelect();
            rangeSelect.closeRangeSelect += () => {
                flowLayoutPanel.Controls.Remove(rangeSelect);
            };
            
            flowLayoutPanel.Controls.Add(rangeSelect);
            rangeSelect.Width = flowLayoutPanel.Width - 7;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonAddRange.PerformClick();
        }


        Thread t;
        bool computing = false;
        private void buttonCompute_Click(object sender, EventArgs e)
        {
            if (computing)
            {
                t.Abort();
                buttonCompute.Text = "Рассчитать";
                labelComputationStatus.Text = "Не исполняется";
                computing = false;
                return;
            }
            List<string> files = new List<string>();
            for(int i = 0; i < dataGridViewSelected.RowCount-1; i++)
            {
                string val = dataGridViewSelected.Rows[i].Cells[0].Value.ToString();
                if (!string.IsNullOrWhiteSpace(val))
                {
                    files.Add(val);
                }
            }
            
            List<RangeHz> ranges = new List<RangeHz>();
            for(int i = 0; i < flowLayoutPanel.Controls.Count; i++)
            {
                RangeSelect rs = (RangeSelect)flowLayoutPanel.Controls[i];
                RangeHz r = new RangeHz(rs.StartValue, rs.EndValue, rs.StartOpen, rs.EndOpen);
                ranges.Add(r);
            }
            double discretization = (double)numericUpDownDiscretization.Value;
            string saveDir = textBoxSavePath.Text;
            if (!Directory.Exists(saveDir))
            {
                MessageBox.Show("Папка для сохранения результатов \"" + saveDir + "\" не найдена", "Обратите внимание");
                return;
            }
            if (f != null)
            {
                f.Close();
            }

            f = new VerificationForm(this, files.ToArray(), ranges.ToArray(), discretization);
            f.Show();
            buttonCompute.Enabled = false;
            disableAllChangableControlls();
            
            f.Confirmed += () => {
                buttonCompute.Enabled = true;
                Queue<string> filesQueue = new Queue<string>(f.FilesToPerform.Count);
                foreach(var file in f.FilesToPerform)
                {
                    filesQueue.Enqueue(file);
                }
                var dict = Utils.GroupFilesByFolders(f.FilesToPerform.ToArray());
                var dirs = dict.Keys.ToList();
                Dictionary<string, int> dirsIndexes = new Dictionary<string, int>();

                int startIndex = -1;
                string[] dirsInSave = Directory.GetDirectories(saveDir);

                string programIdentifier = "FreqsSelector";

                Regex r = new Regex(programIdentifier + "[\\d]+");
                for(int i = 0; i < dirsInSave.Length; i++)
                {
                    if (r.IsMatch(dirsInSave[i]))
                    {
                        int ind;
                        string baseDir = Utils.GetFilename(dirsInSave[i]);

                        string strInd = baseDir.Substring(programIdentifier.Length);
                        if (int.TryParse(strInd, out ind))
                        {
                            startIndex = Math.Max(startIndex, ind);
                        }
                    }
                }

                startIndex++;

                for (int i = 0; i < dirs.Count; i++)
                {
                    dirsIndexes[dirs[i]] = i + startIndex;
                }

                t = new Thread(() =>
                {
                    FTCoumputer c = new DFTCumputer();
                    int countFiles = filesQueue.Count;
                    computing = true;
                    DateTime now = DateTime.Now;
                    string timeString = now.ToString("dd/MM/yy HH:mm:ss");
                    int counted = 0;
                    string logPath = ".\\Log " + timeString.Replace(':', '_') +".txt";
                    var s = File.Create(logPath);
                    s.Close();

                    var simplifiedRanges = f.simplifiedRanges;
                    List<string> resRangesList = new List<string>();
                    foreach (var range in simplifiedRanges)
                    {
                        resRangesList.Add("[" + range.Min + ";" + (range.Max == double.MaxValue ? "+Inf)" : range.Max.ToString() + "]"));
                    }
                    string resRanges = string.Join(" U ", resRangesList.ToArray());


                    using (var writer = new StreamWriter(logPath, true))
                    {
                        writer.WriteLine("Time:" + timeString);
                        writer.WriteLine("Restore ranges: " + resRanges);
                        writer.WriteLine("Analazing files:" + countFiles + ":");

                        foreach (var path in filesQueue.ToList())
                        {
                            writer.WriteLine(path);
                        }
                        writer.WriteLine("Analization start");
                    }


                    while (filesQueue.Count != 0)
                    {
                        string file = filesQueue.Peek();

                        this.Invoke((Action)(() =>
                        {
                            labelComputationStatus.Text = "Обрабатываеся " +
                            (countFiles - filesQueue.Count + 1) + "/" + countFiles + ":\n" + file;
                        }));
                        using (var writer = new StreamWriter(logPath, true))
                        {
                            string time = DateTime.Now.ToString("dd.MM.yy HH:mm:ss");
                            writer.WriteLine("Start:" + time);
                            writer.WriteLine("File("+(countFiles - filesQueue.Count + 1) + "/" + countFiles + "):\t" + file);
                        }
                        FTCoumputer.Result res;
                        try
                        {
                            res = Compute(f, c, file, discretization, ranges.ToArray());
                        }
                        catch (FileComputeError err)
                        {
                            using (var writer = new StreamWriter(logPath, true))
                            {
                                string time = DateTime.Now.ToString("dd.MM.yy HH:mm:ss");
                                switch (err.error)
                                {
                                    case FileComputeError.Error.FAILED_TO_OPEN:
                                        WriteFileStatusToVerificationForm(err.file, "Не удалось открыть");
                                        writer.WriteLine("Done:" + time);
                                        writer.WriteLine("Result:FAILED_TO_OPEN");
                                        break;
                                    case FileComputeError.Error.INVALID_FORMAT:
                                        WriteFileStatusToVerificationForm(err.file, "Не верный формат");
                                        writer.WriteLine("Done:" + time);

                                        writer.WriteLine("Result:INVALID_FORMAT");
                                        break;
                                }
                                continue;
                            }
                        }

                        if (res == null)
                        {
                            filesQueue.Dequeue();
                            continue;
                        }

                        counted++;

                        string baseFileDir = Utils.GetBaseDir(file);
                        string fileSaveDir = Utils.JoinPathParts(saveDir, programIdentifier + dirsIndexes[baseFileDir].ToString());
                        string ident = Utils.GetFilename(file);
                        string[] savedFiles = WriteResults(res, fileSaveDir, timeString, baseFileDir, ident);
                        filesQueue.Dequeue();
                        using (var writer = new StreamWriter(logPath, true))
                        {
                            string time = DateTime.Now.ToString("dd.MM.yy HH:mm:ss");
                            
                            List<string> rangesIndxsList = new List<string>();
                            foreach (var range in res.Ranges)
                            {
                                rangesIndxsList.Add("[" + range.Min + ";" + range.Max  + "]");
                            }
                            string rangesIndxsStr = string.Join(" U ", rangesIndxsList.ToArray());

                            writer.WriteLine("Done:" + time);
                            writer.WriteLine("Result:OK");
                            writer.WriteLine("Ranges:" + rangesIndxsStr);
                            writer.WriteLine("SavedTo:"+fileSaveDir);
                            writer.WriteLine("FT:" + savedFiles[0]);
                            writer.WriteLine("IFT:" + savedFiles[1]);
                            writer.WriteLine("MINS:" + savedFiles[2]);
                            writer.WriteLine("MAXS:" + savedFiles[3]);
                        }
                    }
                    this.Invoke((Action)(() =>
                    {
                        labelComputationStatus.Text = "Не исполняется";
                        MessageBox.Show("Файлов рассчитано успешно: " + counted + " из " + countFiles, "Готово!");
                        buttonCompute.Text = "Рассчитать";
                        computing = false;
                        enableAllChangableControlls();
                    }));
                    
                });
                t.Start();
                
            };
            f.Rejected += () =>
            {
                buttonCompute.Enabled = true;
                enableAllChangableControlls();
            };
        }
        private string[] WriteResults(FTCoumputer.Result result, string saveDir, string timeIdent, string baseFileDir, string ident)
        {
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }

            
            
            var ranges = result.Ranges;
            List<string> rangesStrList = new List<string>();
            foreach(var range in ranges)
            {
                rangesStrList.Add("[" + range.Min + "-" + range.Max + "]");
            }
            string rangesStr = string.Join("_", rangesStrList);
            
            //README.txt
            using (StreamWriter writer = new StreamWriter(Utils.JoinPathParts(saveDir, "README.txt")))
            {
                writer.Write("В данной папке хранятся результаты по файлам. взятым из папки:\r\n"
                    +baseFileDir+"\r\nОт:\r\n"+timeIdent);
            }

            string[] savedFiles = {
                Utils.JoinPathParts(saveDir,"dft_" + rangesStr + "_" + ident),
                Utils.JoinPathParts(saveDir, "idft_" + rangesStr + "_" + ident),
                Utils.JoinPathParts(saveDir, "MINS_" + rangesStr + "_" + ident),
                Utils.JoinPathParts(saveDir, "MAXS_" + rangesStr + "_" + ident)
            };

            //dft
            using (StreamWriter writer = new StreamWriter(savedFiles[0]))
            {
                foreach(var val in result.DFT)
                {
                    writer.Write(val.Real + "\t" + val.Imag + "\r\n");
                }
            }

            //idft
            using (StreamWriter writer = new StreamWriter(savedFiles[1]))
            {
                foreach (var val in result.IDFT)
                {
                    writer.Write(val + "\r\n");
                }
            }

            //mins diffs
            using (StreamWriter writer = new StreamWriter(savedFiles[2]))
            {
                foreach (var val in result.MinsDiffs)
                {
                    writer.Write(val + "\r\n");
                }
            }

            //maxs diffs
            using (StreamWriter writer = new StreamWriter(savedFiles[3]))
            {
                foreach (var val in result.MaxsDiffs)
                {
                    writer.Write(val + "\r\n");
                }
            }
            return savedFiles;
        }
        VerificationForm f;
        private void WriteFileStatusToVerificationForm(string file, string status)
        {
            if(f!=null && !f.IsDisposed)
            {
                f.SetStatusToFile(file, status);
            }
        }

        class FileComputeError: Exception{
            public string file;
            public Error error;
            public FileComputeError(string file, Error error)
            {
                this.file = file;
                this.error = error;
            }
            public enum Error
            {
                FAILED_TO_OPEN,
                INVALID_FORMAT,

            }
        }

        private FTCoumputer.Result Compute(VerificationForm f, FTCoumputer c, string file, double discretization, RangeHz[] ranges)
        {
            List<string> lines;
            try {
                lines = new List<string>(File.ReadAllLines(file));
                lines = lines.FindAll((el) =>
                {
                    return !string.IsNullOrWhiteSpace(el);
                });
            }
            catch
            {
                //WriteFileStatusToVerificationForm(file, "Не удалось открыть");
                //return  null;
                throw new FileComputeError(file, FileComputeError.Error.FAILED_TO_OPEN);
            }
            double[] data = new double[lines.Count];
            int i = 0;

            char sep = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            foreach (var el in lines)
            {
                var eldot = el.Replace('.', sep);

                if(!double.TryParse(el.Replace(',', sep), out data[i]))
                {
                    if(!double.TryParse(el.Replace('.', sep), out data[i]))
                    {
                        //WriteFileStatusToVerificationForm(file, "Не верный формат файла");
                        //return null;
                        throw new FileComputeError(file, FileComputeError.Error.INVALID_FORMAT);
                    }
                }
                i++;
            }
            var res = c.Compute(data, discretization, ranges);
            WriteFileStatusToVerificationForm(file, "Обработан");
            return res;
        }

        void disableAllChangableControlls()
        {
            buttonSelectFiles.Enabled = false;
            dataGridViewSelected.Enabled = false;
            textBoxSavePath.Enabled = false;
            buttonSelectSavePath.Enabled = false;
            numericUpDownDiscretization.Enabled = false;
            buttonAddRange.Enabled = false;
            flowLayoutPanel.Enabled = false;
        }

        void enableAllChangableControlls()
        {
            buttonSelectFiles.Enabled = true;
            dataGridViewSelected.Enabled = true;
            textBoxSavePath.Enabled = true;
            buttonSelectSavePath.Enabled = true;
            numericUpDownDiscretization.Enabled = true;
            buttonAddRange.Enabled = true;
            flowLayoutPanel.Enabled = true;
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }
        private void buttonSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Выберите файлы для обработки";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                foreach(var name in dlg.FileNames)
                {
                    dataGridViewSelected.Rows.Insert(0, name);
                }
                setRowNumber(dataGridViewSelected);
            }
        }

        private void buttonSelectSavePath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if(fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBoxSavePath.Text = fbd.SelectedPath;
                }
            }

        }
    }
}
