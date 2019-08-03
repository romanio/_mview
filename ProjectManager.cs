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

    public class VirtualGroupItem
    {
        public string wellname;
        public string pad;
    }

    public class ProjectManager
    {
        public List<ProjectManagerItem> projectList = new List<ProjectManagerItem>();
        public EclipseProject ActiveProject;
        public List<VirtualGroupItem> VirtualGroup = null;
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

                // Set last project as active

                ActiveProject = projectList.Last().ecl;
                ActiveProjectIndex = projectList.Count - 1;
            }
        }

        public void DeleteActiveProject()
        {
            projectList.RemoveAt(ActiveProjectIndex);

            if (projectList.Count > 0)
            {
                ActiveProject = projectList.Last().ecl;
                ActiveProjectIndex = projectList.Count - 1;
            }
            else // полное удаление
            {
                ActiveProjectIndex = -1;
                ActiveProject = null;
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
