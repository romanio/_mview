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
using System.Reflection;

namespace mview
{
    public partial class FormCrossPlots : Form
    {
        FormCrossPlotsModel model = null;
        PlotModel plotModel = null;
        PlotModel plotHisto = null;

        public FormCrossPlots(EclipseProject ecl)
        {
            InitializeComponent();
            //
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, gridData, new object[] { true });
            //

            model = new FormCrossPlotsModel(ecl);

            listKeywords.SelectedIndex = 0;
            //
            boxRestart.Items.Clear();
            boxRestart.BeginUpdate();
            boxRestart.Items.AddRange(model.GetDates());

            if (boxRestart.Items.Count > 0)
                boxRestart.SelectedIndex = 0;

            boxRestart.EndUpdate();
            //
            plotModel = new PlotModel
            {
                Title = "(No keyword)",
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                DefaultFontSize = 10
            };

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Simualted"
            });


            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Historical"
            });

            plotView1.Model = plotModel;
            //

            plotHisto = new PlotModel
            {
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                DefaultFontSize = 10,
            };

            plotHisto.Axes.Add(new OxyPlot.Axes.CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Relative Deviation",
                ItemsSource = new[] { "<10%", "10-20%", ">20%" }
            });


            plotHisto.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Well count"
            });

            plotView2.Model = plotHisto;

            //
            UpdateVirtualGroupsList();

        }

        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxRestart.SelectedIndex == -1) return;
            UpdateData();
        }

        private void boxRestart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKeywords.SelectedItem == null) return;
            UpdateData();
        }

        void UpdateData()
        {
            if (plotModel == null) return;

            gridData.Rows.Clear();
            plotModel.Series.Clear();
            plotModel.Annotations.Clear();
            plotHisto.Series.Clear();

            int step = boxRestart.SelectedIndex;
            string keyword = listKeywords.SelectedItem.ToString();

            //
            var data = new List<Tuple<string, float, float>>();

            if (listGroups.SelectedItem.ToString() == "(All)")
            {
                data = model.GetDataByKeywordAndDate(keyword, step);
            }
            else
            {
                string selected_pad = listGroups.SelectedItem.ToString();
                data = model.GetDataByPadKeywordAndDate(selected_pad, keyword, step);
            }

            plotModel.Title = keyword.ToUpper();
                
            int row = -1;

            int over20 = 0;
            int over10 = 0;
            int less10 = 0;
            int sum = 0;
            float max = 0;
            float diff = 0;

            plotModel.Series.Add(new LineSeries
            {
                LineStyle = LineStyle.None,
                MarkerType = MarkerType.Circle,
                MarkerFill = Color.Orange.ToOxyColor(),
                MarkerStroke = Color.Black.ToOxyColor(),
                MarkerSize = 3
            });


            foreach (Tuple<string, float, float> item in data)
            {
                if ((item.Item2 != 0.00) && (item.Item3 != 0.00))
                {
                    row = gridData.Rows.Add();

                    gridData[0, row].Value = item.Item1;
                    gridData[1, row].Value = item.Item2;
                    gridData[2, row].Value = item.Item3;
                    gridData[3, row].Value = item.Item2 - item.Item3;
                    diff = 100 * (item.Item2 - item.Item3) / item.Item3;

                    gridData[4, row].Value = diff;

                    if (Math.Abs(diff) <= 10) less10++;
                    if ((Math.Abs(diff) > 10) && (Math.Abs(diff) <= 20)) over10++;
                    if (Math.Abs(diff) > 20) over20++;

                    if (item.Item2 > max) max = item.Item2;
                    if (item.Item3 > max) max = item.Item3;

                    //((LineSeries)plotModel.Series[0]).Points.Add(new DataPoint(item.Item2, item.Item3));

                    // добавим подпись

                    var pointAnnotation1 = new OxyPlot.Annotations.PointAnnotation();
                    pointAnnotation1.Fill = Color.Orange.ToOxyColor();
                    pointAnnotation1.StrokeThickness = 1;
                    pointAnnotation1.Stroke = Color.Black.ToOxyColor();
                    pointAnnotation1.X = Convert.ToDouble(item.Item2);
                    pointAnnotation1.Y = Convert.ToDouble(item.Item3);
                    pointAnnotation1.Text = item.Item1;
                    pointAnnotation1.FontSize = 9;
                    plotModel.Annotations.Add(pointAnnotation1);
                }
            }

            /*
            data.Sort((x, y) => (y.Item2 - y.Item3).CompareTo(x.Item2-x.Item3));

            plotAbsolute.Series.Add(new LineSeries { });

            int position = 0;

            for (int iw = 0; iw < data.Count; ++iw)
            {
                if (data[iw].Item2 > 0)
                {
                    double difference = data[iw].Item2 - data[iw].Item3;
                    ((LineSeries)plotAbsolute.Series[0]).Points.Add(new DataPoint(position, difference));

                    var pointAnnotation1 = new OxyPlot.Annotations.PointAnnotation();
                    pointAnnotation1.Fill = Color.Orange.ToOxyColor();
                    pointAnnotation1.StrokeThickness = 1;
                    pointAnnotation1.Stroke = Color.Black.ToOxyColor();
                    pointAnnotation1.X = Convert.ToDouble(position);
                    pointAnnotation1.Y = Convert.ToDouble(difference);
                    pointAnnotation1.Text = data[iw].Item1;
                    pointAnnotation1.FontSize = 9;
                    plotAbsolute.Annotations.Add(pointAnnotation1);

                    position++;
                }
            }
            */

            sum = less10 + over10 + over20;

            if (sum > 0)
            {
                // Линия хорошей адаптации

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Red.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(0, 0));
                ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(max, max));

                // Линия плюс минус 10%

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Green.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Green.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });


                ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(0, 0));
                ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(max, 1.1 * max));


                ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(0, 0));
                ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(max, 0.9 * max));

                // Линия плюс минус 20%

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Blue.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });

                plotModel.Series.Add(new LineSeries
                {
                    LineStyle = LineStyle.Dot,
                    Color = Color.Blue.ToOxyColor(),
                    MarkerType = MarkerType.None,
                });


                ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(0, 0));
                ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(max, 1.2 * max));


                ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(0, 0));
                ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(max, 0.8 * max));

                //
                plotHisto.Series.Add(new ColumnSeries { });
                ((ColumnSeries)plotHisto.Series[0]).Items.Add(new ColumnItem { CategoryIndex = 0, Value = less10 });
                ((ColumnSeries)plotHisto.Series[0]).Items.Add(new ColumnItem { CategoryIndex = 1, Value = over10 });
                ((ColumnSeries)plotHisto.Series[0]).Items.Add(new ColumnItem { CategoryIndex = 2, Value = over20 });
             
            }

            plotModel.InvalidatePlot(true);
            plotHisto.InvalidatePlot(true);
        }

        private void listGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        void UpdateVirtualGroupsList()
        {
            listGroups.Items.Clear();
            listGroups.Items.Add("(All)");

            var pads = model.GetVirtalGroups();

            if (pads != null) listGroups.Items.AddRange(pads);

            listGroups.SelectedIndex = 0;
        }

        private void bbLoadGroups_Click(object sender, EventArgs e)
        {
            model.LoadVirtualGroups();
            UpdateVirtualGroupsList();
        }
    }
}
