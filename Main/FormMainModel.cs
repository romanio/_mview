﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;

namespace mview
{
    public class FormMainModel
    {
        private readonly ProjectManager pm = new ProjectManager();

        public void UpdateActiveProject()
        {
            pm.UpdateActiveProject();
        }

        public void OpenNewModel()
        {
            pm.OpenECLProject();
        }

        public ProjectManager GetProjectManager()
        {
            return pm;
        }

        public void ShowCrossPlots()
        {
            var tmp = new FormCrossPlots(pm);
            tmp.Show();
        }

        public void ShowVirtualGroups()
        {
            var tmp = new FormVirtualGroups(pm);
            tmp.Show();
        }

        public void Show2DView()
        {
            var tmp = new Form2D(pm.ActiveProject);
            tmp.Show();
        }

        public void Show3DView()
        {
            var tmp = new Form3D(pm.ActiveProject);
            tmp.Show();
        }

        public void ShowDetailForm()
        {
            var tmp = new FormDetails(pm.ActiveProject);
            tmp.ShowDialog();
        }

        public string[] GetNamesFromVGroup(string selected_pad)
        {
            var wells = (from item in pm.VirtualGroup
                         where item.pad == selected_pad
                         select item.wellname).ToArray();

            return wells.ToArray();
        }

        public string[] GetVirtualGroups()
        {
            if (pm.VirtualGroup != null)
            {
                var pads = (from item in pm.VirtualGroup
                            select item.pad).Distinct().ToArray();
                return pads;
            }
            return null;
        }

        public string GetActiveProjectName()
        {
            return pm.projectList[pm.ActiveProjectIndex].name;
        }

        public void ExportToExcel()
        {
            // save to excel

            var XL = new Microsoft.Office.Interop.Excel.Application
            {
                Visible = false,
                Interactive = false,
                ScreenUpdating = false,
                SheetsInNewWorkbook = 1
            };

            Workbook wb = XL.Workbooks.Add();
            Worksheet ws = XL.Worksheets[1];
            ws.Name = "DATA";

            var range = ws.get_Range(
                ((Range)ws.Cells[2, 1]).Address,
                ((Range)ws.Cells[2 + pm.ActiveProject.SUMMARY.KEYWORDS.Length - 1, 4]).Address);

            object[,] keys = new object[pm.ActiveProject.SUMMARY.KEYWORDS.Length, 4];

            for (int iw = 0; iw < pm.ActiveProject.SUMMARY.KEYWORDS.Length; ++iw)
            {
                keys[iw, 0] = pm.ActiveProject.SUMMARY.KEYWORDS[iw];
                keys[iw, 1] = pm.ActiveProject.SUMMARY.WGUNITS[iw];
                keys[iw, 2] = pm.ActiveProject.SUMMARY.WGNAMES[iw];
                keys[iw, 3] = pm.ActiveProject.SUMMARY.NUMS[iw];
            }
            range.Value = keys;

            range = ws.get_Range(
                ((Range)ws.Cells[2, 5]).Address,
                ((Range)ws.Cells[2 + pm.ActiveProject.SUMMARY.KEYWORDS.Length - 1, 5 + pm.ActiveProject.SUMMARY.NTIME - 1]).Address);

            object[,] data = new object[pm.ActiveProject.SUMMARY.KEYWORDS.Length, pm.ActiveProject.SUMMARY.NTIME];

            for (int it = 0; it < pm.ActiveProject.SUMMARY.NTIME; ++it)
            {
                for (int iw = 0; iw < pm.ActiveProject.SUMMARY.KEYWORDS.Length; ++iw)
                {
                    data[iw, it] = pm.ActiveProject.SUMMARY.DATA[it][iw];
                }
            }

            range.Value = data;
            XL.Visible = true;
            XL.Interactive = true;
            XL.ScreenUpdating = true;
    }

    public EclipseProject GetActiveProject()
        {
            return pm.ActiveProject;
        }

        public string[] GetAllKeywords()
        {
            return pm.ActiveProject.SUMMARY.KEYWORDS.Distinct().ToArray();
        }

        public string[] GetNamesByType(NameOptions type)
        {
            return
                (from item in pm.ActiveProject.VECTORS
                 where item.Type == type
                 select item.Name).ToArray();
        }
    }
}
