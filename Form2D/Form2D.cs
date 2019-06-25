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

        public Form2D(EclipseProject ecl)
        {
            InitializeComponent();
            model = new Form2DModel(ecl);
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

            boxZSlice.Items.Clear();
            boxZSlice.BeginUpdate();

            for (int it = 0; it < model.GetNZ(); ++it)
                boxZSlice.Items.Add((it + 1).ToString());

            if (boxRestart.Items.Count > 0)
                boxRestart.SelectedIndex = 0;

            boxZSlice.SelectedIndex = 0;
            boxZSlice.EndUpdate();
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

        private void boxZSliceOnSelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetZA(boxZSlice.SelectedIndex);
            treeProperties_AfterSelect(null, null);
        }

        private void buttonChartOptions_Click(object sender, EventArgs e)
        {
            Form2DOptions tmp = new Form2DOptions(model.style);
            tmp.ApplyStyle += OnApplyStyle;
            tmp.Show();
        }

        private void OnApplyStyle()
        {
            System.Diagnostics.Debug.WriteLine("2D Options : ApplyStyle");
            model.ApplyStyle();
            glControlOnPaint(null, null);
        }


    }
}
