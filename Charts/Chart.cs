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
        PlotModel plotModel = null;
        PlotModel specplotModel = null;
        ChartController chartController = null;

        bool edit_mode_keywords = false;

        // При изменении количества проектов

        public void SetEclipseProject(ProjectManager pm)
        {
            model = new ChartModel(pm);

            checkedProjectList.Items.Clear();

            
            foreach (ProjectManagerItem item in pm.projectList)
            {
                checkedProjectList.Items.Add(item.name);
            }

            if (pm.ActiveProjectIndex != -1)
            {
                checkedProjectList.Items[pm.ActiveProjectIndex] = checkedProjectList.Items[pm.ActiveProjectIndex] + " (ACTIVE)";
                checkedProjectList.SetItemChecked(pm.ActiveProjectIndex, true);
                selected_pm = new int[] { pm.ActiveProjectIndex };
            }
        }

        public void InitChart()
        {
            plotModel = new PlotModel
            {
                Title = "(No wells yet)",
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                LegendFontSize = 10,
                LegendPosition = chartController.LegendPosition,
               
                DefaultFontSize = 10
            };

            if (chartController.AxisX == "TIME")
            {
                plotModel.Axes.Add(new OxyPlot.Axes.DateTimeAxis
                {
                    Position = OxyPlot.Axes.AxisPosition.Bottom,
                    StringFormat = "dd.MM.yyyy",
                    MajorGridlineStyle = chartController.AxisXStyle,
                    MajorGridlineThickness = chartController.AxisXWidth,
                    MajorGridlineColor = chartController.AxisXColor.ToOxyColor()
                });
            }
            else
            {
                plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
                {
                    Position = AxisPosition.Bottom,
                    Title = chartController.AxisX,
                });
            }

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                MajorGridlineStyle = chartController.AxisYStyle,
                MajorGridlineThickness = chartController.AxisYWidth,
                MajorGridlineColor = chartController.AxisYColor.ToOxyColor()
            });

            plotView1.Model = plotModel;

            //

            specplotModel = new PlotModel
            {
                Title = "Waterflood Diagnostic",
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                LegendFontSize = 10,
               // LegendPosition = chartController.LegendPosition,

                DefaultFontSize = 10
            };

            specplotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Oil cummulative",
                MajorGridlineStyle = chartController.AxisXStyle,
                MajorGridlineThickness = chartController.AxisXWidth,
                MajorGridlineColor = chartController.AxisXColor.ToOxyColor()
            });

            specplotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "WaterCut",
                MajorGridlineStyle = chartController.AxisYStyle,
                MajorGridlineThickness = chartController.AxisYWidth,
                MajorGridlineColor = chartController.AxisYColor.ToOxyColor()
            });

            plotView2.Model = specplotModel;
            
        }

        public Chart(ProjectManager pm, ChartController chartController)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, gridData, new object[] { true });

            model = new ChartModel(pm);
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

            InitChart();
            listKeywords_SelectedIndexChanged(null, null);
        }

        int[] selected_index = null;
        int[] selected_pm = null;

        void UpdateVisibleElements()
        {
            // Обновим специальные операции

            specplotModel.Series.Clear();

            int series_index = 0;

            for (int it = 0; it < selected_names.Length; ++it)
            {
                specplotModel.Series.Add(new LineSeries
                {
                    Title = "Sim",
                    LineStyle = OxyPlot.LineStyle.Solid,
                    StrokeThickness = 2,
                    Smooth = false,
                    MarkerType =  OxyPlot.MarkerType.Circle,
                    MarkerSize = 3
                });

                ((OxyPlot.Series.LineSeries)specplotModel.Series[series_index]).Points.AddRange(
                    model.GetData(selected_names[it], "WOPT", "WWCT"));

                series_index++;

                specplotModel.Series.Add(new LineSeries
                {
                    Title = "Hist",
                    LineStyle = OxyPlot.LineStyle.Solid,
                    StrokeThickness = 2,
                    Smooth = false,
                    MarkerType = OxyPlot.MarkerType.Circle,
                    MarkerSize = 3
                });

                ((OxyPlot.Series.LineSeries)specplotModel.Series[series_index]).Points.AddRange(
                    model.GetData(selected_names[it], "WOPTH", "WWCTH"));

                series_index++;
            }

            specplotModel.Axes[0].Reset();
            specplotModel.Axes[1].Reset();

            specplotModel.InvalidatePlot(true);

            // Обновим таблицу

            gridData.ColumnCount = selected_names.Length * listKeywords.SelectedItems.Count + 1;
            gridData.Columns[0].HeaderText = "Date";
            gridData.RowCount = model.GetStepCountActive();
            gridData.VirtualMode = false;

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

            gridData.VirtualMode = true;

            // Заглавие графика

            StringBuilder title_name = new StringBuilder();

            for (int iw = 0; iw < selected_names.Length - 1; ++iw)
                title_name.Append(selected_names[iw] + ", ");

            title_name.Append(selected_names.Last());

            plotModel.Title = title_name.ToString();

            // Размерность оси Y

            if (selected_units.Count > 0)
            {
                selected_units = selected_units.Distinct().ToList();

                StringBuilder axis_y_name = new StringBuilder();

                for (int iw = 0; iw < selected_units.Count - 1; ++iw)
                    axis_y_name.Append(selected_units[iw] + ", ");

                axis_y_name.Append(selected_units.Last());

                plotModel.Axes[1].Title = axis_y_name.ToString();
            }

            // Обновить график

            plotModel.Series.Clear();
   
            series_index = -1;

            for (int ip = 0; ip < selected_pm.Length; ++ip) // Цикл по всем выбранным проектам
            {
                for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
                {
                    List<List<OxyPlot.DataPoint>> datas = new List<List<OxyPlot.DataPoint>>();

                    for (int it = 0; it < selected_names.Length; ++it) // Считывание данных
                    {
                        var tmp_data = model.GetDataTime(selected_pm[ip], selected_names[it], listKeywords.SelectedItems[iw].ToString());
                        datas.Add(tmp_data);
                    }

                    // Определение стиля линии графика

                    var tmp_style = chartController.GetStyle(listKeywords.SelectedItems[iw].ToString());

                    if (tmp_style?.GroupMode == GroupMode.Normal || tmp_style == null) // Обычный режим отображения
                    {
                        for (int it = 0; it < selected_names.Length; ++it)
                        {
                            var tmp_ls = new LineSeries
                            {
                                Title = listKeywords.SelectedItems[iw].ToString() + "." + model.GetName(selected_pm[ip]),
                                LineStyle = tmp_style?.LineStyle ?? OxyPlot.LineStyle.Solid,
                                StrokeThickness = tmp_style?.LineWidth ?? 1,
                                Smooth = tmp_style?.LineSmooth ?? false,
                                MarkerType = tmp_style?.MarkerType ?? OxyPlot.MarkerType.Circle,
                                MarkerSize = tmp_style?.MarkerSize ?? 4,
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

                            plotModel.Series.Add(tmp_ls);
                            series_index++;

                            ((OxyPlot.Series.LineSeries)plotModel.Series[series_index]).Points.Clear();
                            ((OxyPlot.Series.LineSeries)plotModel.Series[series_index]).Points.AddRange(datas[it]);
                        }
                    }

                    if (tmp_style?.GroupMode == GroupMode.Average)
                    {
                        var tmp_ls = new LineSeries
                        {
                            Title = listKeywords.SelectedItems[iw].ToString() + ".av." +model.GetName(selected_pm[ip]),
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

                        plotModel.Series.Add(tmp_ls);
                        series_index++;

                        // Осреднение для значений не равных нулю

                        for (int it = 0; it < model.GetStepCount(selected_pm[ip]); ++it)
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

                            ((OxyPlot.Series.LineSeries)plotModel.Series[series_index]).Points.Add(new DataPoint(datas[0][it].X, count > 0 ? value / count : 0));
                        }
                    }

                    if (tmp_style?.GroupMode == GroupMode.Sum)
                    {
                        var tmp_ls = new LineSeries
                        {
                            Title = listKeywords.SelectedItems[iw].ToString() + ".sum." + model.GetName(selected_pm[ip]),
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

                        plotModel.Series.Add(tmp_ls);
                        series_index++;

                        for (int it = 0; it < model.GetStepCount(selected_pm[ip]); ++it)
                        {
                            double value = 0;

                            for (int ic = 0; ic < datas.Count; ++ic)
                            {
                                if (datas[ic][it].Y != 0)
                                {
                                    value = value + datas[ic][it].Y;
                                }
                            }
                            ((OxyPlot.Series.LineSeries)plotModel.Series[series_index]).Points.Add(new DataPoint(datas[0][it].X, value));
                        }
                    }
                }
            }

            // Пользовательские вектора
          
            if (checkShowUserFunction.Checked)
            {
                plotModel.Annotations.Clear();

                for (int it = 0; it < selected_names.Length; ++it)
                {
                    var tmp_data = chartController.GetUserFunction(selected_names[it]);

                    if (tmp_data != null)
                    {
                        plotModel.Series.Add(new LineSeries
                        {
                            Title = "User",
                            LineStyle = LineStyle.None,
                            MarkerType = MarkerType.Circle,
                            MarkerSize = 4
                        });

                        ((OxyPlot.Series.LineSeries)plotModel.Series.Last()).Points.AddRange(tmp_data);

                        // Добавление аннотаций

                        var tmp_anno = chartController.GetAnnotation(selected_names[it]);
                        
                        foreach(ChartController.AnnotationItem item in tmp_anno)
                        {
                            plotModel.Annotations.Add(new OxyPlot.Annotations.TextAnnotation
                            {
                                TextPosition = new DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(item.time), item.value),
                                TextRotation = -90,
                                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Left,
                                Text = item.text
                            });
                        }                 
                    }
                }
            }

            plotModel.Axes[0].Reset();
            plotModel.Axes[1].Reset();

            plotModel.InvalidatePlot(true);
        }

        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edit_mode_keywords) return;
            if (tabControl1.SelectedIndex == 2)
            {
                UpdateVisibleElements();
            }

            if (listKeywords.SelectedItems.Count == 0) return;

            System.Diagnostics.Debug.WriteLine("LIST KEYWORDS");
            UpdateVisibleElements();
        }

        private void gridData_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == 0)
                e.Value = model.GetDateByStep(e.RowIndex).ToString(); //.ToShortDateString();
            else
                e.Value = model.GetParamAtIndex(selected_index[e.ColumnIndex - 1], e.RowIndex);
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void checkedProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected_pm = new int[checkedProjectList.CheckedIndices.Count];

            for (int iw = 0; iw < checkedProjectList.CheckedIndices.Count; ++iw)
            {
                selected_pm[iw] = checkedProjectList.CheckedIndices[iw];
            }

            UpdateVisibleElements();
        }

        private void buttonLoadUserFunction_Click(object sender, EventArgs e)
        {
            chartController.LoadUserFunctions();
            checkShowUserFunction.Enabled = true;
        }

        private void checkShowUserFunction_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisibleElements();
        }
    }
}
