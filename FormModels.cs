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

        void UpdateData()
        {

            boxActiveProject.Items.Clear();
            boxActiveProject.BeginUpdate();

            foreach (ProjectManagerItem item in pm.projectList)
            {
                boxActiveProject.Items.Add(item.name);
            };

            boxActiveProject.SelectedIndex = pm.ActiveProjectIndex;
            boxActiveProject.EndUpdate();
        }

        public FormModels(ProjectManager pm)
        {
            InitializeComponent();

            this.pm = pm;

            UpdateData();
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

        private void boxActiveProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = boxActiveProject.SelectedIndex;

            gridGeneral.Rows.Clear();
            gridGeneral.Rows.Add("FILENAME", pm.projectList[index].ecl.FILENAME);
            gridGeneral.Rows.Add("ROOT", pm.projectList[index].ecl.ROOT);
            gridGeneral.Rows.Add("PATH", pm.projectList[index].ecl.PATH);

            foreach (KeyValuePair<string, string> item in pm.projectList[index].ecl.FILES)
            {
                gridGeneral.Rows.Add(item.Key, item.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (boxNewName.Visible == false)
            {
                boxNewName.Visible = true;
                buttonRename.Text = "Finish";
                boxNewName.Text = pm.projectList[boxActiveProject.SelectedIndex].name;
            }
            else
            {
                boxNewName.Visible = false;
                buttonRename.Text = "Rename";
                pm.projectList[boxActiveProject.SelectedIndex].name = boxNewName.Text;
                UpdateData();
            }
        }
    }
}
