using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public partial class Form2DOptions : Form
    {
        public event UpdateDataDelegate ApplyStyle;

        Form2DModelStyle style;
        bool after_init = false;

        public Form2DOptions(Form2DModelStyle style)
        {
            InitializeComponent();
            this.style = style;

            checkShowGridLines.Checked = true;

            after_init = true;
        }

        private void checkShowGridLines_CheckedChanged(object sender, EventArgs e)
        {
            style.ShowGridLines = checkShowGridLines.Checked;
            if (after_init) ApplyStyle();
        }

        private void boxMaximum_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (double.TryParse(boxMaximum.Text, out value))
            {
                style.max_value = value;

                if (after_init) ApplyStyle();
            }
        }

        private void boxMinimum_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (double.TryParse(boxMinimum.Text, out value))
            {
                style.min_value = value;

                if (after_init) ApplyStyle();
            }
        }
    }
}
