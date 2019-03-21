using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mview.ECL;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace mview
{
    public class Grid2D
    {
        public int element_count = 0;

        public float XMINCOORD;
        public float YMINCOORD;
        public float ZMINCOORD;
        public float XMAXCOORD;
        public float YMAXCOORD;
        public float ZMAXCOORD;


        public void GenerateGrid(EclipseProject ecl, Func<int, float> GetValue)
        {
            // Определение максимальной и минимальной координаты Х и Y кажется простым,
            // для этого рассмотрим координаты четырех углов модели.
            // Более полный алгоритм должен рассматривать все 8 углов модели

            // Координата X четырех углов сетки

            List<float> XCORD = new List<float>()
            {
                ecl.EGRID.COORD[0],
                ecl.EGRID. COORD[6 *  ecl.EGRID.NX + 0],
                ecl.EGRID.COORD[6 * ( ecl.EGRID.NX + 1) *  ecl.EGRID.NY + 0],
                ecl.EGRID.COORD[6 * (( ecl.EGRID.NX + 1) * ( ecl.EGRID.NY + 1) - 1) + 0]
            };

            XMINCOORD = XCORD.Min();
            XMAXCOORD = XCORD.Max();

            // Координата Y четырех углов сетки

            List<float> YCORD = new List<float>()
            {
                 ecl.EGRID.COORD[1],
                 ecl.EGRID.COORD[6 *  ecl.EGRID.NX + 1],
                 ecl.EGRID.COORD[6 * (ecl.EGRID.NX + 1) *  ecl.EGRID.NY + 1],
                 ecl.EGRID.COORD[6 * (( ecl.EGRID.NX + 1) * ( ecl.EGRID.NY + 1) - 1) + 1]
            };

            YMINCOORD = YCORD.Min();
            YMAXCOORD = YCORD.Max();

            IntPtr vertex_ptr;
            IntPtr element_ptr;

            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NY * sizeof(float) * 3 * 4 + ecl.EGRID.NX * ecl.EGRID.NY * sizeof(byte) * 4 * 3),
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            vertex_ptr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NY * sizeof(int) * 4),
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            element_ptr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.EGRID.NX * ecl.EGRID.NY * sizeof(float) * 3 * 4);

            System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());

            int cell_index = 0;
            int ZA = 1;
            Colorizer colorizer = new Colorizer();
            Color color;
            float value;
            Cell CELL;
            int index = 0;

            unsafe
            {
                float* vertex_mem = (float*)vertex_ptr;
                int* index_mem = (int*)element_ptr;
                byte* color_mem = (byte*)(vertex_ptr + ecl.EGRID.NX * ecl.EGRID.NY * sizeof(float) * 3 * 4);

                for (int X = 0; X < ecl.EGRID.NX; ++X)
                    for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                    {
                        cell_index = ecl.INIT.GetActive(X, Y, ZA);

                        if (cell_index > 0)
                        {
                            CELL = ecl.EGRID.GetCell(X, Y, ZA);

                            value = GetValue(cell_index - 1);

                            color = colorizer.ColorByValue(value);

                            index_mem[index] = index;
                            vertex_mem[index * 3 + 0] = CELL.TNW.X;
                            vertex_mem[index * 3 + 1] = CELL.TNW.Y;
                            vertex_mem[index * 3 + 2] = 0.1f;

                            color_mem[index * 3 + 0] = color.R;
                            color_mem[index * 3 + 1] = color.G;
                            color_mem[index * 3 + 2] = color.B;

                            index++;

                            index_mem[index] = index;
                            vertex_mem[index * 3 + 0] = CELL.TNE.X;
                            vertex_mem[index * 3 + 1] = CELL.TNE.Y;
                            vertex_mem[index * 3 + 2] = 0.1f;

                            color_mem[index * 3 + 0] = color.R;
                            color_mem[index * 3 + 1] = color.G;
                            color_mem[index * 3 + 2] = color.B;

                            index++;

                            index_mem[index] = index;
                            vertex_mem[index * 3 + 0] = CELL.TSE.X;
                            vertex_mem[index * 3 + 1] = CELL.TSE.Y;
                            vertex_mem[index * 3 + 2] = 0.1f;

                            color_mem[index * 3 + 0] = color.R;
                            color_mem[index * 3 + 1] = color.G;
                            color_mem[index * 3 + 2] = color.B;

                            index++;

                            index_mem[index] = index;
                            vertex_mem[index * 3 + 0] = CELL.TSW.X;
                            vertex_mem[index * 3 + 1] = CELL.TSW.Y;
                            vertex_mem[index * 3 + 2] = 0.1f;

                            color_mem[index * 3 + 0] = color.R;
                            color_mem[index * 3 + 1] = color.G;
                            color_mem[index * 3 + 2] = color.B;

                            index++;
                        }
                    }
            }

            element_count = index;
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
        }
    }
}
