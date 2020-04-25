namespace FreqsSelector
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewSelected = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddRange = new System.Windows.Forms.Button();
            this.buttonCompute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelComputationStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.buttonSelectSavePath = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownDiscretization = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscretization)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSelected
            // 
            this.dataGridViewSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewSelected.Location = new System.Drawing.Point(12, 31);
            this.dataGridViewSelected.Name = "dataGridViewSelected";
            this.dataGridViewSelected.Size = new System.Drawing.Size(452, 125);
            this.dataGridViewSelected.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Файл/маска";
            this.Column1.Name = "Column1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Файлы для обработки";
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Location = new System.Drawing.Point(341, 8);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(123, 23);
            this.buttonSelectFiles.TabIndex = 2;
            this.buttonSelectFiles.Text = "Выбрать файлы";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            this.buttonSelectFiles.Click += new System.EventHandler(this.buttonSelectFiles_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(16, 257);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(448, 160);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Диапазоны анализа";
            // 
            // buttonAddRange
            // 
            this.buttonAddRange.Location = new System.Drawing.Point(147, 227);
            this.buttonAddRange.Name = "buttonAddRange";
            this.buttonAddRange.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRange.TabIndex = 6;
            this.buttonAddRange.Text = "Добавить диапазон";
            this.buttonAddRange.UseVisualStyleBackColor = true;
            this.buttonAddRange.Click += new System.EventHandler(this.buttonAddRange_Click);
            // 
            // buttonCompute
            // 
            this.buttonCompute.Location = new System.Drawing.Point(360, 439);
            this.buttonCompute.Name = "buttonCompute";
            this.buttonCompute.Size = new System.Drawing.Size(104, 45);
            this.buttonCompute.TabIndex = 7;
            this.buttonCompute.Text = "Рассчитать";
            this.buttonCompute.UseVisualStyleBackColor = true;
            this.buttonCompute.Click += new System.EventHandler(this.buttonCompute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Статус выполнения:";
            // 
            // labelComputationStatus
            // 
            this.labelComputationStatus.AutoSize = true;
            this.labelComputationStatus.Location = new System.Drawing.Point(17, 439);
            this.labelComputationStatus.Name = "labelComputationStatus";
            this.labelComputationStatus.Size = new System.Drawing.Size(89, 13);
            this.labelComputationStatus.TabIndex = 9;
            this.labelComputationStatus.Text = "Не исполняется";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Путь для сохранения результатов";
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(16, 180);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(366, 20);
            this.textBoxSavePath.TabIndex = 11;
            // 
            // buttonSelectSavePath
            // 
            this.buttonSelectSavePath.Location = new System.Drawing.Point(389, 178);
            this.buttonSelectSavePath.Name = "buttonSelectSavePath";
            this.buttonSelectSavePath.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectSavePath.TabIndex = 12;
            this.buttonSelectSavePath.Text = "Выбрать";
            this.buttonSelectSavePath.UseVisualStyleBackColor = true;
            this.buttonSelectSavePath.Click += new System.EventHandler(this.buttonSelectSavePath_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Частота дискретизации";
            // 
            // numericUpDownDiscretization
            // 
            this.numericUpDownDiscretization.DecimalPlaces = 3;
            this.numericUpDownDiscretization.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownDiscretization.Location = new System.Drawing.Point(151, 206);
            this.numericUpDownDiscretization.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDownDiscretization.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownDiscretization.Name = "numericUpDownDiscretization";
            this.numericUpDownDiscretization.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDiscretization.TabIndex = 14;
            this.numericUpDownDiscretization.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 501);
            this.Controls.Add(this.numericUpDownDiscretization);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSelectSavePath);
            this.Controls.Add(this.textBoxSavePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelComputationStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCompute);
            this.Controls.Add(this.buttonAddRange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.buttonSelectFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewSelected);
            this.Name = "Form1";
            this.Text = "Frequencies Selector";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDiscretization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSelectFiles;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddRange;
        private System.Windows.Forms.Button buttonCompute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelComputationStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSavePath;
        private System.Windows.Forms.Button buttonSelectSavePath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownDiscretization;
    }
}

