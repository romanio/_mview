using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public partial class UСOptions : UserControl
    {
        Form2DModelStyle Style;
        bool IsUpdateStyle = true;

        public event EventHandler ApplyStyle;
        public float PropertyMaxValue = 1;
        public float PropertyMinValue = 0;

        public UСOptions(Form2DModelStyle Style)
        {
            this.Style = Style;

            InitializeComponent();
        }

        private void UСOptions_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                IsUpdateStyle = true;

                checkShowGridLines.Checked = Style.ShowGridLines;
                checkShowBubbles.Checked = Style.ShowBubbles;
                boxBubbleMode.SelectedIndex = 0;
                numericScaleFactor.Value = (decimal)Style.ScaleFactor;

                boxMinimum.Text = Style.MinValue.ToString();
                boxMaximum.Text = Style.MaxValue.ToString();

                switch (Style.BubbleMode)
                {
                    case BubbleMode.Simulation:
                        boxBubbleMode.SelectedIndex = 0;
                        break;
                    case BubbleMode.Historical:
                        boxBubbleMode.SelectedIndex = 1;
                        break;

                    default:
                        break;
                }

                IsUpdateStyle = false;
            }
        }

        private void checkShowGridLines_CheckedChanged(object sender, EventArgs e)
        {
            Style.ShowGridLines = checkShowGridLines.Checked;

            if (!IsUpdateStyle) ApplyStyle(sender, e);
        }

        private void boxMaximum_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (double.TryParse(boxMaximum.Text, out value))
            {
                Style.MaxValue = value;

                if (!IsUpdateStyle) ApplyStyle(sender, e);
            }
        }

        private void boxMinimum_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (double.TryParse(boxMinimum.Text, out value))
            {
                Style.MinValue = value;

                if (!IsUpdateStyle) ApplyStyle(sender, e);
            }
        }

        private void checkShowBubbles_CheckedChanged(object sender, EventArgs e)
        {
            Style.ShowBubbles = checkShowBubbles.Checked;
            if (!IsUpdateStyle) ApplyStyle(sender, e);
        }

        private void boxBubbleMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (boxBubbleMode.SelectedIndex)
            {
                case 0:
                    Style.BubbleMode = BubbleMode.Simulation;
                    break;
                case 1:
                    Style.BubbleMode = BubbleMode.Historical;
                    break;
                case 2:
                    Style.BubbleMode = BubbleMode.SimVSHist;
                    break;
            }

            if (!IsUpdateStyle) ApplyStyle(sender, e);
        }

        private void numericScaleFactor_ValueChanged(object sender, EventArgs e)
        {
            Style.ScaleFactor = (double)numericScaleFactor.Value;

            if (!IsUpdateStyle) ApplyStyle(sender, e);
        }

        private void checkShowAllWell_CheckedChanged(object sender, EventArgs e)
        {
            Style.ShowAllWelltrack = checkShowAllWell.Checked;

            if (!IsUpdateStyle) ApplyStyle(sender, e);
        }

        private void trackStratch_Scroll(object sender, EventArgs e)
        {
            Style.StretchFactor = trackStratch.Value * 0.01;

            if (!IsUpdateStyle) ApplyStyle(sender, e);
        }

        private void MinColorDefault_Click(object sender, EventArgs e)
        {
            boxMinimum.Text = PropertyMinValue.ToString();
        }

        private void MaxColorDefault_Click(object sender, EventArgs e)
        {
            boxMaximum.Text = PropertyMaxValue.ToString();
        }
    }
}
