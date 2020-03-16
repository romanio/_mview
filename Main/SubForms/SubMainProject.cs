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
    public partial class SubMainProject : Form
    {
        private readonly ProjectManager pm = null;

        public event EventHandler UpdateData;

        public SubMainProject(ProjectManager pm)
        {
            InitializeComponent();
            this.pm = pm;
        }

        public void UpdateSelectedProjects()
        {
            listboxProjectNames.Items.Clear();

            foreach (ProjectManagerItem item in pm.projectList)
            {
                listboxProjectNames.Items.Add(item.name, item.selected);
            };

            if (pm.ActiveProjectIndex != -1)
            {
                listboxProjectNames.Items[pm.ActiveProjectIndex] = listboxProjectNames.Items[pm.ActiveProjectIndex] + " (ACTIVE)";
            }
        }

        public void UpdateSubForm()
        {
            gridGeneral.Rows.Clear();
            boxActiveProject.Items.Clear();
            boxActiveProject.BeginUpdate();

            foreach (ProjectManagerItem item in pm.projectList)
            {
                boxActiveProject.Items.Add(item.name);
            };

            boxActiveProject.SelectedIndex = pm.ActiveProjectIndex;
            boxActiveProject.EndUpdate();

            UpdateSelectedProjects();
        }

        private void SubMainProjectOnFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void boxActiveProjectOnSelectedIndexChanged(object sender, EventArgs e)
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
            
            pm.SetActiveProject(index);
            UpdateSelectedProjects();
            UpdateData(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pm.DeleteActiveProject();
            UpdateSubForm();
            UpdateData(sender, e);
        }

        private void buttonRenameOnClick(object sender, EventArgs e)
        {
            if (boxNewName.Visible == false)
            {
                boxNewName.Visible = true;
                boxNewName.Text = pm.projectList[boxActiveProject.SelectedIndex].name;
                boxNewName.Focus();
                buttonRename.Text = "Set new name";
            }
            else
            {
                boxNewName.Visible = false;
                pm.projectList[boxActiveProject.SelectedIndex].name = boxNewName.Text;
                buttonRename.Text = "Rename";
                UpdateSubForm();
                UpdateData(sender, e);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void boxNewName_TextChanged(object sender, EventArgs e)
        {

        }

        private void listboxProjectNamesOnSelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listboxProjectNames.SelectedIndex;
            pm.projectList[index].selected = listboxProjectNames.GetItemChecked(index);
            UpdateData(sender, e);
        }
    }
}
