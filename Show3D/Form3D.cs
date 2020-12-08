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
        Form3DModel model = null;
        readonly EclipseProject ecl = null;
        readonly SubGraphicFilter subGraphicFilter = null;

        public Form3D(EclipseProject ecl)
        {
            InitializeComponent();

            this.ecl = ecl;

            subGraphicFilter = new SubGraphicFilter();
            subGraphicFilter.UpdateData += SubGraphicFilterOnUpdateData;
        }

        private void SubGraphicFilterOnUpdateData(object sender, EventArgs e)
        {
            model.OnSetGraphicFilter(subGraphicFilter.GetData());
            model.OnPaint();
            glControl.SwapBuffers();
        }

        void UpdateVisualData()
        {
            // Заполнение  статических и динамических свойств

            treeProperties.Nodes[0].Nodes.Clear();
            treeProperties.Nodes[1].Nodes.Clear();

            var staticNodes = new List<TreeNode>();

            foreach (string item in model.GetStaticProperties())
                staticNodes.Add(new TreeNode(item));

            treeProperties.Nodes[0].Nodes.AddRange(staticNodes.ToArray());

            var dynamicNodes = new List<TreeNode>();

            foreach (string item in model.GetAllDinamicProperties())
                dynamicNodes.Add(new TreeNode(item));

            treeProperties.Nodes[1].Nodes.AddRange(dynamicNodes.ToArray());

            // Список из всех доступных рестартов

            boxRestart.Items.Clear();
            boxRestart.Items.AddRange(model.GetRestartDates());
            
            if (boxRestart.Items.Count > 0)  boxRestart.SelectedIndex = 0;

            // Обновить размерность по X, Y, Z

            subGraphicFilter.SetData(model.GetNX(), model.GetNY(), model.GetNZ());
        }
        private void glControlOnLoad(object sender, EventArgs e)
        {
            model = new Form3DModel(ecl);
            UpdateVisualData();
            model.OnLoad();

            glControlOnResize(null, null);
            glControl.MouseWheel += new MouseEventHandler(glControlOnMouseWheel);
        }
        private void glControlOnMouseWheel(object sender, MouseEventArgs e)
        {
            model.OnMouseWheel(e);
            model.OnPaint();
            glControl.SwapBuffers();
        }
        private void glControlOnPaint(object sender, PaintEventArgs e)
        {
            model.OnPaint();
            glControl.SwapBuffers();
        }
        private void glControlOnMouseMove(object sender, MouseEventArgs e)
        {
            model.OnMouseMove(e);
            model.OnPaint();
            glControl.SwapBuffers();
        }
        private void glControlOnMouseClick(object sender, MouseEventArgs e)
        {
            model.MouseClick(e);
            glControl.SwapBuffers();
        }

        private void glControlOnResize(object sender, EventArgs e)
        {
            model?.OnResize(glControl.Width, glControl.Height);
          
            glControl.SwapBuffers();
        }
        private void TreePropertiesOnAfterSelect(object sender, TreeViewEventArgs e)
        {
            // Статические свойства

            if (treeProperties.SelectedNode?.Parent?.Index == 0)
            {
                model.OnStaticPropertySelected(treeProperties.SelectedNode.Text);
            }
            // Динамические свойства

            if (treeProperties.SelectedNode?.Parent?.Index == 1)
            {
                model.OnDynamicPropertySelected(treeProperties.SelectedNode.Text);
            }

            model.OnPaint();
            glControl.SwapBuffers();
        }

        private void BoxRestartOnSelectedIndexChanged(object sender, EventArgs e)
        {
            model.OnRestartSelected(boxRestart.SelectedIndex);
        }

        private void ButtonShowFilterOnClick(object sender, EventArgs e)
        {
            subGraphicFilter.Show();
            subGraphicFilter.Focus();
        }
    }
}
