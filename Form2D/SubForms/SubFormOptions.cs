using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;

namespace mview
{
    public partial class SubFormOptions : Form
    {
        public event EventHandler ApplyStyle;

        readonly PlotModel plotModel = null;

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
                plotModel.Series.Add(new ColumnSeries { });

                for (int iw = 0; iw < 20; ++iw)
                {
                    ((ColumnSeries)plotModel.Series[0]).Items.Add(new ColumnItem
                    {
                        CategoryIndex = iw,
                        Value = value[iw]
                    });
                }

                ((ColumnSeries)plotModel.Series[0]).FillColor = OxyColor.FromArgb(255, 255, 120, 0);
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

        public SubFormOptions(Form2DModelStyle Style)
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
                Angle = -90,
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 20
            });


            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Cell count",
                AbsoluteMinimum = 0
            });

            plotView.Model = plotModel ;
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
            ApplyStyle(sender, e);
        }

        private void MaxColorDefault_Click(object sender, EventArgs e)
        {
            boxMaximum.Text = m_propertyMaxValue.ToString();
            Style.MaxValue = m_propertyMaxValue;
            ApplyStyle(sender, e);
        }

        private void boxMinimum_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (double.TryParse(boxMinimum.Text, out value))
            {
                Style.MinValue = value;

               ApplyStyle(sender, e);
            }
        }

        private void boxMaximum_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (double.TryParse(boxMaximum.Text, out value))
            {
                Style.MaxValue = value;

                ApplyStyle(sender, e);
            }
        }
    }
}
