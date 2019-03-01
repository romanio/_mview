using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public partial class FormModels : Form
    {
        ProjectManager pm = null;

        public FormModels(ProjectManager pm)
        {
            InitializeComponent();

            this.pm = pm;

            checkedModelList.Items.Clear();
            foreach (ProjectManagerItem item in pm._projectList)
            {
                checkedModelList.Items.Add(item.name);
            }

        }
        private void FormModels_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonModels_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOpenModel_Click(object sender, EventArgs e)
        {
            pm.OpenECLProject();
        }

        private void checkedModelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridGeneral.Rows.Clear();
            gridGeneral.Rows.Add("FILENAME", pm._projectList[checkedModelList.SelectedIndex].ecl.FILENAME);
            gridGeneral.Rows.Add("ROOT", pm._projectList[checkedModelList.SelectedIndex].ecl.ROOT);
            gridGeneral.Rows.Add("PATH", pm._projectList[checkedModelList.SelectedIndex].ecl.PATH);

            foreach (KeyValuePair<string, string> item in pm._projectList[checkedModelList.SelectedIndex].ecl.FILES)
            {
                gridGeneral.Rows.Add(item.Key, item.Value);
            }
        }
    }
}
