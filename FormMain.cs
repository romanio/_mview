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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        int row_count = 1;
        int col_count = 1;
        int item_count = 1;


        private void button14_Click(object sender, EventArgs e)
        {
            OxyPlot.WindowsForms.PlotView view = new OxyPlot.WindowsForms.PlotView();
            view.Dock = DockStyle.Fill;
 
            var pm = new OxyPlot.PlotModel
            {
                Title = "Example #1",
                Subtitle = "oil cummulative ",
                PlotType = OxyPlot.PlotType.Cartesian
            };

            //pm.Series.Add(new Fun)
            pm.Series.Add(new OxyPlot.Series.LineSeries { Title = "Oil" });

            view.Model = pm;

            tableLayoutPanel1.Controls.Add(view);
        }
    }
}
