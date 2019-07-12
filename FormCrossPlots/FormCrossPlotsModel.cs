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

        public string[] GetVirtalGroups()
        {
            if (ecl.VirtualGroup == null) return null;

            var pads = (from item in ecl.VirtualGroup
                        select item.pad).Distinct().ToArray();

            return pads;
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

        public void LoadVirtualGroups()
        {
            var fd = new System.Windows.Forms.OpenFileDialog() { Filter = "User group file|*.csv" };

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ecl.VirtualGroup = new List<VirtualGroupItem>();

                using (System.IO.TextReader text = new System.IO.StreamReader(fd.FileName, Encoding.GetEncoding("Windows-1251")))
                {
                    string line;

                    while ((line = text.ReadLine()) != null)
                    {
                        string[] split = line.Split(new char[] { ';' });

                        if (split.Length == 2)
                        {
                            ecl.VirtualGroup.Add(new VirtualGroupItem
                            {
                                wellname = split[0].Trim(),
                                pad = split[1].Trim()
                            });
                        }
                    }
                    text.Close();
                }
            }
        }

        public List<Tuple<string, float, float>> GetDataByPadKeywordAndDate(string pad, string keyword, int step)
        {
            string wellname;
            float sim_value;
            float hist_value;
            
            var wells = (from item in ecl.VirtualGroup
                         where item.pad == pad
                         select item.wellname).ToArray();

            var res = new List<Tuple<string, float, float>>();

            foreach (Vector item in ecl.VECTORS)
            {
                if (item.Type == NameOptions.Well && Array.IndexOf(wells, item.Name) > 0)
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
