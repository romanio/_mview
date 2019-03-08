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

                if (listBoxKeywords.Items.Count > 0)
                    listBoxKeywords.SelectedIndex = 0;
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
            boxMarkerStyle.Items.Remove("Custom");

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

        private void buttonApplySeries_Click(object sender, EventArgs e)
        {
            var seriesStyle = new SeriesStyle()
            {
                Name = listBoxKeywords.SelectedItem.ToString(),
                LineStyle = (OxyPlot.LineStyle)Enum.Parse(typeof(OxyPlot.LineStyle), boxLineStyle.Text, true),
                LineWidth = Convert.ToInt32(numericLineWidth.Value),
                LineSmooth = checkSmooth.Checked,
                MarkerType = (OxyPlot.MarkerType)Enum.Parse(typeof(OxyPlot.MarkerType), boxMarkerStyle.Text, true),
                MarkerSize = Convert.ToInt32(numericMarkerSize.Value),
            };

            if (buttonLineColor.Text != "(default)")
            {
                seriesStyle.LineColor = buttonLineColor.BackColor;
            }

            if (buttonMarkerBorderColor.Text != "(default)")
            {
                seriesStyle.MarkerColor = buttonMarkerBorderColor.BackColor;
            }

            if (buttonMarkerFill.Text != "(default)")
            {
                seriesStyle.MarkerFillColor = buttonMarkerFill.BackColor;
            }

            chartController.UpdateStyle(seriesStyle);

            ApplyStyle();
        }

        private void listBoxKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxKeywords.SelectedIndex == -1) return;

            int index = chartController.GetIndex(listBoxKeywords.SelectedItem.ToString());

            if (index == -1) // Default style
            {
                boxLineStyle.SelectedIndex = boxLineStyle.FindString("Solid");
                buttonLineColorDefault_Click(null, null);

                numericLineWidth.Value = 1;
                checkSmooth.Checked = false;
                boxMarkerStyle.SelectedIndex = boxMarkerStyle.FindString("Circle");
                numericMarkerSize.Value = 5;
                buttonMarkerBorderDefault_Click(null, null);
                buttonMarkerFillDefault_Click(null, null);
            }
            else
            {
                var tmp = chartController.GetStyle(index);

                boxLineStyle.SelectedIndex = boxLineStyle.FindString(tmp.LineStyle.ToString());
                //
                if (tmp.LineColor.Name == "0")
                {
                    buttonLineColorDefault_Click(null, null);
                }
                else
                {
                    buttonLineColor.BackColor = tmp.LineColor;
                    buttonLineColor.Text = "";
                }
                //
                if (tmp.MarkerColor.Name == "0")
                {
                    buttonMarkerBorderDefault_Click(null, null);
                }
                else
                {
                    buttonMarkerBorderColor.BackColor = tmp.MarkerColor;
                    buttonMarkerBorderColor.Text = "";
                }
                //
                if (tmp.MarkerFillColor.Name == "0")
                {
                    buttonMarkerFillDefault_Click(null, null);
                }
                else
                {
                    buttonMarkerFill.BackColor = tmp.MarkerFillColor;
                    buttonMarkerFill.Text = "";
                }
                //
                numericMarkerSize.Value = tmp.MarkerSize;
                numericLineWidth.Value = tmp.LineWidth;
                checkSmooth.Checked = tmp.LineSmooth;
                boxMarkerStyle.SelectedIndex = boxMarkerStyle.FindString(tmp.MarkerType.ToString());
            }
        }

        private void buttonLineColorDefault_Click(object sender, EventArgs e)
        {
            buttonLineColor.Text = "(default)";
            buttonLineColor.BackColor = SystemColors.Control;
            buttonLineColor.UseVisualStyleBackColor = true;
        }

        private void buttonMarkerBorderDefault_Click(object sender, EventArgs e)
        {
            buttonMarkerBorderColor.Text = "(default)";
            buttonMarkerBorderColor.BackColor = SystemColors.Control;
            buttonMarkerBorderColor.UseVisualStyleBackColor = true;
        }

        private void buttonMarkerFillDefault_Click(object sender, EventArgs e)
        {
            buttonMarkerFill.Text = "(default)";
            buttonMarkerFill.BackColor = SystemColors.Control;
            buttonMarkerFill.UseVisualStyleBackColor = true;
        }
    }
}
