using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview
{
    class FormMainModel
    {
        ProjectManager pm = new ProjectManager();

        public void OpenNewModel()
        {
            pm.OpenECLProject();
        }

        public void ShowModelsForm(int X, int Y)
        {
            FormModels tmp = new FormModels(pm);

            tmp.Left = X;
            tmp.Top = Y;
            tmp.Show();
        }

        public void ShowDetailForm()
        {
            FormDetails fm = new FormDetails(pm.ActiveProject);
            fm.ShowDialog();
        }

        public EclipseProject GetActiveProject()
        {
            return pm.ActiveProject;
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
