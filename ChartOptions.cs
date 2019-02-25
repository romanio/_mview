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
    public delegate void ApplyStyleDelegate();

    public partial class ChartOptions : Form
    {
        public event ApplyStyleDelegate ApplyStyle;

        public string[] Keywords
        {
            set
            {
                boxKeywords.Items.Clear();
                boxKeywords.Items.Add("TIME");
                boxKeywords.Items.AddRange(value);
                boxKeywords.SelectedIndex = 0;
            }
        }

        ChartController chartController;
        public ChartOptions(ChartController chartController)
        {
            InitializeComponent();

            this.chartController = chartController;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void boxKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartController.AxisX = boxKeywords.SelectedItem.ToString();
            ApplyStyle();
        }
    }
}
