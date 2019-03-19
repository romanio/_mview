using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace mview
{
    public class Engine2D
    {

        int vboID;
        int eboID;

        public void OnLoad()
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.PolygonOffsetFill);
            GL.ClearColor(Color.White);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            vboID = GL.GenBuffer();
            eboID = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, eboID);
        }

        public void OnUnload()
        {
            GL.DeleteBuffer(vboID);
            GL.DeleteBuffer(eboID);
        }

        int width, height; // Параметры окна вывода

        public void OnResize(int width, int height)
        {
            this.width = width;
            this.height = height;

            // При изменении размера окна, необходимо определить новые координаты OpenGL
            // и задать новые размеры текстуры, для вывода текста

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Центр координат устанавливается в центре окна. Можно было и сместить центр координат в левый верхний угол
            // При использовании центральных точек отсчета, запись несколько тяжеловата

            GL.Ortho(0,  width, 0, height, -1, +1);
            GL.Viewport(0, 0, width, height);

            //       if (render != null) render.Dispose(); // Удаляем старый рендер текста
            //      render = new TextRender(Width, Height); // И объявляем новый
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void OnPaint()
        {

        }

    }


}
