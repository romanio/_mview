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
            checkShowBubbles.Checked = true;
            boxBubbleMode.SelectedIndex = 0;
            numericScaleFactor.Value = 100;

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

        private void checkShowBubbles_CheckedChanged(object sender, EventArgs e)
        {
            style.ShowBubbles = checkShowBubbles.Checked;
            if (after_init) ApplyStyle();
        }

        private void boxBubbleMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (boxBubbleMode.SelectedIndex)
            {
                case 0:
                    style.BubbleMode = BubbleMode.Simulation;
                    break;
                case 1:
                    style.BubbleMode = BubbleMode.Historical;
                    break;
                case 2:
                    style.BubbleMode = BubbleMode.SimVSHist;
                    break;
            }

            if (after_init) ApplyStyle();

        }

        private void numericScaleFactor_ValueChanged(object sender, EventArgs e)
        {
            style.scale_factor = (double)numericScaleFactor.Value;

            if (after_init) ApplyStyle();
        }

        private void checkShowAllWell_CheckedChanged(object sender, EventArgs e)
        {
            style.ShowAllWelltrack = checkShowAllWell.Checked;

            if (after_init) ApplyStyle();
        }
    }
}
