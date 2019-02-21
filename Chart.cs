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
            //pm.Title = name;
            selected_names = names;

            // Сохраним текущие выделенные слова

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

        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edit_mode_keywords) return;

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

            gridData.ColumnCount = listKeywords.SelectedItems.Count + 1;
            gridData.Columns[0].HeaderText = "Date";

        }
    }
}
