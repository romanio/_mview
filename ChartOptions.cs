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
    public delegate void UpdateDataDelegate();

    public partial class ChartOptions : Form
    {
        public event UpdateDataDelegate ApplyStyle;

        public string[] Keywords
        {
            set
            {
                boxAxisXMode.Items.Clear();
                boxAxisXMode.Items.Add("TIME");
                boxAxisXMode.Items.AddRange(value);

                int index = boxAxisXMode.Items.IndexOf(chartController.AxisX);
                if (index != -1) boxAxisXMode.SelectedIndex = index;

                index = boxAxisYMode.Items.IndexOf(chartController.AxisY);
                if (index != -1) boxAxisYMode.SelectedIndex = index;

                listBoxKeywords.Items.Clear();
                listBoxKeywords.Items.AddRange(value);
                
            }
        }

        ChartController chartController;

        public ChartOptions(ChartController chartController)
        {
            InitializeComponent();
            this.chartController = chartController;

            boxLineStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));
            boxLineStyle.SelectedIndex = 0;

            boxMarkerStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.MarkerType)));
            boxMarkerStyle.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ApplyStyle();
            Close();
        }

        private void boxKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartController.AxisX = boxAxisXMode.SelectedItem.ToString();
            ApplyStyle();
        }

        private void ChartOptions_Deactivate(object sender, EventArgs e)
        {
            if (IsColorDialog)
            {

            }
            else
            {
                ApplyStyle();
                Close();
            }
        }

        private void boxAxisYMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartController.AxisY = boxAxisYMode.SelectedItem.ToString();
            ApplyStyle();
        }

        bool IsColorDialog = false;

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            IsColorDialog = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonLineColor.BackColor = colorDialog.Color;
                buttonLineColor.Text = "";
                IsColorDialog = false;
            }
        }

        private void buttonMarkerBorderColor_Click(object sender, EventArgs e)
        {
            IsColorDialog = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonMarkerBorderColor.BackColor = colorDialog.Color;
                buttonMarkerBorderColor.Text = "";
                IsColorDialog = false;
            }
        }

        private void buttonMarkerFill_Click(object sender, EventArgs e)
        {
            IsColorDialog = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonMarkerFill.BackColor = colorDialog.Color;
                buttonMarkerFill.Text = "";
                IsColorDialog = false;
            }
        }
    }
}
