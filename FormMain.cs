﻿using System;
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

        // Свойства управляемые из модели

        bool edit_mode_names = false;


        public string[] Names
        {
            set
            {
                edit_mode_names = true;

                listNames.Items.Clear();
                if (value != null)
                    listNames.Items.AddRange(value);

                edit_mode_names = false;
            }
        }

        public FormMain()
        {
            InitializeComponent();
        }

        private void openModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            model.OpenNewModel();
            // Update data
            Names = model.GetNamesByType(NameOptions.Well);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            model.ShowDetailForm();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = comboBox1.SelectedIndex.ToString();

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            switch (comboBox1.SelectedIndex)
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
            foreach(Chart item in tableLayoutPanel1.Controls)
            {
                item.UpdateSelectedName(listNames.SelectedItem.ToString());
            }


        }
    }
}