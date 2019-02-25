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

namespace mview
{
    public partial class Chart : UserControl
    {
        ChartModel model = null;
        OxyPlot.PlotModel pm = null;

        bool edit_mode_keywords = false;

        public void SetEclipseProject(EclipseProject ecl)
        {
            model = new ChartModel(ecl);
        }

        public Chart(EclipseProject ecl)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, gridData, new object[] { true });


            model = new ChartModel(ecl);

            listKeywords.Items.Clear();

            pm = new OxyPlot.PlotModel
            {
                Title = "(No wells yet)",
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                LegendFontSize = 10,
                DefaultFontSize = 10
            };

            pm.Axes.Add(new OxyPlot.Axes.DateTimeAxis {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                StringFormat = "dd.MM.yyyy"
            });

            pm.Axes.Add(new OxyPlot.Axes.LinearAxis {
                Position = OxyPlot.Axes.AxisPosition.Left
            });
    
            plotView1.Model = pm;
        }

        string[] selected_names = null;

        public void UpdateSelectedNames(string[] names)
        {
            // Заглавие графика

            StringBuilder title_name = new StringBuilder();

            for (int iw = 0; iw < names.Length - 1; ++iw)
                title_name.Append(names[iw] + ",");

            title_name.Append(names.Last());

            pm.Title = title_name.ToString();

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

            listKeywords_SelectedIndexChanged(null, null);
        }

        int[] selected_index = null;

        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edit_mode_keywords) return;
            if (listKeywords.SelectedItems.Count == 0) return;

            System.Diagnostics.Debug.WriteLine("LIST KEYWORDS");

            // Обновить график

            pm.Series.Clear();

            for (int it = 0; it < selected_names.Length; ++it)
            {
                for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
                {
                    var data = model.GetData(selected_names[it], listKeywords.SelectedItems[iw].ToString());

                    pm.Series.Add(new OxyPlot.Series.LineSeries
                    {
                        Title = listKeywords.SelectedItems[iw].ToString(),
                        MarkerType = OxyPlot.MarkerType.Circle
                    });

                    ((OxyPlot.Series.LineSeries)pm.Series[it * listKeywords.SelectedItems.Count +  iw]).Points.Clear();
                    ((OxyPlot.Series.LineSeries)pm.Series[it * listKeywords.SelectedItems.Count + iw]).Points.AddRange(data);
                }
            }

            pm.Axes[0].Reset();
            pm.Axes[1].Reset();

            pm.InvalidatePlot(true);

            // А теперь и таблицу

            gridData.ColumnCount = selected_names.Length * listKeywords.SelectedItems.Count + 1;
            gridData.Columns[0].HeaderText = "Date";
            gridData.RowCount = model.GetStepCount();
            gridData.VirtualMode = true;

            int index = 1;
            selected_index = new int[selected_names.Length * listKeywords.SelectedItems.Count];

            for (int it = 0; it < selected_names.Length; ++it)
            {
                var vector = model.GetDataVector(selected_names[it]);

                for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
                {
                    var data = vector.Data.FirstOrDefault(c => c.keyword == listKeywords.SelectedItems[iw].ToString());
                    selected_index[index - 1] = data.index;
                    gridData.Columns[index++].HeaderText = vector.Name + "\n" + data.keyword + "\n" + data.unit;
                }
            }
        }

        private void gridData_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.ColumnIndex == 0) e.Value = model.GetDateByStep(e.RowIndex).ToShortDateString();
            else
                e.Value = model.GetParamAtIndex(selected_index[e.ColumnIndex - 1], e.RowIndex);
        }
    }
}
