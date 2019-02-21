using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class ChartModel
    {
        EclipseProject ecl = null;


        public string[] GetKeywords(string name)
        {
            var tmp_name = ecl.VECTORS.FirstOrDefault(c => c.Name == name);
            var tmp_data = tmp_name.Data.Select(c => c.keyword);
            return tmp_data.ToArray();
        }

        public List<OxyPlot.DataPoint> GetData(string name, string keyword)
        {
            var tmp_name = ecl.VECTORS.FirstOrDefault(c => c.Name == name);
            var tmp_data = tmp_name.Data.FirstOrDefault(c => c.keyword == keyword);

            List<OxyPlot.DataPoint> data = new List<OxyPlot.DataPoint>();
            
            for (int iw = 0; iw < ecl.SUMMARY.DATA.Count; ++iw)
            {
                data.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(
                    ecl.SUMMARY.STARTDATE.AddDays(ecl.SUMMARY.DATA[iw][ecl.SUMMARY.TINDEX])),
                    ecl.SUMMARY.DATA[iw][tmp_data.index]));
            }

            return data;
         
        }

        public ChartModel(EclipseProject ecl)
        {
            this.ecl = ecl;
        }
    }
}
