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
        public Chart()
        {
            InitializeComponent();

            OxyPlot.WindowsForms.PlotView view = new OxyPlot.WindowsForms.PlotView();
            view.Dock = DockStyle.Fill;

            var pm = new OxyPlot.PlotModel
            {
                Title = "Example #1",
                Subtitle = "oil cummulative ",
                PlotType = OxyPlot.PlotType.Cartesian
            };

            //pm.Series.Add(new Fun)
            pm.Series.Add(new OxyPlot.Series.LineSeries { Title = "Oil" });

            view.Model = pm;

            tableLayoutPanel1.Controls.Add(view);
        }
    }
}
