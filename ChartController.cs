using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;

namespace mview
{
    public class SeriesStyle
    {
        public string Name;
        //
        public OxyColor LineColor;
        public OxyColor MarkerColor;
        public OxyColor MarkerFillColor;
        //
        public int MarkerSize;
        public int LineWidth;

        public bool LineSmooth;
        public MarkerType MarkerType;
        public LineStyle LineStyle;
    }

    public class ChartController
    {
        List<SeriesStyle> listSeriesStyle = new List<SeriesStyle>();

        public string AxisX = "TIME";
        public string AxisY = "Normal";
    }
}
