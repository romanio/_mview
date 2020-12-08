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
    public partial class SubGraphicFilter : Form
    {
        public event EventHandler UpdateData;
        public SubGraphicFilter()
        {
            InitializeComponent();
        }

        public void SetData(int NX, int NY, int NZ)
        {
            // Размерность по X, Y, Z

            var xSize = new List<object> { };

            for (int it = 0; it < NX; ++it)
                xSize.Add((it + 1).ToString());

            var ySize = new List<object> { };

            for (int it = 0; it < NY; ++it)
                ySize.Add((it + 1).ToString());

            var zSize = new List<object> {};

            for (int it = 0; it < NZ; ++it)
                zSize.Add((it + 1).ToString());

            
            comboSliceX.Items.Clear();
            comboSliceX.Items.AddRange(xSize.ToArray());

            comboSliceY.Items.Clear();
            comboSliceY.Items.AddRange(ySize.ToArray());

            comboSliceZ.Items.Clear();
            comboSliceZ.Items.AddRange(zSize.ToArray());
        }

        public GraphicFilterData GetData()
        {
            return new GraphicFilterData
            {
                UseIndexFilter = checkboxUseIndexFilter.Checked,
                IndexX = radioButtonUseX.Checked ? comboSliceX.SelectedIndex : -1,
                IndexY = radioButtonUseY.Checked ? comboSliceY.SelectedIndex : -1,
                IndexZ = radioButtonUseZ.Checked ? comboSliceZ.SelectedIndex : -1
            };
        }

        private void SubGraphicFilterOnFormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void CheckBoxUseIndexFilterOnCheckedChanged(object sender, EventArgs e)
        {
            var state = checkboxUseIndexFilter.Checked;
            
            radioButtonUseX.Enabled = state;
            radioButtonUseY.Enabled = state;
            radioButtonUseZ.Enabled = state;

            comboSliceX.Enabled = state;
            comboSliceY.Enabled = state;
            comboSliceZ.Enabled = state;

            UpdateData(sender, e);
        }

        private void ComboSliceXOnSelectedIndexChanged(object sender, EventArgs e)
        {
            radioButtonUseX.Checked = true;
            UpdateData(sender, e);
        }

        private void ComboSliceYOnSelectedIndexChanged(object sender, EventArgs e)
        {
            radioButtonUseY.Checked = true;
            UpdateData(sender, e);
        }

        private void ComboSliceZOnSelectedIndexChanged(object sender, EventArgs e)
        {
            radioButtonUseZ.Checked = true;
            UpdateData(sender, e);
        }

        private void RadioButtonUseXOnCheckedChanged(object sender, EventArgs e)
        {
            UpdateData(sender, e);
        }

        private void RadioButtonUseYOnCheckedChanged(object sender, EventArgs e)
        {
            UpdateData(sender, e);
        }

        private void RadioButtonUseZOnCheckedChanged(object sender, EventArgs e)
        {
            UpdateData(sender, e);
        }
    }
}
