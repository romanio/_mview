using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public class ProjectManagerItem
    {
        public EclipseProject ecl = new EclipseProject();
        public string name = null;
    }

    public class ProjectManager
    {
        public List<ProjectManagerItem> projectList = new List<ProjectManagerItem>();
        public EclipseProject ActiveProject;
        public int ActiveProjectIndex = -1;

        public void OpenECLProject()
        {
            OpenFileDialog fd = new OpenFileDialog() {Filter = "Eclipse file|*.SMSPEC" };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                var item = new ProjectManagerItem();
                item.ecl.OpenData(fd.FileName);
                item.name = item.ecl.ROOT;

                projectList.Add(item);

                if (projectList.Count == 1)
                {
                    ActiveProject = projectList[0].ecl;
                    ActiveProjectIndex = 0;
                }
            }
        }

        public void SetActiveProject(int index)
        {
            ActiveProjectIndex = index;
            ActiveProject = projectList[index].ecl;
        }

        public void UpdateActiveProject()
        {
            ActiveProject.OpenData(ActiveProject.FILENAME);
        }

    }
}
