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
    public partial class Form2D : Form
    {
        Form2DModel model = null;

        UCSetFocusOn ucSetFocusOn = null;
        UСOptions ucOptions = null;

        public Form2D(EclipseProject ecl)
        {
            InitializeComponent();
            model = new Form2DModel(ecl);

            // 
            ucSetFocusOn = new UCSetFocusOn();
            this.Controls.Add(ucSetFocusOn);
            ucSetFocusOn.BringToFront();
            ucSetFocusOn.Location = new Point(bbSetFocusOn.Location.X, bbSetFocusOn.Location.Y + bbSetFocusOn.Height + 8);

            ucSetFocusOn.Visible = false;
            ucSetFocusOn.SelectedIndexChanged += new EventHandler(this.OnUCWellsSelected);

            //
            ucOptions = new UСOptions(model.style);

            this.Controls.Add(ucOptions);
            ucOptions.BringToFront();
            ucOptions.Location = new Point(bbChartOptions.Location.X, bbChartOptions.Location.Y + bbChartOptions.Height + 8);

            ucOptions.Visible = false;
            ucOptions.ApplyStyle += new EventHandler(this.OnUCApplyStyle);

        }

        private void OnUCApplyStyle(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("2D Options : ApplyStyle");
            model.ApplyStyle();
            glControlOnPaint(null, null);
        }

        private void OnUCWellsSelected(object sender, EventArgs e)
        {
            model.SetFocusOnWell(((ListBox)sender).SelectedItem.ToString());
            glControl.SwapBuffers();
        }

        void FillStaticProperties()
        {
            // Имена свойств из INIT файла

            treeProperties.Nodes[0].Nodes.Clear();
            treeProperties.Nodes[1].Nodes.Clear();

            var static_properties = model.GetStaticProperties();
            var dynamic_properties = model.GetAllDinamicProperties();

            treeProperties.BeginUpdate();
            foreach (string item in static_properties)
            {
                treeProperties.Nodes[0].Nodes.Add(item);
            }
            foreach (string item in dynamic_properties)
            {
                treeProperties.Nodes[1].Nodes.Add(item);
            }
            treeProperties.EndUpdate();

            // Список из всех доступных рестартов

            boxRestart.Items.Clear();

            boxRestart.BeginUpdate();
            boxRestart.Items.AddRange(model.GetRestartDates());

            boxRestart.EndUpdate();

            // Размерность по X, Y, Z

            boxXSlice.Items.Clear();
            boxXSlice.BeginUpdate();

            for (int it = 0; it < model.GetNX(); ++it)
                boxXSlice.Items.Add((it + 1).ToString());

            boxXSlice.SelectedIndex = 0;
            boxXSlice.EndUpdate();

            //

            boxYSlice.Items.Clear();
            boxYSlice.BeginUpdate();

            for (int it = 0; it < model.GetNY(); ++it)
                boxYSlice.Items.Add((it + 1).ToString());

            boxYSlice.SelectedIndex = 0;
            boxYSlice.EndUpdate();

            //

            boxZSlice.Items.Clear();
            boxZSlice.BeginUpdate();

            for (int it = 0; it < model.GetNZ(); ++it)
                boxZSlice.Items.Add((it + 1).ToString());

            if (boxRestart.Items.Count > 0)
                boxRestart.SelectedIndex = 0;

            boxZSlice.SelectedIndex = 0;
            boxZSlice.EndUpdate();
            
            //
        }

        private void boxRestart_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.ReadRestart(boxRestart.SelectedIndex);
            treeProperties_AfterSelect(null, null);
        }

        private void treeProperties_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeProperties.SelectedNode?.Parent?.Index == 0)
            {
                model.SetStaticProperty(treeProperties.SelectedNode.Text);
                glControlOnPaint(null, null);

            }

            if (treeProperties.SelectedNode?.Parent?.Index == 1)
            {
                model.SetDynamicProperty(treeProperties.SelectedNode.Text);
                glControlOnPaint(null, null);
            }
        }

        // Всё что касается OpenGL

        private void glControlOnLoad(object sender, EventArgs e)
        {
            model.OnLoad();
            FillStaticProperties();
            glControl.MouseWheel += new MouseEventHandler(glControlOnMouseWheel);
        }

        private void glControlOnMouseWheel(object sender, MouseEventArgs e)
        {
            model.MouseWheel(e);
            glControlOnPaint(null, null);
        }

        private void glControlOnPaint(object sender, PaintEventArgs e)
        {
            model.OnPaint();
            glControl.SwapBuffers();
        }

        private void glControlOnMouseMove(object sender, MouseEventArgs e)
        {
            model.MouseMove(e);
            glControlOnPaint(null, null);
        }

        private void glControlOnMouseClick(object sender, MouseEventArgs e)
        {
            model.MouseClick(e);
            glControlOnPaint(null, null);

            var res = model.GetXYZVSelected();

            lbCellValue.Text = String.Format("Cell [{0}, {1}, {2}] = {3}, {4}", res.Item1 + 1, res.Item2 + 1, res.Item3 + 1, res.Item4, model.GetGridUnit());
        }

        private void glControlOnResize(object sender, EventArgs e)
        {
            model.OnResize(glControl.Width, glControl.Height);
            glControl.SwapBuffers();
        }

        private void Form2DOnFormClosed(object sender, FormClosedEventArgs e)
        {
            model.OnUnload();
        }

        private void boxXSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BOX X SELECTED INDEX");

            model.SetXA(boxXSlice.SelectedIndex);
            treeProperties_AfterSelect(null, null);
        }

        private void boxYSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetYA(boxYSlice.SelectedIndex);
            treeProperties_AfterSelect(null, null);
        }

        private void boxZSliceOnSelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetZA(boxZSlice.SelectedIndex);
            treeProperties_AfterSelect(null, null);
        }

        private void buttonChartOptions_Click(object sender, EventArgs e)
        {
            ucOptions.Visible = !ucOptions.Visible;

            if (ucOptions.Visible)
            {
                // Восстановление настроек

                ucOptions.checkShowGridLines.Checked = model.style.ShowGridLines;
                ucOptions.checkShowBubbles.Checked = model.style.ShowBubbles;
                ucOptions.boxBubbleMode.SelectedIndex = 0;
                ucOptions.numericScaleFactor.Value = (decimal)model.style.scale_factor;

                ucOptions.boxMinimum.Text = model.style.min_value.ToString();
                ucOptions.boxMaximum.Text = model.style.max_value.ToString();

                switch (model.style.BubbleMode)
                {
                    case BubbleMode.Simulation:
                        ucOptions.boxBubbleMode.SelectedIndex = 0;
                        break;
                    case BubbleMode.Historical:
                        ucOptions.boxBubbleMode.SelectedIndex = 1;
                        break;

                    default:
                        break;
                }
            }
        }

        private void OnApplyStyle()
        {

        }



        private void bbSetFocusOn_Click(object sender, EventArgs e)
        {
            ucSetFocusOn.Visible = !ucSetFocusOn.Visible;

            if (ucSetFocusOn.Visible)
            {
                ucSetFocusOn.listWells.Items.Clear();
                ucSetFocusOn.listWells.Items.AddRange(model.GetWellNames());
            }
        }

        private void tabSliceControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSliceControl.SelectedIndex == 0)
            {
                model.SetPosition(ViewMode.X);
                glControlOnPaint(null, null);
            }

            if (tabSliceControl.SelectedIndex == 1)
            {
                model.SetPosition(ViewMode.Y);
                glControlOnPaint(null, null);
            }

            if (tabSliceControl.SelectedIndex == 2)
            {
                model.SetPosition(ViewMode.Z);
                glControlOnPaint(null, null);
            }
        }
    }
}
