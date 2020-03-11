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
        FormMainModel model;
        
        public event EventHandler ApplyStyle;

        public SubMainProject(FormMainModel model)
        {
            InitializeComponent();
            this.model = model;
        }

        public void UpdateSubForm()
        {
            boxActiveProject.Items.Clear();
            boxActiveProject.BeginUpdate();
            gridGeneral.Rows.Clear();

            foreach (ProjectManagerItem item in model.GetProjectManager().projectList)
            {
                boxActiveProject.Items.Add(item.name);
            };

            boxActiveProject.SelectedIndex = model.GetProjectManager().ActiveProjectIndex;
            boxActiveProject.EndUpdate();
        }

        private void SubMainProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void boxActiveProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = boxActiveProject.SelectedIndex;
            var pm = model.GetProjectManager();

            gridGeneral.Rows.Clear();
            gridGeneral.Rows.Add("FILENAME", pm.projectList[index].ecl.FILENAME);
            gridGeneral.Rows.Add("ROOT", pm.projectList[index].ecl.ROOT);
            gridGeneral.Rows.Add("PATH", pm.projectList[index].ecl.PATH);

            foreach (KeyValuePair<string, string> item in pm.projectList[index].ecl.FILES)
            {
                gridGeneral.Rows.Add(item.Key, item.Value);
            }
            
            pm.SetActiveProject(index);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.GetProjectManager().DeleteActiveProject();
            UpdateSubForm();
            ApplyStyle(sender, e);
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (boxNewName.Visible == false)
            {
                boxNewName.Visible = true;
                boxNewName.Text = model.GetProjectManager().projectList[boxActiveProject.SelectedIndex].name;
                boxNewName.Focus();
                buttonRename.Text = "Set new name";
            }
            else
            {
                boxNewName.Visible = false;
                model.GetProjectManager().projectList[boxActiveProject.SelectedIndex].name = boxNewName.Text;
                buttonRename.Text = "Rename";
                UpdateSubForm();
                ApplyStyle(sender, e);
            }
        }
    }
}
