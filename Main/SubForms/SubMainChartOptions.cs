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

    public partial class SubMainChartOptions : Form
    {
        public event EventHandler UpdateData;

        public string[] Keywords
        {
            set
            {
                listKeywords.Items.Clear();
                listKeywords.Items.AddRange(value);

                if (listKeywords.Items.Count > 0)
                    listKeywords.SelectedIndex = 0;
            }
        }

        ChartController chartController;

        public SubMainChartOptions(ChartController chartController)
        {
            InitializeComponent();
            this.chartController = chartController;

            boxLineStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));
            boxLineStyle.SelectedIndex = 0;

            boxMarkerStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.MarkerType)));
            boxMarkerStyle.Items.Remove("Custom");
            boxMarkerStyle.SelectedIndex = 0;

            boxGroupMode.Items.AddRange(Enum.GetNames(typeof(GroupMode)));
            boxGroupMode.SelectedIndex = 0;

            //
            boxAxisXStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));
            boxAxisXStyle.SelectedIndex = boxAxisXStyle.FindString(chartController.AxisXStyle.ToString());

            numericAxisXWidth.Value = chartController.AxisXWidth;
            numericAxisYWidth.Value = chartController.AxisYWidth;

            boxAxisYStyle.Items.AddRange(Enum.GetNames(typeof(OxyPlot.LineStyle)));
            boxAxisYStyle.SelectedIndex = boxAxisYStyle.FindString(chartController.AxisYStyle.ToString());

            boxLegendPosition.Items.AddRange(Enum.GetNames(typeof(OxyPlot.Legends.LegendPosition)));
            boxLegendPosition.SelectedIndex = boxLegendPosition.FindString(chartController.LegendPosition.ToString());

            //
            if (chartController.AxisXColor.Name == "0")
            {
                buttonAxisXColorDefault_Click(null, null);
            }
            else
            {
                buttonAxisXColor.BackColor = chartController.AxisXColor;
                buttonAxisXColor.Text = "";
            }

            if (chartController.AxisYColor.Name == "0")
            {
                buttonAxisYColorDefault_Click(null, null);
            }
            else
            {
                buttonAxisYColor.BackColor = chartController.AxisYColor;
                buttonAxisYColor.Text = "";
            }
            //
        }


        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData(sender, e);
            Close();
        }

        private void buttonLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonLineColor.BackColor = colorDialog.Color;
                buttonLineColor.Text = "";
            }
        }

        private void buttonMarkerBorderColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonMarkerBorderColor.BackColor = colorDialog.Color;
                buttonMarkerBorderColor.Text = "";
            }
        }

        private void buttonMarkerFill_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonMarkerFill.BackColor = colorDialog.Color;
                buttonMarkerFill.Text = "";
            }
        }

        private void buttonApplySeries_Click(object sender, EventArgs e)
        {
            chartController.LegendPosition = (OxyPlot.Legends.LegendPosition)Enum.Parse(typeof(OxyPlot.Legends.LegendPosition), boxLegendPosition.Text, true);

            chartController.AxisXStyle = (OxyPlot.LineStyle)Enum.Parse(typeof(OxyPlot.LineStyle), boxAxisXStyle.Text, true);
            chartController.AxisXWidth = Convert.ToInt32(numericAxisXWidth.Value);
            chartController.AxisYStyle = (OxyPlot.LineStyle)Enum.Parse(typeof(OxyPlot.LineStyle), boxAxisYStyle.Text, true);
            chartController.AxisYWidth = Convert.ToInt32(numericAxisXWidth.Value);
            
            if (buttonAxisXColor.Text != "(default)")
            {
                chartController.AxisXColor = buttonAxisXColor.BackColor;
            }
            else
            {
                chartController.AxisXColor = Color.FromName("0");
            }

            if (buttonAxisYColor.Text != "(default)")
            {
                chartController.AxisYColor = buttonAxisYColor.BackColor;
            }
            else
            {
                chartController.AxisYColor = Color.FromName("0");
            }

            var seriesStyle = new SeriesStyle()
            {
                Name = listKeywords.SelectedItem.ToString(),
                LineStyle = (OxyPlot.LineStyle)Enum.Parse(typeof(OxyPlot.LineStyle), boxLineStyle.Text, true),
                LineWidth = Convert.ToInt32(numericLineWidth.Value),
                LineSmooth = checkSmooth.Checked,
                MarkerType = (OxyPlot.MarkerType)Enum.Parse(typeof(OxyPlot.MarkerType), boxMarkerStyle.Text, true),
                MarkerSize = Convert.ToInt32(numericMarkerSize.Value),
                GroupMode = (GroupMode)Enum.Parse(typeof(GroupMode), boxGroupMode.Text, true)
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

            UpdateData(sender, e);
        }

        private void listKeywordsOnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listKeywords.SelectedIndex == -1) return;

            int index = chartController.GetIndex(listKeywords.SelectedItem.ToString());

            if (index == -1) // Default style
            {
                boxLineStyle.SelectedIndex = boxLineStyle.FindString("Solid");
                buttonLineColorDefault_Click(null, null);

                numericLineWidth.Value = 1;
                checkSmooth.Checked = false;
                boxMarkerStyle.SelectedIndex = boxMarkerStyle.FindString("Circle");
                numericMarkerSize.Value = 5;
                boxGroupMode.SelectedIndex = boxGroupMode.FindString("Normal");

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
                boxGroupMode.SelectedIndex = boxGroupMode.FindString(tmp.GroupMode.ToString());
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

        private void buttonAxisXColorDefault_Click(object sender, EventArgs e)
        {
            buttonAxisXColor.Text = "(default)";
            buttonAxisXColor.BackColor = SystemColors.Control;
            buttonAxisXColor.UseVisualStyleBackColor = true;
        }

        private void buttonAxisYColorDefault_Click(object sender, EventArgs e)
        {
            buttonAxisYColor.Text = "(default)";
            buttonAxisYColor.BackColor = SystemColors.Control;
            buttonAxisYColor.UseVisualStyleBackColor = true;
        }

        private void buttonAxisXColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonAxisXColor.BackColor = colorDialog.Color;
                buttonAxisXColor.Text = "";
            }
        }

        private void buttonAxisYColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonAxisYColor.BackColor = colorDialog.Color;
                buttonAxisYColor.Text = "";
            }
        }

        private void SubMainChartOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
