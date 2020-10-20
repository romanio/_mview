using OpenTK.Graphics.OpenGL;
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
        ModelForm3D model = null;
        EclipseProject ecl = null;
        Sub3DFilter sub3DFilter = null;

        public Form3D(EclipseProject ecl)
        {
            InitializeComponent();
            this.ecl = ecl;

            sub3DFilter = new Sub3DFilter();
            sub3DFilter.UpdateData += Sub3DFilterOnUpdateData;
        }

        private void Sub3DFilterOnUpdateData(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void UpdateVisual()
        {
            // Заполнение  статических и динамических свойств

            treeProperties.Nodes[0].Nodes.Clear();
            treeProperties.Nodes[1].Nodes.Clear();

            var staticNodes = new List<TreeNode>();

            foreach (string item in model.GetStaticProperties())
            {
                staticNodes.Add(new TreeNode(item));
            }

            treeProperties.Nodes[0].Nodes.AddRange(staticNodes.ToArray());

            var dynamicNodes = new List<TreeNode>();

            foreach (string item in model.GetAllDinamicProperties())
            {
                dynamicNodes.Add(new TreeNode(item));
            }

            treeProperties.Nodes[1].Nodes.AddRange(dynamicNodes.ToArray());

            // Список из всех доступных рестартов

            boxRestart.Items.Clear();
            boxRestart.Items.AddRange(model.GetRestartDates());

            // Размерность по X, Y, Z

            var xSize = new List<object> { "all" };
            
            for (int it = 0; it < model.GetNX(); ++it)
               xSize.Add((it + 1).ToString());

            var ySize = new List<object> { "all" };

            for (int it = 0; it < model.GetNY(); ++it)
                ySize.Add((it + 1).ToString());

            var zSize = new List<object> { "all" };

            for (int it = 0; it < model.GetNZ(); ++it)
                zSize.Add((it + 1).ToString());


            boxXSlice.Items.Clear();
            boxXSlice.Items.AddRange(xSize.ToArray());

            boxYSlice.Items.Clear();
            boxYSlice.Items.AddRange(ySize.ToArray());

            boxZSlice.Items.Clear();
            boxZSlice.Items.AddRange(zSize.ToArray());
        }

        // Всё что касается OpenGL

        private void glControlOnLoad(object sender, EventArgs e)

        {
            model = new ModelForm3D(ecl);

            UpdateVisual();

            model.OnLoad();

            glControlOnResize(null, null);
            glControl.MouseWheel += new MouseEventHandler(glControlOnMouseWheel);

            boxXSlice.SelectedIndex = 0;
            boxYSlice.SelectedIndex = 0;
            boxZSlice.SelectedIndex = 0;

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
            model?.OnResize(glControl.Width, glControl.Height);
            glControl.SwapBuffers();
        }

        private void boxZSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetZA(boxZSlice.SelectedIndex - 1);
            glControlOnPaint(null, null);
        }

        private void boxXSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetXA(boxXSlice.SelectedIndex - 1);
            glControlOnPaint(null, null);
        }

        private void boxYSlice_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.SetYA(boxYSlice.SelectedIndex - 1);
            glControlOnPaint(null, null);
        }

        private void TreePropertiesOnAfterSelect(object sender, TreeViewEventArgs e)
        {
            // Статические свойства

            if (treeProperties.SelectedNode?.Parent?.Index == 0)
            {
                model.OnStaticPropertySelected(treeProperties.SelectedNode.Text);
                //string name = treeProperties.SelectedNode.Text;
                //model.SetStaticProperty(name);

                //model.GenerateStaticGrid();

                //glControlOnPaint(null, null);
            }

            // Динамические свойства

            if (treeProperties.SelectedNode?.Parent?.Index == 1)
            {
                model.OnDynamicPropertySelected(treeProperties.SelectedNode.Text);
                
                //model.SetDynamicProperty(name);
                //model.GenerateRestartGrid();


                //glControlOnPaint(null, null);
            }
        }

        private void BoxRestartOnSelectedIndexChanged(object sender, EventArgs e)
        {
            model.OnRestartSelected(boxRestart.SelectedIndex);

            /*
            if (editVisualData) return;

            System.Diagnostics.Debug.WriteLine("Form2D [BoxRestart SelectedIndexChanged]");

            model.ReadRestart(boxRestart.SelectedIndex);

            treeProperties_AfterSelect(null, null);
            */
        }

        private void bbShowFilterOnClick(object sender, EventArgs e)
        {
            sub3DFilter.Show();
            sub3DFilter.Focus();
        }
    }
}
