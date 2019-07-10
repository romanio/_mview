using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class FormCrossPlotsModel
    {
        EclipseProject ecl = null;

        public FormCrossPlotsModel(EclipseProject ecl)
        {
            this.ecl = ecl;
        }

        public string[] GetDates()
        {
            List<string> dates = new List<string>();
            for (int istep = 0; istep < ecl.SUMMARY.NTIME; ++istep)
            {
                dates.Add(ecl.SUMMARY.STARTDATE.AddDays(ecl.SUMMARY.DATA[istep][ecl.SUMMARY.TINDEX]).ToString());
            }

            return dates.ToArray();
        }

        public List<Tuple<string, float, float>> GetDataByKeywordAndDate(string keyword, int step)
        {
            string wellname;
            float sim_value;
            float hist_value;

            var res = new List<Tuple<string, float, float>>();

            foreach (Vector item in ecl.VECTORS)
            {
                if (item.Type == NameOptions.Well)
                {
                    var found_sim = item.Data.FirstOrDefault(c => c.keyword == ("W" + keyword));

                    if (found_sim.keyword != null)
                    {
                        wellname = item.Name;
                        sim_value = ecl.SUMMARY.DATA[step][found_sim.index];
                        hist_value = 0;

                        var found_hist = item.Data.FirstOrDefault(c => c.keyword == ("W" + keyword + "H"));

                        if (found_hist.keyword != null)
                        {
                            hist_value = ecl.SUMMARY.DATA[step][found_hist.index];
                        }

                        res.Add(new Tuple<string, float, float>(wellname, sim_value, hist_value));
                    }
                }
            }

            return res;
        } 
    }
}
