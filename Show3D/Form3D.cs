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
    public partial class Form3D : Form
    {
        private Form3DModel model = null;
        private EclipseProject ecl = null;

        public Form3D(EclipseProject ecl)
        {
            InitializeComponent();
            this.ecl = ecl;
        }

        bool editVisualData = false;
        void UpdateVisual()
        {
            editVisualData = true;

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

            boxXSlice.Items.Add("(all)");

            for (int it = 0; it < model.GetNX(); ++it)
                boxXSlice.Items.Add((it + 1).ToString());

            boxXSlice.SelectedIndex = 0;
            boxXSlice.EndUpdate();

            //

            boxYSlice.Items.Clear();
            boxYSlice.BeginUpdate();

            boxYSlice.Items.Add("(all)");

            for (int it = 0; it < model.GetNY(); ++it)
                boxYSlice.Items.Add((it + 1).ToString());

            boxYSlice.SelectedIndex = 0;
            boxYSlice.EndUpdate();

            //

            boxZSlice.Items.Clear();
            boxZSlice.BeginUpdate();

            boxZSlice.Items.Add("(all)");

            for (int it = 0; it < model.GetNZ(); ++it)
                boxZSlice.Items.Add((it + 1).ToString());

            if (boxRestart.Items.Count > 0)
                boxRestart.SelectedIndex = 0;

            boxZSlice.SelectedIndex = 0;
            boxZSlice.EndUpdate();

            //

            editVisualData = false;

            //tabSliceControl_SelectedIndexChanged(null, null);
        }

        // Всё что касается OpenGL

        private void glControlOnLoad(object sender, EventArgs e)

        {
            model = new Form3DModel(ecl);

            UpdateVisual();

            model.OnLoad();

            glControlOnResize(null, null);
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

        //    var res = model.GetXYZVSelected();
         //   lbCellValue.Text = String.Format("Cell [{0}, {1}, {2}] = {3}, {4}", res.Item1 + 1, res.Item2 + 1, res.Item3 + 1, res.Item4, model.GetGridUnit());
        }

        private void glControlOnResize(object sender, EventArgs e)
        {
            if (model == null) return;

            model.OnResize(glControl.Width, glControl.Height);
            glControl.SwapBuffers();
        }

        private void boxZSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editVisualData) return;

            model.SetZA(boxZSlice.SelectedIndex - 1);
            glControlOnPaint(null, null);
        }

        private void boxXSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editVisualData) return;

            model.SetXA(boxXSlice.SelectedIndex - 1);
            glControlOnPaint(null, null);
        }

        private void boxYSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editVisualData) return;

            model.SetYA(boxYSlice.SelectedIndex - 1);
            glControlOnPaint(null, null);
        }

        private void treeProperties_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Статические свойства

            if (treeProperties.SelectedNode?.Parent?.Index == 0)
            {
                string name = treeProperties.SelectedNode.Text;
                model.SetStaticProperty(name);

                /*
                subOptions.UpdateMode = true;
                subOptions.PropertyMaxValue = model.GetPropertyMaxValue();
                subOptions.PropertyMinValue = model.GetPropertyMinValue();
                subOptions.PropertyStatistic = model.GetPropertyStatistic();
                subOptions.PropertName = name;
                subOptions.UpdateMode = false;

                model.ApplyStyleData();
                */

                model.GenerateStaticGrid();

                glControlOnPaint(null, null);
            }

            // Динамические свойства

            if (treeProperties.SelectedNode?.Parent?.Index == 1)
            {
                string name = treeProperties.SelectedNode.Text;
                model.SetDynamicProperty(name);

                /*
                subOptions.UpdateMode = true;
                subOptions.PropertyMaxValue = model.GetPropertyMaxValue();
                subOptions.PropertyMinValue = model.GetPropertyMinValue();
                subOptions.PropertyStatistic = model.GetPropertyStatistic();
                subOptions.PropertName = name;
                subOptions.UpdateMode = false;

                model.ApplyStyleData();
                */
                model.GenerateRestartGrid();


                glControlOnPaint(null, null);
            }
        }

        private void boxRestart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editVisualData) return;

            System.Diagnostics.Debug.WriteLine("Form2D [BoxRestart SelectedIndexChanged]");

            model.ReadRestart(boxRestart.SelectedIndex);

            treeProperties_AfterSelect(null, null);
        }
    }
}
