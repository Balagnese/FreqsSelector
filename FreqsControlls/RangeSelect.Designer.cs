namespace FreqsControlls
{
    partial class RangeSelect
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxEndOpen = new System.Windows.Forms.CheckBox();
            this.checkBoxStartOpen = new System.Windows.Forms.CheckBox();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxEndOpen
            // 
            this.checkBoxEndOpen.AutoSize = true;
            this.checkBoxEndOpen.Location = new System.Drawing.Point(160, 32);
            this.checkBoxEndOpen.Name = "checkBoxEndOpen";
            this.checkBoxEndOpen.Size = new System.Drawing.Size(129, 17);
            this.checkBoxEndOpen.TabIndex = 11;
            this.checkBoxEndOpen.Text = "Открытый диапазон";
            this.checkBoxEndOpen.UseVisualStyleBackColor = true;
            this.checkBoxEndOpen.CheckedChanged += new System.EventHandler(this.checkBoxEndOpen_CheckedChanged);
            // 
            // checkBoxStartOpen
            // 
            this.checkBoxStartOpen.AutoSize = true;
            this.checkBoxStartOpen.Location = new System.Drawing.Point(160, 3);
            this.checkBoxStartOpen.Name = "checkBoxStartOpen";
            this.checkBoxStartOpen.Size = new System.Drawing.Size(129, 17);
            this.checkBoxStartOpen.TabIndex = 10;
            this.checkBoxStartOpen.Text = "Открытый диапазон";
            this.checkBoxStartOpen.UseVisualStyleBackColor = true;
            this.checkBoxStartOpen.CheckedChanged += new System.EventHandler(this.checkBoxStartOpen_CheckedChanged);
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.DecimalPlaces = 3;
            this.numericUpDownEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownEnd.Location = new System.Drawing.Point(56, 32);
            this.numericUpDownEnd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownEnd.TabIndex = 9;
            this.numericUpDownEnd.Tag = "";
            this.numericUpDownEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownEnd.ThousandsSeparator = true;
            this.numericUpDownEnd.ValueChanged += new System.EventHandler(this.numericUpDownEnd_ValueChanged);
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.DecimalPlaces = 3;
            this.numericUpDownStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownStart.Location = new System.Drawing.Point(56, 3);
            this.numericUpDownStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownStart.TabIndex = 8;
            this.numericUpDownStart.Tag = "";
            this.numericUpDownStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownStart.ThousandsSeparator = true;
            this.numericUpDownStart.ValueChanged += new System.EventHandler(this.numericUpDownStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Конец";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Начало";
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.ForeColor = System.Drawing.Color.Crimson;
            this.buttonClose.Location = new System.Drawing.Point(333, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(20, 10, 3, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(44, 39);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.16667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.83333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownEnd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxStartOpen, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxEndOpen, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownStart, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(313, 58);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(19, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Гц";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 29);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(19, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Гц";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(417, 61);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // RangeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "RangeSelect";
            this.Size = new System.Drawing.Size(423, 63);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxEndOpen;
        private System.Windows.Forms.CheckBox checkBoxStartOpen;
        private System.Windows.Forms.NumericUpDown numericUpDownEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
