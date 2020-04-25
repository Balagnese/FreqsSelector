using System;
using System.Windows.Forms;

namespace FreqsControlls
{
    public partial class RangeSelect : UserControl
    {
        public RangeSelect()
        {
            InitializeComponent();
        }

        double startValue;
        public double StartValue
        {
            get
            {
                return startValue;
            }
            private set
            {
                startValue = value;
                numericUpDownStart.Value = (decimal)value;
                if (value > EndValue)
                {
                    EndValue = startValue;
                }
            }
        }

        public bool StartOpen
        {
            get
            {
                return checkBoxStartOpen.Checked;
            }
        }
        private void numericUpDownStart_ValueChanged(object sender, EventArgs e)
        {
            StartValue = (double)numericUpDownStart.Value;
        }
        double endValue;
        public double EndValue
        {
            get
            {
                return endValue;
            }
            private set
            {
                endValue = value;
                numericUpDownEnd.Value = (decimal)value;
                if (value < StartValue)
                {
                    StartValue = endValue;
                }
            }
        }
        public bool EndOpen
        {
            get
            {
                return checkBoxEndOpen.Checked;
            }
        }
        private void numericUpDownEnd_ValueChanged(object sender, EventArgs e)
        {
            EndValue = (double)numericUpDownEnd.Value;
        }

        private void checkBoxStartOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStartOpen.Checked)
            {
                numericUpDownStart.Enabled = false;
            }
            else
            {
                numericUpDownStart.Enabled = true;
            }
        }

        private void checkBoxEndOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEndOpen.Checked)
            {
                numericUpDownEnd.Enabled = false;
            }
            else
            {
                numericUpDownEnd.Enabled = true;
            }
        }
        public delegate void OnCloseRangeSelect();
        public event OnCloseRangeSelect closeRangeSelect;
        private void buttonClose_Click(object sender, EventArgs e)
        {
            closeRangeSelect.Invoke();
        }
    }
}
