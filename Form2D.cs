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

            FillStaticProperties();
        }

        void FillStaticProperties()
        {
            // Имена свойств из INIT файла

            treeProperties.Nodes[0].Nodes.Clear();

            var static_properties = model.GetStaticProperties();

            treeProperties.BeginUpdate();

            foreach (string item in static_properties)
            {
                treeProperties.Nodes[0].Nodes.Add(item);
            }

            treeProperties.EndUpdate();

            //

            boxRestart.Items.Clear();

            boxRestart.BeginUpdate();
            boxRestart.Items.AddRange(model.GetRestartDates());

            boxRestart.EndUpdate();

            if (boxRestart.Items.Count > 0)
                boxRestart.SelectedIndex = 0;

            boxZSlice.Items.Clear();
            boxZSlice.BeginUpdate();

            for (int it = 0; it < model.GetNZ(); ++it)
                boxZSlice.Items.Add((it + 1).ToString());

         //   boxZSlice.SelectedIndex = 0;
            boxZSlice.EndUpdate();

            tabSliceControlOnSelectedIndexChanged(null, null);

        }

        private void boxRestart_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.ReadRestart(boxRestart.SelectedIndex);

            // Рестарт файл может содержать разное количество динамических свойств, поэтому приходится
            // обновлять список доступных, каждый раз при чтении другого рестарт-файла
            // При перелистывании рестартов, удобно сохранять выбранное свойство

            string selected_propery = null;

            foreach(TreeNode node in treeProperties.Nodes[1].Nodes) // Найдем, кто же выбран
            {
                if (node.IsSelected) selected_propery = node.Text;
            }

            treeProperties.Nodes[1].Nodes.Clear();

            var dynamic_properties = model.GetDinamicProperties(boxRestart.SelectedIndex);

            treeProperties.BeginUpdate();
            foreach (string item in dynamic_properties) // И вернем ктоже был выбран
            {
                treeProperties.Nodes[1].Nodes.Add(item);

                if (item == selected_propery)
                {
                    treeProperties.SelectedNode = treeProperties.Nodes[1].LastNode;

                    model.SetDynamicProperty(selected_propery);
                    glControlOnPaint(null, null);
                }
            }
            treeProperties.EndUpdate();
        }

        private void treeProperties_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeProperties.SelectedNode?.Parent?.Index == 0)
            {
                model.SetStaticProperty(e.Node.Text);
                glControlOnPaint(null, null);

            }

            if (treeProperties.SelectedNode?.Parent?.Index == 1)
            {
                model.SetDynamicProperty(e.Node.Text);
                glControlOnPaint(null, null);
            }
        }

        // Всё что касается OpenGL

        private void glControlOnLoad(object sender, EventArgs e)
        {
            model.OnLoad();
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

        private void glControlOnResize(object sender, EventArgs e)
        {
            model.OnResize(glControl.Width, glControl.Height);
            glControl.SwapBuffers();
        }

        private void Form2DOnFormClosed(object sender, FormClosedEventArgs e)
        {
            model.OnUnload();
        }

        private void checkShowGridLinesOnCheckedChanged(object sender, EventArgs e)
        {
            model.SetGridlineStatus(checkShowGridLines.Checked);
            glControl.SwapBuffers();
        }

        private void boxZSliceOnSelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetZA(boxZSlice.SelectedIndex);
            glControlOnPaint(null, null);
        }

        private void tabSliceControlOnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boxMinimumOnValidating(object sender, CancelEventArgs e)
        {
            float value;
            if (float.TryParse(boxMinimum.Text, out value))
            {
                model.SetMinValue(value);
                glControlOnPaint(null, null);
            }
        }

        private void boxMaximumOnValidating(object sender, CancelEventArgs e)
        {
            float value;
            if (float.TryParse(boxMinimum.Text, out value))
            {
                model.SetMaxValue(value);
                glControlOnPaint(null, null);
            }
        }


    }
}
