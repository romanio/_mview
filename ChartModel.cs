﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    public class ChartModel
    {
        ProjectManager pm = null;

        public string[] GetKeywords(string name)
        {
            var tmp_name = pm.ActiveProject.VECTORS.FirstOrDefault(c => c.Name == name);
            var tmp_data = tmp_name.Data.Select(c => c.keyword);
            return tmp_data.ToArray();
        }

        public DateTime GetDateByStep(int step)
        {
            return pm.ActiveProject.SUMMARY.STARTDATE.AddDays(pm.ActiveProject.SUMMARY.DATA[step][pm.ActiveProject.SUMMARY.TINDEX]);
        }

        public float GetParamAtIndex(int index, int step)
        {
            return pm.ActiveProject.SUMMARY.DATA[step][index];
        }

        public int GetStepCount()
        {
            return pm.ActiveProject.SUMMARY.NTIME;
        }

        public Vector GetDataVector(string name)
        {
            return pm.ActiveProject.VECTORS.FirstOrDefault(c => c.Name == name);
        }

        public List<OxyPlot.DataPoint> GetData(string name, string keyword_X, string keyword_Y)
        {
            var tmp_name = pm.ActiveProject.VECTORS.FirstOrDefault(c => c.Name == name);
            var tmp_axis_x = tmp_name.Data.FirstOrDefault(c => c.keyword == keyword_X);
            var tmp_axis_y = tmp_name.Data.FirstOrDefault(c => c.keyword == keyword_Y);

            List<OxyPlot.DataPoint> data = new List<OxyPlot.DataPoint>();

            for (int iw = 0; iw < pm.ActiveProject.SUMMARY.DATA.Count; ++iw)
            {
                data.Add(new OxyPlot.DataPoint(
                    pm.ActiveProject.SUMMARY.DATA[iw][tmp_axis_x.index],
                    pm.ActiveProject.SUMMARY.DATA[iw][tmp_axis_y.index]));
            }
                return data;
        }

        public List<OxyPlot.DataPoint> GetDataTime(string name, string keyword)
        {
            var tmp_name = pm.ActiveProject.VECTORS.FirstOrDefault(c => c.Name == name);
            var tmp_data = tmp_name.Data.FirstOrDefault(c => c.keyword == keyword);

            List<OxyPlot.DataPoint> data = new List<OxyPlot.DataPoint>();
            
            for (int iw = 0; iw < pm.ActiveProject.SUMMARY.DATA.Count; ++iw)
            {
                double value = pm.ActiveProject.SUMMARY.DATA[iw][tmp_data.index];

               // if (value == 0) value = double.NaN;

                data.Add(new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(
                    pm.ActiveProject.SUMMARY.STARTDATE.AddDays(
                        pm.ActiveProject.SUMMARY.DATA[iw][pm.ActiveProject.SUMMARY.TINDEX])),
                        value));
            }

            return data;
        }

        public ChartModel(ProjectManager pm)
        {
            this.pm = pm;
        }
    }
}
