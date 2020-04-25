using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreqsSelector
{
    public partial class VerificationForm : Form
    {
        Form1 mainForm;
        string[] selectedFiles;
        public RangeHz[] simplifiedRanges;
        double discretization;
        public VerificationForm(Form1 mainForm, string[] selectedFiles, RangeHz[] userSelectedRanges, double discretization)
        {
            InitializeComponent();
            this.selectedFiles = selectedFiles;
            this.mainForm = mainForm;
            this.simplifiedRanges = FTCoumputer.CollapseRangesHzIntersections(userSelectedRanges);
            this.discretization = discretization;
            
        }

        public delegate void DecisionDelegate();
        public event DecisionDelegate Confirmed;
        public event DecisionDelegate Rejected;

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Utils.SetRowNumber(dataGridView1);
        }

        public List<string> FilesToPerform
        {
            get;
            private set;
        } = new List<string>();

        private void VerificationForm_Load(object sender, EventArgs e)
        {
            foreach (string s in selectedFiles)
            {
                if (Directory.Exists(s))
                {
                    dataGridView1.Rows.Insert(dataGridView1.RowCount, s, "Ошибка: найдена папка");
                    continue;
                }
                int lastDelim = 0;

                lastDelim = s.LastIndexOf('\\');
                if (lastDelim == -1)
                {
                    dataGridView1.Rows.Insert(dataGridView1.RowCount, s, "Ошибка: Не найден");
                    continue;
                }
                string dir = s.Substring(0, lastDelim);
                string file = s.Substring(lastDelim + 1);
                string[] paths = Directory.GetFiles(dir, file);
                if (paths.Length == 0)
                {
                    dataGridView1.Rows.Insert(dataGridView1.RowCount, s, "Не найден");
                }
                else
                {
                    foreach (var path in paths)
                    {
                        if (!FilesToPerform.Contains(path))
                        {
                            dataGridView1.Rows.Insert(dataGridView1.RowCount, path, "OK");
                            FilesToPerform.Add(path);
                        }
                    }
                }
            }
            Utils.SetRowNumber(dataGridView1);

            labelDiscretization.Text = discretization.ToString();

            string resRanges = "Объединение диапазонов: ";
            List<string> resRangesList = new List<string>();
            if(simplifiedRanges.Length == 0)
            {
                resRanges += "Не указано ни одного диапазона";
            }
            foreach (var range in simplifiedRanges)
            {
                resRangesList.Add("[" + range.Min + ";" + (range.Max == double.MaxValue ? "+Inf)" : range.Max.ToString() + "]"));
            }
            resRanges += string.Join(" U ", resRangesList.ToArray());
            richTextBoxShowRanges.Text = resRanges;

            if (FilesToPerform.Count == 0)
            {
                MessageBox.Show("Не выбрано ни одного существующего файла для обработки");
                buttonConfirm.Enabled = false;
            }
            if (simplifiedRanges.Length == 0)
            {
                MessageBox.Show("Не указано ни одного не пустого диапазона");
                buttonConfirm.Enabled = false;
            }
        }
        bool doneConfirm = false;
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Confirmed.Invoke();
            doneConfirm = true;
            buttonConfirm.Enabled = false;
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            Rejected.Invoke();
            this.Close();
        }

        private void VerificationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!doneConfirm)
                Rejected.Invoke();
        }

        public void SetStatusToFile(string file, string status)
        {
            for(int i = 0; i < dataGridView1.RowCount; i++)
            {
                if(dataGridView1.Rows[i].Cells[0].Value.ToString() == file)
                {
                    try
                    {
                        Invoke((Action)(() =>
                        {
                            if (!this.IsDisposed)
                                dataGridView1.Rows[i].Cells[1].Value = status;
                        }));
                    }
                    catch
                    {

                    }
                    return;
                }
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            FilesToPerform.Remove(e.Row.Cells[0].Value.ToString());
        }
    }
}
