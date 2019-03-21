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
        }

        private void boxRestart_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Динамические свойства из выбранного RESTART файла

            model.ReadRestart(boxRestart.SelectedIndex);

            string selected_propery = null;

            foreach(TreeNode node in treeProperties.Nodes[1].Nodes)
            {
                if (node.IsSelected) selected_propery = node.Text;
            }

            treeProperties.Nodes[1].Nodes.Clear();

            var dynamic_properties = model.GetDinamicProperties(boxRestart.SelectedIndex);

            treeProperties.BeginUpdate();


            foreach (string item in dynamic_properties)
            {
                treeProperties.Nodes[1].Nodes.Add(item);

                if (item == selected_propery) treeProperties.SelectedNode = treeProperties.Nodes[1].LastNode;
            }

            treeProperties.EndUpdate();

            //
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

        }

        private void glControlOnPaint(object sender, PaintEventArgs e)
        {
            model.OnPaint();
            glControl.SwapBuffers();
        }

        private void glControlOnMouseMove(object sender, MouseEventArgs e)
        {

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
    }
}
