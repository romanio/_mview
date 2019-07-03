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
    public partial class FormMain : Form
    {
        FormMainModel model = new FormMainModel();
        NameOptions namesType = NameOptions.Well;

        ChartController chartController = new ChartController();

        // Свойства управляемые из модели

        public string[] Names
        {
            set
            {
                listNames.BeginUpdate();

                // Сохраним текущие выделенные имена

                var tmp_names = new List<string>();
                foreach (string item in listNames.SelectedItems)
                {
                    tmp_names.Add(item);
                }

                listNames.Items.Clear();
                listNames.Sorted = checkSorted.Checked;

                if (value != null)
                    listNames.Items.AddRange(value);

                // Востановим выделенные слова

                int index = -1;
                foreach (string item in tmp_names)
                {
                    index = listNames.Items.IndexOf(item);

                    if (index != -1)
                    {
                        listNames.SetSelected(index, true);
                    }
                }

                listNames.EndUpdate();
            }
        }

        public FormMain()
        {
            InitializeComponent();

            chartController.LoadSettings();

            boxSetChartCount.SelectedIndex = 0;
            boxNamesType.SelectedIndex = 2;
        }

        private void openModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.OpenNewModel();

            if (model.GetActiveProject() == null) return;

            UpdateData();
            panel1.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            switch (boxSetChartCount.SelectedIndex)
            {
                case 0:
                    tableLayoutPanel1.RowCount = 1;
                    tableLayoutPanel1.ColumnCount = 1;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetProjectManager(), chartController) { Dock = DockStyle.Fill });

                    break;
                case 1:
                    tableLayoutPanel1.RowCount = 1;
                    tableLayoutPanel1.ColumnCount = 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetProjectManager(), chartController) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetProjectManager(), chartController) { Dock = DockStyle.Fill });
                    break;
                case 2:
                    tableLayoutPanel1.RowCount = 2;
                    tableLayoutPanel1.ColumnCount = 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                    tableLayoutPanel1.Controls.Add(new Chart(model.GetProjectManager(), chartController) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetProjectManager(), chartController) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetProjectManager(), chartController) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetProjectManager(), chartController) { Dock = DockStyle.Fill });

                    break;
                case 3:
                    break;
            }

            UpdateData();
        }

        private void listNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listNames.SelectedItem == null) return;

            System.Diagnostics.Debug.WriteLine("LIST NAMES");

            var names = new List<string>(listNames.SelectedItems.Count);
            foreach (object item in listNames.SelectedItems)
            {
                names.Add(item.ToString());
            }

            foreach (Chart item in tableLayoutPanel1.Controls)
            {
                item.UpdateSelectedNames(names.ToArray());
            }
        }

        private void boxNamesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (boxNamesType.SelectedIndex)
            {
                case 0:
                    namesType = NameOptions.Field;
                    break;
                case 1:
                    namesType = NameOptions.Group;
                    break;
                case 2:
                    namesType = NameOptions.Well;
                    break;
                case 3:
                    namesType = NameOptions.Aquifer;
                    break;
                case 4:
                    namesType = NameOptions.Region;
                    break;
                case 5:
                    namesType = NameOptions.Other;
                    break;
            }

            if (model.GetActiveProject() == null) return;

            Names = model.GetNamesByType(namesType);
        }

        private void checkSorted_CheckedChanged(object sender, EventArgs e)
        {
            if (model.GetActiveProject() == null) return;
            Names = model.GetNamesByType(namesType);
        }

        void UpdateDataModels()
        {

            boxActiveProject.Items.Clear();
            boxActiveProject.BeginUpdate();

            foreach (ProjectManagerItem item in model.GetProjectManager().projectList)
            {
                boxActiveProject.Items.Add(item.name);
            };

            boxActiveProject.SelectedIndex = model.GetProjectManager().ActiveProjectIndex;
            boxActiveProject.EndUpdate();
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            UpdateDataModels();
        }

        void UpdateData()
        {
            if (model.GetActiveProject() == null)
            {
                buttonModels.Text = @"\\\";

                foreach (Chart item in tableLayoutPanel1.Controls)
                {
                    item.SetEclipseProject(model.GetProjectManager());
                }

                gridGeneral.Rows.Clear();
                listNames.Items.Clear();
            }
            else
            {

                buttonModels.Text = model.GetActiveProjectName();

                foreach (Chart item in tableLayoutPanel1.Controls)
                {
                    item.SetEclipseProject(model.GetProjectManager());
                }

                boxNamesType_SelectedIndexChanged(null, null);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            model.ShowDetailForm();
        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.ExportToExcel();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            chartController.SaveSettings();
        }

        private void buttonChartOptions_Click(object sender, EventArgs e)
        {
            ChartOptions tmp = new ChartOptions(chartController);

            tmp.Left = buttonChartOptions.PointToScreen(Point.Empty).X;
            tmp.Top = buttonChartOptions.PointToScreen(Point.Empty).Y;
            tmp.ApplyStyle += OnChartApplyStyle;
            tmp.Keywords = model.GetAllKeywords().OrderBy(c => c).ToArray();
            tmp.Show();
        }

        private void OnChartApplyStyle()
        {
            System.Diagnostics.Debug.WriteLine("CHART OPTIONS : CHART APPLY STYLE");
            listNames_SelectedIndexChanged(null, null);
        }

        private void dViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.Show2DView();
        }

        private void dViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            model.Show3DView();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
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

            UpdateData();
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (boxNewName.Visible == false)
            {
                boxNewName.Visible = true;
                boxNewName.Text = model.GetProjectManager().projectList[boxActiveProject.SelectedIndex].name;
                boxNewName.Focus();
            }
            else
            {
                boxNewName.Visible = false;
                model.GetProjectManager().projectList[boxActiveProject.SelectedIndex].name = boxNewName.Text;
                UpdateDataModels();
            }
        }

        private void boxNewName_Leave(object sender, EventArgs e)
        {
            buttonRename_Click(null, null);
        }

        private void bbUpdate_Click(object sender, EventArgs e)
        {
            model.UpdateActiveProject();
            UpdateData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.GetProjectManager().DeleteActiveProject();
            UpdateData();
        }
    }
}