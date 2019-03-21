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
        public Grid2D grid = new Grid2D();


        int vboID;
        int eboID;

        public void OnLoad()
        {
            System.Diagnostics.Debug.WriteLine("Engine2D : OnLoad");

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
            System.Diagnostics.Debug.WriteLine("Engine2D : OnUnLoad");

            GL.DeleteBuffer(vboID);
            GL.DeleteBuffer(eboID);
        }

        int width, height; // Параметры окна вывода

        public void OnResize(int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("Engine2D : OnResize");

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

        public void DrawFrame() // Рамка вокруг модели
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Black);
            GL.Vertex3(grid.XMINCOORD, grid.YMINCOORD, 0);
            GL.Vertex3(grid.XMINCOORD, grid.YMAXCOORD, 0);
            GL.Vertex3(grid.XMINCOORD, grid.YMAXCOORD, 0);
            GL.Vertex3(grid.XMAXCOORD, grid.YMAXCOORD, 0);
            GL.Vertex3(grid.XMAXCOORD, grid.YMAXCOORD, 0);
            GL.Vertex3(grid.XMAXCOORD, grid.YMINCOORD, 0);
            GL.Vertex3(grid.XMAXCOORD, grid.YMINCOORD, 0);
            GL.Vertex3(grid.XMINCOORD, grid.YMINCOORD, 0);
            GL.End();
        }

        float scale = 0.01f;

        public void OnPaint()
        {
            System.Diagnostics.Debug.WriteLine("Engine2D : OnPaint");

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (grid.element_count == 0) return;

            // Масштабирование и перенос области отображения
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Scale(scale, scale, 1);

            // Центрирование

            GL.Translate((grid.XMINCOORD + 0.5 * (grid.XMAXCOORD - grid.XMINCOORD)), (grid.YMINCOORD + 0.5 * (grid.YMAXCOORD - grid.YMINCOORD)), 0);


            // Отрисовка ячеек
            GL.PolygonOffset(+1, +1);
            GL.EnableClientState(ArrayCap.ColorArray);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.DrawElements(PrimitiveType.Quads, grid.element_count, DrawElementsType.UnsignedInt, 0);

            DrawFrame();


        }
    }
}
