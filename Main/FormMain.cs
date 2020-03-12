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
        private readonly FormMainModel model = new FormMainModel();

        // Sub forms

        private readonly SubMainProject subProject = null;
        private readonly SubMainChartOptions subChartOptions = null;

        NameOptions namesType = NameOptions.Well;
        string selectedPad = "(All)";

        private readonly ChartController chartController = new ChartController();
        public FormMain()
        {
            InitializeComponent();

            chartController.LoadSettings();

            boxSetChartCount.SelectedIndex = 0;
            boxNamesType.SelectedIndex = 2;

            subProject = new SubMainProject(model.GetProjectManager());
            subProject.UpdateData += new EventHandler(OnSubProjectUpdate);

            subChartOptions = new SubMainChartOptions(chartController);
            subChartOptions.UpdateData += new EventHandler(OnSubChartOptionsUpdate);
            //
        }
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
                {
                    if (selectedPad == "(All)")
                    {
                        listNames.Items.AddRange(value);
                    }
                    else
                    {
                        var selected_wells_in_pad = model.GetNamesFromVGroup(selectedPad);
                        List<string> filtered_wellnames = new List<string>();

                        for (int iw = 0; iw < selected_wells_in_pad.Length; ++iw)
                        {
                            if (Array.IndexOf(value, selected_wells_in_pad[iw]) != -1)
                            {
                                filtered_wellnames.Add(selected_wells_in_pad[iw]);
                            }
                        }

                        listNames.Items.AddRange(filtered_wellnames.ToArray());
                    }
                }

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

        private void openModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.OpenNewModel();

            if (model.GetActiveProject() == null) return;

            UpdateData();
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


        void UpdateData()
        {
            if (model.GetActiveProject() == null)
            {
                buttonModels.Text = @"\\\";

                foreach (Chart item in tableLayoutPanel1.Controls)
                {
                    item.SetEclipseProject(model.GetProjectManager());
                }


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

        private void FormMainOnFormClosed(object sender, FormClosedEventArgs e)
        {
            chartController.SaveSettings();
        }


        private void OnSubChartOptionsUpdate(object sender, EventArgs e)
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


        private void button2_Click(object sender, EventArgs e)
        {
            model.GetProjectManager().DeleteActiveProject();
            UpdateData();
        }

        private void virtualGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.ShowVirtualGroups();

        }

        private void crossPlotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.ShowCrossPlots();
        }

        private void dViewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            model.Show2DView();
        }

        private void bbWellFilter_Click(object sender, EventArgs e)
        {
            panelNameFilter.Visible = !panelNameFilter.Visible;

            listGroups.Items.Clear();
            listGroups.Items.Add("(All)");
            listGroups.Items.AddRange(model.GetVirtualGroups()??new string[] { });
        }

        private void listGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGroups.SelectedIndex == -1) return;

            selectedPad = listGroups.SelectedItem.ToString();

            if (selectedPad == "(All)")
            {
                bbWellFilter.ForeColor = Color.Black;
            }
            else
            {
                bbWellFilter.ForeColor = Color.Red;
            }

            UpdateData();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            subProject.UpdateSubForm();
            subProject.Show();
        }

        private void OnSubProjectUpdate(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form2D [OnSubFormOptions]");
            UpdateData();
        }

        private void boxNewName_TextChanged(object sender, EventArgs e)
        {

        }

        // События
        private void buttonModelsOnClick(object sender, EventArgs e)
        {
                subProject.UpdateSubForm();
                subProject.Focus();
                subProject.Show();
        }
        private void buttonChartOptionsOnClick(object sender, EventArgs e)
        {
            subChartOptions.Left = buttonChartOptions.PointToScreen(Point.Empty).X;
            subChartOptions.Top = buttonChartOptions.PointToScreen(Point.Empty).Y;
            subChartOptions.Keywords = model.GetAllKeywords().OrderBy(c => c).ToArray();
            subChartOptions.Focus();
            subChartOptions.Show();
        }
        private void buttonUpdateOnClick(object sender, EventArgs e)
        {
            model.UpdateActiveProject();
            UpdateData();
        }
    }
}