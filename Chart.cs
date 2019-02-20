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

        string selected_name = null;

        public void UpdateSelectedName(string name)
        {
            pm.Title = name;
            selected_name = name;
            // Сохраним текущие выделенные слова

            var tmp_keywords = new List<string>();
            foreach (string item in listKeywords.SelectedItems)
            {
                tmp_keywords.Add(item);
            }

            edit_mode_keywords = true;

            listKeywords.Items.Clear();
            listKeywords.Items.AddRange(model.GetKeywords(name));

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

            listKeywords_SelectedIndexChanged(null, null);
        }

        private void listKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edit_mode_keywords) return;

            System.Diagnostics.Debug.WriteLine("LIST KEYWORDS");

            pm.Series.Clear();
            for (int iw = 0; iw < listKeywords.SelectedItems.Count; ++iw)
            {
                pm.Series.Add(new OxyPlot.Series.LineSeries { Title = listKeywords.SelectedItems[iw].ToString(), MarkerType = OxyPlot.MarkerType.Circle });
                ((OxyPlot.Series.LineSeries)pm.Series[iw]).Points.Clear();
                ((OxyPlot.Series.LineSeries)pm.Series[iw]).Points.AddRange(model.GetData(selected_name, listKeywords.SelectedItems[iw].ToString()));
            }

            pm.Axes[0].Reset();
            pm.Axes[1].Reset();

            pm.InvalidatePlot(true);
        }
    }
}
