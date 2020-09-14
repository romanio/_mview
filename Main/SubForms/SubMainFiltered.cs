using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace mview
{
    public partial class SubMainFiltered : Form
    {
        public event EventHandler UpdateData;

        public SubMainFiltered(Form2DModelStyle Style)
        {
            InitializeComponent();

        }

        private void SubFormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void listWells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGroups.SelectedItem == null) return;
            if (listGroups.SelectedIndex == -1) return;
           
            UpdateData(sender, e);
        }
    }
}
