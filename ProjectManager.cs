using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    class ProjectManagerItem
    {
        public EclipseProject ecl = new EclipseProject();
        public string name = null;
    }

    class ProjectManager
    {
        public List<ProjectManagerItem> _projectList = new List<ProjectManagerItem>();
        public EclipseProject ActiveProject;

        public void OpenECLProject()
        {
            OpenFileDialog fd = new OpenFileDialog() {Filter = "Eclipse file|*.SMSPEC" };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                var item = new ProjectManagerItem();
                item.ecl.OpenData(fd.FileName);
                item.name = item.ecl.ROOT;

                _projectList.Add(item);

                if (_projectList.Count == 1)
                    ActiveProject = _projectList[0].ecl;
            }
        }
    }
}
