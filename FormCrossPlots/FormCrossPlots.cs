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
    public partial class FormCrossPlots : Form
    {
        FormCrossPlotsModel model = null;
        PlotModel plotModel = null;
                
        public FormCrossPlots(EclipseProject ecl)
        {
            InitializeComponent();
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
                Title = "(No wells yet)",
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                DefaultFontSize = 10
            };

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Axis X"
            });
        

        plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                Title = "Axis Y"
            });

            plotView1.Model = plotModel;

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

            gridData.Rows.Clear();

            int step = boxRestart.SelectedIndex;
            string keyword = listKeywords.SelectedItem.ToString();
            var data = model.GetDataByKeywordAndDate(keyword, step);

            int row = -1;

            int over20 = 0;
            int over10 = 0;
            int less10 = 0;

            foreach (Tuple<string, float, float> item in data)
            {
                if ((item.Item2 != 0.00) && (item.Item3 != 0.00))
                {
                    row = gridData.Rows.Add();

                    gridData[0, row].Value = item.Item1;
                    gridData[1, row].Value = item.Item2;
                    gridData[2, row].Value = item.Item3;
                    gridData[3, row].Value = item.Item2 - item.Item3;
                    float diff = 100 * (item.Item2 - item.Item3) / item.Item3;

                    gridData[4, row].Value = diff;

                    if (Math.Abs(diff) <= 10) less10++;
                    if ((Math.Abs(diff) > 10) && (Math.Abs(diff) <= 20)) over10++;
                    if (Math.Abs(diff) > 20) over20++;

                }
            }



        }
    }
}
