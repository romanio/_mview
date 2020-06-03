using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace mview
{
    public partial class Sub2DOptions : Form
    {
        public event EventHandler UpdateData;

        readonly PlotModel plotModel = null;
        
        public bool UpdateMode = true;
        float m_propertyMinValue = 0;
        float m_propertyMaxValue = 1;
        
        public string PropertName
        {
            set
            {
                plotModel.Title = value;
            }
        }

        public long[] PropertyStatistic
        {
            set
            {
                plotModel.Series.Clear();


                double[] xvalues = new double[20];
                double dvals = (m_propertyMaxValue - m_propertyMinValue) / 20;

                for (int iw = 0; iw < 20; ++iw)
                {
                    xvalues[iw] = m_propertyMinValue + dvals * (iw + 0.5);
                }
                
                ((CategoryAxis)plotModel.Axes[0]).ItemsSource = xvalues;

                //
                plotModel.Series.Add(new BarSeries { });

                for (int iw = 0; iw < 20; ++iw)
                {
                    ((BarSeries)plotModel.Series[0]).Items.Add(new BarItem
                    {
                        CategoryIndex = iw,
                        Value = value[iw]
                    });
                }

                ((BarSeries)plotModel.Series[0]).FillColor = OxyColor.FromArgb(255, 255, 120, 0);
                plotModel.Axes[0].Reset();
                plotModel.Axes[1].Reset();
                plotModel.InvalidatePlot(true);
            }
        } 

        public float PropertyMinValue
        {
            set
            {
                m_propertyMinValue = value;
                MinColorDefault_Click(null, null);
            }
        }

        public float PropertyMaxValue
        {
            set
            {
                m_propertyMaxValue = value;
                MaxColorDefault_Click(null, null);
            }
        }

        readonly Form2DModelStyle Style;

        public Sub2DOptions(Form2DModelStyle Style)
        {
            InitializeComponent();

            this.Style = Style;

            plotModel = new PlotModel
            {
                Title = "(No keyword)",
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                DefaultFontSize = 10
            };

            plotModel.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Value",
                StringFormat = "N2",
                Angle = -90
            });


            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Cell count",
                AbsoluteMinimum = 0
            });

            plotView.Model = plotModel ;

            UpdateMode = true;

            checkShowGridLines.Checked = Style.ShowGridLines;
            checkShowBubbles.Checked = Style.ShowBubbles;
            checkNoFillColor.Checked = Style.ShowNoFillColor;

            boxBubbleMode.SelectedIndex = 0;
            numericScaleFactor.Value = (decimal)Style.ScaleFactor;
            numericZScale.Value = (decimal)Style.ZScale;

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

            UpdateMode = false;
        }

        private void SubFormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void MinColorDefault_Click(object sender, EventArgs e)
        {
            boxMinimum.Text = m_propertyMinValue.ToString();
            Style.MinValue = m_propertyMinValue;

            if (UpdateMode) return;

            UpdateData(sender, e);
        }

        private void MaxColorDefault_Click(object sender, EventArgs e)
        {
            boxMaximum.Text = m_propertyMaxValue.ToString();
            Style.MaxValue = m_propertyMaxValue;

            if (UpdateMode) return;

            UpdateData(sender, e);
        }

        double value;
        private void boxMinimum_Validating(object sender, CancelEventArgs e)
        {
            if (UpdateMode) return;

            if (double.TryParse(boxMinimum.Text, out value))
            {
                Style.MinValue = value;

                UpdateData(sender, e);
            }
        }

        private void boxMaximum_Validating(object sender, CancelEventArgs e)
        {
            if (UpdateMode) return;

            if (double.TryParse(boxMaximum.Text, out value))
            {
                Style.MaxValue = value;

                UpdateData(sender, e);
            }
        }

        private void trackStratch_Scroll(object sender, EventArgs e)
        {
            Style.StretchFactor = trackStratch.Value * 0.01;
            if (UpdateMode) return;

            UpdateData(sender, e);
        }

        private void checkShowGridLines_CheckedChanged(object sender, EventArgs e)
        {
            Style.ShowGridLines = checkShowGridLines.Checked;
            if (UpdateMode) return;

            UpdateData(sender, e);
        }

        private void checkShowAllWell_CheckedChanged(object sender, EventArgs e)
        {
            Style.ShowAllWelltrack = checkShowAllWell.Checked;
            
            if (UpdateMode) return;
            UpdateData(sender, e);
        }

        private void checkShowBubbles_CheckedChanged(object sender, EventArgs e)
        {
            Style.ShowBubbles = checkShowBubbles.Checked;
            if (UpdateMode) return;

            UpdateData(sender, e);
        }

        private void boxBubbleMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdateMode) return;

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

            UpdateData(sender, e);
        }

        private void numericScaleFactor_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateMode) return;

            Style.ScaleFactor = (double)numericScaleFactor.Value;

            UpdateData(sender, e);
        }

        private void numericZScale_ValueChanged(object sender, EventArgs e)
        {
            if (UpdateMode) return;

            Style.ZScale = (double)numericZScale.Value;

            UpdateData(sender, e);
        }

        private void checkNoFillColor_CheckedChanged(object sender, EventArgs e)
        {
            Style.ShowNoFillColor = checkNoFillColor.Checked;

            if (UpdateMode) return;

            UpdateData(sender, e);
        }
    }
}
