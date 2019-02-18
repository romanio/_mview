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

        public Chart(EclipseProject ecl)
        {
            InitializeComponent();
            model = new ChartModel(ecl);

            pm = new OxyPlot.PlotModel
            {
                Title = "Example #1",
                PlotType = OxyPlot.PlotType.Cartesian,
                DefaultFont = "Tahoma",
                TitleFontWeight = 2,
                TitleFontSize = 10,
                LegendFontSize = 9,
                DefaultFontSize = 10
            };

            pm.Series.Add(new OxyPlot.Series.LineSeries { Title = "WOPRH", MarkerType = OxyPlot.MarkerType.Circle });
            pm.Series.Add(new OxyPlot.Series.LineSeries { Title = "WOPR", MarkerType = OxyPlot.MarkerType.Circle });


            plotView1.Model = pm;
        }

        public void UpdateSelectedName(string name)
        {
            button1.Text = name;

            ((OxyPlot.Series.LineSeries)pm.Series[0]).Points.Clear();
            ((OxyPlot.Series.LineSeries)pm.Series[0]).Points.AddRange(model.GetData(name, "WOPRH"));

            ((OxyPlot.Series.LineSeries)pm.Series[1]).Points.Clear();
            ((OxyPlot.Series.LineSeries)pm.Series[1]).Points.AddRange(model.GetData(name, "WOPR"));


            pm.Axes[0].Reset();
            pm.Axes[1].Reset();

            pm.InvalidatePlot(true);

            //
        }
    }
}
