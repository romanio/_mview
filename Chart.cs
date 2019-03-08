using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;

namespace mview
{
    public partial class Chart : UserControl
    {
        ChartModel model = null;
        OxyPlot.PlotModel pm = null;
        ChartController chartController = new ChartController();

        bool edit_mode_keywords = false;

        public void SetEclipseProject(EclipseProject ecl)
        {
            model = new ChartModel(ecl);
        }

        void InitChart()
        {
            pm = new PlotModel
            {
                Title = "(No wells yet)",
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                LegendFontSize = 10,
                DefaultFontSize = 10
            };

            if (chartController.AxisX == "TIME")
            {
                pm.Axes.Add(new OxyPlot.Axes.DateTimeAxis
                {
                    Position = OxyPlot.Axes.AxisPosition.Bottom,
                    StringFormat = "dd.MM.yyyy"
                });
            }
            else
            {
                pm.Axes.Add(new OxyPlot.Axes.LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = chartController.AxisX
                });
            }

            pm.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left
            });

            plotView1.Model = pm;
        }

        public Chart(EclipseProject ecl, ChartController chartController)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, gridData, new object[] { true });

            model = new ChartModel(ecl);
            this.chartController = chartController;

            listKeywords.Items.Clear();
            InitChart();
        }

        string[] selected_names = null;

        public void UpdateSelectedNames(string[] names)
        {
            // Сохраним текущие выделенные слова

            selected_names = names;
 
            var tmp_keywords = new List<string>();
            foreach (string item in listKeywords.SelectedItems)
            {
                tmp_keywords.Add(item);
            }

            edit_mode_keywords = true;
            listKeywords.BeginUpdate();

            listKeywords.Items.Clear();
            listKeywords.Items.AddRange(model.GetKeywords(names[0]));

            // Восстановим выделенные слова

            int index = -1;
            foreach (string item in tmp_keywords)
            {
                index = listKeywords.Items.IndexOf(item);

                if (index != -1)
                {
                    listKeywords.SetSelected(index, true);
                 }
            }

            edit_mode_keywords = false;
            listKeywords.EndUpdate();

            UpdateVisibleElements();
            listKeywords_SelectedIndexChanged(null, null);
        }

        int[] selected_index = null;

        void UpdateVisibleElements()
        {
            // Обновим таблицу

            gridData.ColumnCount = selected_names.Length * listKeywords.SelectedItems.Count + 1;
            gridData.Columns[0].HeaderText = "Date";
            gridData.RowCount = model.GetStepCount();
            gridData.VirtualMode = true;

            int index = 1;
            selected_index = new int[selected_names.Length * listKeywords.SelectedItems.Count];
            List<string> selected_units = new List<string>();

            for (int it = 0; it < selected_names.Length; ++it)
            {
                var vector = model.GetDataVector(selected_names[it]);

                for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
                {
                    var data = vector.Data.FirstOrDefault(c => c.keyword == listKeywords.SelectedItems[iw].ToString());
                    selected_index[index - 1] = data.index;
                    selected_units.Add(data.unit);
                    gridData.Columns[index++].HeaderText = vector.Name + "\n" + data.keyword + "\n" + data.unit;
                }
            }

            // Заглавие графика

            StringBuilder title_name = new StringBuilder();

            for (int iw = 0; iw < selected_names.Length - 1; ++iw)
                title_name.Append(selected_names[iw] + ",");

            title_name.Append(selected_names.Last());

            pm.Title = title_name.ToString();

            // Размерность оси Y

            if (selected_units.Count > 0)
            {
                selected_units = selected_units.Distinct().ToList();

                StringBuilder axis_y_name = new StringBuilder();

                for (int iw = 0; iw < selected_units.Count - 1; ++iw)
                    axis_y_name.Append(selected_units[iw] + ",");

                axis_y_name.Append(selected_units.Last());

                pm.Axes[1].Title = axis_y_name.ToString();
            }

            // Обновить график

            pm.Series.Clear();

            // Обычный режим для графиков, отличия только в оси X

            if (chartController.AxisY == "Normal")
            {
                for (int it = 0; it < selected_names.Length; ++it)
                {
                    for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
                    {
                        List<DataPoint> data = null;

                        if (chartController.AxisX == "TIME") // Временные ряды
                        {
                            data = model.GetDataTime(selected_names[it], listKeywords.SelectedItems[iw].ToString());
                        }
                        else // произвольная ось X
                        {
                            data = model.GetData(selected_names[it], chartController.AxisX, listKeywords.SelectedItems[iw].ToString());
                        }

                        //

                        var tmp_style = chartController.GetStyle(listKeywords.SelectedItems[iw].ToString());

                        var tmp_ls = new LineSeries
                        {
                            Title = listKeywords.SelectedItems[iw].ToString(),
                            LineStyle = tmp_style?.LineStyle ?? OxyPlot.LineStyle.Solid,
                            StrokeThickness = tmp_style?.LineWidth ?? 1,
                            Smooth = tmp_style?.LineSmooth ?? false,
                            MarkerType = tmp_style?.MarkerType ?? OxyPlot.MarkerType.Circle,
                            MarkerSize = tmp_style?.MarkerSize ?? 5
                        };

                        if (tmp_style != null)
                        {
                            if (tmp_style.LineColor.Name != "0") // Default value
                            {
                                tmp_ls.Color = tmp_style.LineColor.ToOxyColor();
                            }

                            if (tmp_style.MarkerFillColor.Name != "0")
                            {
                                tmp_ls.MarkerFill = tmp_style.MarkerFillColor.ToOxyColor();
                            }

                            if (tmp_style.MarkerColor.Name != "0")
                            {
                                tmp_ls.MarkerStroke = tmp_style.MarkerColor.ToOxyColor();
                            }
                        }

                        pm.Series.Add(tmp_ls);

                        ((OxyPlot.Series.LineSeries)pm.Series[it * listKeywords.SelectedItems.Count + iw]).Points.Clear();
                        ((OxyPlot.Series.LineSeries)pm.Series[it * listKeywords.SelectedItems.Count + iw]).Points.AddRange(data);
                    }
                }
            }

           
            if (chartController.AxisY == "Average")
            {
                for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
                {
                    List<List<OxyPlot.DataPoint>> datas = new List<List<OxyPlot.DataPoint>>();

                    for (int it = 0; it < selected_names.Length; ++it)
                    {

                        if (chartController.AxisX == "TIME")
                        {
                            datas.Add(model.GetDataTime(selected_names[it], listKeywords.SelectedItems[iw].ToString()));
                        }
                        else
                        {
                            datas.Add(model.GetData(selected_names[it], chartController.AxisX, listKeywords.SelectedItems[iw].ToString()));
                        }
                    }

                    pm.Series.Add(new OxyPlot.Series.LineSeries
                    {
                        Title = listKeywords.SelectedItems[iw].ToString() + ".av",
                        MarkerType = OxyPlot.MarkerType.Circle
                    });

                    // Осреднение для значений не равных нулю

                    for (int it = 0; it < model.GetStepCount(); ++it)
                    {
                        double value = 0;
                        double count = 0;

                        for (int ic = 0; ic < datas.Count; ++ic)
                        {
                            if (datas[ic][it].Y != 0)
                            {
                                value = value + datas[ic][it].Y;
                                count++;
                            }
                        }
                        ((OxyPlot.Series.LineSeries)pm.Series[iw]).Points.Add(new DataPoint(datas[0][it].X, count > 0 ? value / count : 0));
                       }
                }
            }
           
            if (chartController.AxisY == "Sum")
            {
                for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
                {
                    List<List<OxyPlot.DataPoint>> datas = new List<List<OxyPlot.DataPoint>>();

                    for (int it = 0; it < selected_names.Length; ++it)
                    {
                        if (chartController.AxisX == "TIME")
                        {
                            datas.Add(model.GetDataTime(selected_names[it], listKeywords.SelectedItems[iw].ToString()));
                        }
                        else
                        {
                            datas.Add(model.GetData(selected_names[it], chartController.AxisX, listKeywords.SelectedItems[iw].ToString()));
                        }
                    }

                    pm.Series.Add(new OxyPlot.Series.LineSeries
                    {
                        Title = listKeywords.SelectedItems[iw].ToString() + ".sum",
                        MarkerType = OxyPlot.MarkerType.Circle
                    });

                    // Осреднение для значений не равных нулю

                    for (int it = 0; it < model.GetStepCount(); ++it)
                    {
                        double value = 0;

                        for (int ic = 0; ic < datas.Count; ++ic)
                        {
                            if (datas[ic][it].Y != 0)
                            {
                                value = value + datas[ic][it].Y;
                            }
                        }
                        ((OxyPlot.Series.LineSeries)pm.Series[iw]).Points.Add(new DataPoint(datas[0][it].X, value));
                    }
                }
            }

            pm.Axes[0].Reset();
            pm.Axes[1].Reset();

            pm.InvalidatePlot(true);
        }

        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edit_mode_keywords) return;
            if (listKeywords.SelectedItems.Count == 0) return;

            System.Diagnostics.Debug.WriteLine("LIST KEYWORDS");
            UpdateVisibleElements();
        }

        private void gridData_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.Value = model.GetDateByStep(e.RowIndex).ToShortDateString();
            else
                e.Value = model.GetParamAtIndex(selected_index[e.ColumnIndex - 1], e.RowIndex);
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            ChartOptions tmp = new ChartOptions(chartController);

            tmp.Left = buttonOptions.PointToScreen(Point.Empty).X;
            tmp.Top = buttonOptions.PointToScreen(Point.Empty).Y;
            tmp.ApplyStyle += OnApplyStyle;
            tmp.Keywords = model.GetKeywords(selected_names[0]);
            tmp.Show();
        }

        private void OnApplyStyle()
        {
            System.Diagnostics.Debug.WriteLine("CHART OPTIONS : APPLY STYLE");

            InitChart();
            UpdateVisibleElements();
        }
    }
}
