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

                // Восстановим выделенные слова
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

            boxSetChartCount.SelectedIndex = 0;
            boxNamesType.SelectedIndex = 2;
        }

        private void openModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.OpenNewModel();

            if (model.GetActiveProject() == null) return;

            // Update data

            boxNamesType_SelectedIndexChanged(null, null);

            foreach (Chart item in tableLayoutPanel1.Controls)
            {
                item.SetEclipseProject(model.GetActiveProject());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            model.ShowDetailForm();
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
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetActiveProject()) { Dock = DockStyle.Fill });

                    break;
                case 1:
                    tableLayoutPanel1.RowCount = 1;
                    tableLayoutPanel1.ColumnCount = 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetActiveProject()) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetActiveProject()) { Dock = DockStyle.Fill });
                    break;
                case 2:
                    tableLayoutPanel1.RowCount = 2;
                    tableLayoutPanel1.ColumnCount = 2;
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

                    tableLayoutPanel1.Controls.Add(new Chart(model.GetActiveProject()) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetActiveProject()) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetActiveProject()) { Dock = DockStyle.Fill });
                    tableLayoutPanel1.Controls.Add(new Chart(model.GetActiveProject()) { Dock = DockStyle.Fill });

                    break;
                case 3:
                    break;
            }
        }

        private void listNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("LIST NAMES");

            foreach (Chart item in tableLayoutPanel1.Controls)
            {
                item.UpdateSelectedName(listNames.SelectedItem.ToString());
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
            System.Diagnostics.Debug.WriteLine("CHECKED SORTED");

            if (model.GetActiveProject() == null) return;

            Names = model.GetNamesByType(namesType);
        }
    }
}