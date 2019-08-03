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

        enum TypeCondition
        {
            Relative,
            Absolute
        }

        TypeCondition ActiveCondition = TypeCondition.Relative;

        public FormCrossPlots(ProjectManager pm)
        {
            InitializeComponent();
            //
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, gridData, new object[] { true });
            //

            model = new FormCrossPlotsModel(pm);

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
            float relvalue = 0;
            float absvalue = 0;

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

                    absvalue = item.Item2 - item.Item3;
                    relvalue = 100 * (item.Item2 - item.Item3) / item.Item3;

                    gridData[3, row].Value = absvalue;
                    gridData[4, row].Value = relvalue;

                    // Критерии

                    if (ActiveCondition == TypeCondition.Relative)
                    {
                        if (Math.Abs(relvalue) <= FirstCond) less10++;
                        if ((Math.Abs(relvalue) > FirstCond) && (Math.Abs(relvalue) <= SecondCond)) over10++;
                        if (Math.Abs(relvalue) > SecondCond) over20++;
                    }

                    if (ActiveCondition == TypeCondition.Absolute)
                    {
                        if (Math.Abs(absvalue) <= FirstCond) less10++;
                        if ((Math.Abs(absvalue) > FirstCond) && (Math.Abs(absvalue) <= SecondCond)) over10++;
                        if (Math.Abs(absvalue) > SecondCond) over20++;
                    }

                    if (item.Item2 > max) max = item.Item2;
                    if (item.Item3 > max) max = item.Item3;
                    //


                    // Точки на графике

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

                // Линия по первому условию

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

                if (ActiveCondition == TypeCondition.Relative)
                {
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(max, (100 + FirstCond ) * 0.01 * max));
                    
                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(max, (100 - FirstCond) * 0.01 * max));

                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(max, (100 + SecondCond) * 0.01 * max));

                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(0, 0));
                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(max, (100 - SecondCond) * 0.01 * max));

                    plotHisto.Axes[0].Title = "Relative Deviation";
                    ((CategoryAxis)plotHisto.Axes[0]).ItemsSource = new[] { "<" + FirstCond + "%", FirstCond + "-" + SecondCond + " %", ">" + SecondCond + "%" };
                }

                if (ActiveCondition == TypeCondition.Absolute)
                {
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(0, FirstCond));
                    ((LineSeries)plotModel.Series[2]).Points.Add(new DataPoint(max,  max + FirstCond));

                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(0, -FirstCond));
                    ((LineSeries)plotModel.Series[3]).Points.Add(new DataPoint(max, max - FirstCond));

                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(0, SecondCond));
                    ((LineSeries)plotModel.Series[4]).Points.Add(new DataPoint(max,  max + SecondCond));

                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(0, -SecondCond));
                    ((LineSeries)plotModel.Series[5]).Points.Add(new DataPoint(max, max - SecondCond));

                    plotHisto.Axes[0].Title = "Absolute Deviation";
                    ((CategoryAxis)plotHisto.Axes[0]).ItemsSource = new[] { "<" + FirstCond , FirstCond + "-" + SecondCond , ">" + SecondCond};
                }

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

        private void bbCriteria_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible)
            {
                if (ActiveCondition == TypeCondition.Relative)
                {
                    boxTypeCondition.SelectedIndex = 0;
                }

                if (ActiveCondition == TypeCondition.Absolute)
                {
                    boxTypeCondition.SelectedIndex = 1;
                }

                boxFirstCond.Text = FirstCond.ToString();
                boxFirstCond.ForeColor = Color.Black;


                boxSecondCond.Text = SecondCond.ToString();
                boxSecondCond.ForeColor = Color.Black;
            }
        }

        private void boxTypeCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxTypeCondition.SelectedItem == null) return;

            if (boxTypeCondition.SelectedIndex == 0)
            {
                ActiveCondition = TypeCondition.Relative;
                UpdateData();
            }

            if (boxTypeCondition.SelectedIndex == 1)
            {
                ActiveCondition = TypeCondition.Absolute;
                UpdateData();
            }
        }

        double FirstCond = 10;
        double SecondCond = 20;

        private void boxFirstCond_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (Double.TryParse(boxFirstCond.Text, out value))
            {
                FirstCond = value;
                boxFirstCond.ForeColor = Color.Black;
                UpdateData();
            }
            else
            {
                boxFirstCond.ForeColor = Color.Red;
            }
        }

        private void boxSecondCond_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (Double.TryParse(boxSecondCond.Text, out value))
            {
                SecondCond = value;
                boxSecondCond.ForeColor = Color.Black;
                UpdateData();
            }
            else
            {
                boxSecondCond.ForeColor = Color.Red;
            }
        }
    }
}
