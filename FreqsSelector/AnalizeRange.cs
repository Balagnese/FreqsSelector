using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreqsSelector
{
    public partial class AnalizeRange : UserControl
    {
        public AnalizeRange()
        {
            InitializeComponent();
        }
        double startValue;
        double StartValue
        {
            get
            {
                return startValue;
            }
            set
            {
                startValue = value;
                numericUpDownStart.Value = (decimal) value;
                if (value > EndValue)
                {
                    EndValue = startValue;
                }
            }
        }
        private void numericUpDownStart_ValueChanged(object sender, EventArgs e)
        {
            
        }
        double endValue;
        double EndValue
        {
            get
            {
                return endValue;
            }
            set
            {

            }
        }
        private void numericUpDownEnd_ValueChanged(object sender, EventArgs e)
        {

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
    }
}
