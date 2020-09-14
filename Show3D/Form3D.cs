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
        public Form3D(EclipseProject ecl)
        {
            InitializeComponent();
            model = new Form3DModel(ecl);
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

            Text = model.Engine.grid.ElementCount.ToString();

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
            model.OnResize(glControl.Width, glControl.Height);
            glControl.SwapBuffers();
        }

    }
}
