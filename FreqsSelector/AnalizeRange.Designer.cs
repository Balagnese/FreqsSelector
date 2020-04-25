namespace FreqsSelector
{
    partial class AnalizeRange
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.checkBoxStartOpen = new System.Windows.Forms.CheckBox();
            this.checkBoxEndOpen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начало";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Конец";
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.DecimalPlaces = 3;
            this.numericUpDownStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownStart.Location = new System.Drawing.Point(55, 4);
            this.numericUpDownStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(89, 20);
            this.numericUpDownStart.TabIndex = 2;
            this.numericUpDownStart.Tag = "";
            this.numericUpDownStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownStart.ThousandsSeparator = true;
            this.numericUpDownStart.ValueChanged += new System.EventHandler(this.numericUpDownStart_ValueChanged);
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.DecimalPlaces = 3;
            this.numericUpDownEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownEnd.Location = new System.Drawing.Point(55, 30);
            this.numericUpDownEnd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(89, 20);
            this.numericUpDownEnd.TabIndex = 3;
            this.numericUpDownEnd.Tag = "";
            this.numericUpDownEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownEnd.ThousandsSeparator = true;
            this.numericUpDownEnd.ValueChanged += new System.EventHandler(this.numericUpDownEnd_ValueChanged);
            // 
            // checkBoxStartOpen
            // 
            this.checkBoxStartOpen.AutoSize = true;
            this.checkBoxStartOpen.Location = new System.Drawing.Point(151, 6);
            this.checkBoxStartOpen.Name = "checkBoxStartOpen";
            this.checkBoxStartOpen.Size = new System.Drawing.Size(129, 17);
            this.checkBoxStartOpen.TabIndex = 4;
            this.checkBoxStartOpen.Text = "Открытый диапазон";
            this.checkBoxStartOpen.UseVisualStyleBackColor = true;
            this.checkBoxStartOpen.CheckedChanged += new System.EventHandler(this.checkBoxStartOpen_CheckedChanged);
            // 
            // checkBoxEndOpen
            // 
            this.checkBoxEndOpen.AutoSize = true;
            this.checkBoxEndOpen.Location = new System.Drawing.Point(151, 32);
            this.checkBoxEndOpen.Name = "checkBoxEndOpen";
            this.checkBoxEndOpen.Size = new System.Drawing.Size(129, 17);
            this.checkBoxEndOpen.TabIndex = 5;
            this.checkBoxEndOpen.Text = "Открытый диапазон";
            this.checkBoxEndOpen.UseVisualStyleBackColor = true;
            this.checkBoxEndOpen.CheckedChanged += new System.EventHandler(this.checkBoxEndOpen_CheckedChanged);
            // 
            // AnalizeRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxEndOpen);
            this.Controls.Add(this.checkBoxStartOpen);
            this.Controls.Add(this.numericUpDownEnd);
            this.Controls.Add(this.numericUpDownStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AnalizeRange";
            this.Size = new System.Drawing.Size(281, 53);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownStart;
        private System.Windows.Forms.NumericUpDown numericUpDownEnd;
        private System.Windows.Forms.CheckBox checkBoxStartOpen;
        private System.Windows.Forms.CheckBox checkBoxEndOpen;
    }
}
