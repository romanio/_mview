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
            textPath.Text = pm._projectList[checkedModelList.SelectedIndex].ecl.PATH;
        }
    }
}
