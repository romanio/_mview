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

        PlotModel plotModel = null;

        string _propertyName = null;
        float _propertyMinValue = 0;
        float _propertyMaxValue = 1;
        long[] _propertyStatistic = null;
        
        public string PropertName
        {
            set
            {
                _propertyName = value;
                plotModel.Title = value;
            }
        }

        public long[] PropertyStatistic
        {
            set
            {
                _propertyStatistic = value;

                plotModel.Series.Clear();

                double[] vals = new double[20];
                double dvals = (_propertyMaxValue - _propertyMinValue) / 20;

                for (int iw = 0; iw < 20; ++iw)
                {
                    vals[iw] = _propertyMinValue + dvals * (iw + 0.5);
                }

                ((CategoryAxis)plotModel.Axes[0]).ItemsSource = vals;


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
                plotModel.InvalidatePlot(true);
            }
        } 

        public float PropertyMinValue
        {
            set
            {
                _propertyMinValue = value;
                MinColorDefault_Click(null, null);
            }
        }

        public float PropertyMaxValue
        {
            set
            {
                _propertyMaxValue = value;
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
               StringFormat = "N3",
               Angle = -90,
                AbsoluteMinimum = 1,
                AbsoluteMaximum = 20,
                ItemsSource = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20}
            });


            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Cell count",
                AbsoluteMinimum = 0
            });

            plotView2.Model = plotModel ;
        }

        private void SubFormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void MinColorDefault_Click(object sender, EventArgs e)
        {
            boxMinimum.Text = _propertyMinValue.ToString();
            Style.MinValue = _propertyMinValue;
            ApplyStyle(sender, e);
        }

        private void MaxColorDefault_Click(object sender, EventArgs e)
        {
            boxMaximum.Text = _propertyMaxValue.ToString();
            Style.MaxValue = _propertyMaxValue;
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
