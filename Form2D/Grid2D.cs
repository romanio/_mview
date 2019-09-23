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
        public List<WELLDATA> WELLS; // Опасная копия данных с рестарт файла
        public List<WELLDATA> ACTIVE_WELLS; // Только те скважины, которые следует отображать

        public ViewMode CurrentViewMode = ViewMode.X;
        public float StretchFactor = 0;

        public Colorizer colorizer = new Colorizer();

        public int element_count = 0;

        public float XMINCOORD;
        public float YMINCOORD;
        public float ZMINCOORD;
        public float XMAXCOORD;
        public float YMAXCOORD;
        public float ZMAXCOORD;
        public float XC;
        public float YC;
        public float ZC;

        // Выбранные для отображения координаты

        public int ZA = 0;
        public int XA = 0;
        public int YA = 0;


        // Информация по перфорациям
     //   public int[] WCOORD = null;
        public int welsID;

        public void GenerateWellDrawList(bool show_all)
        {
            ACTIVE_WELLS = new List<WELLDATA>();

            float DX = (XMAXCOORD - XMINCOORD) / ecl.EGRID.NX;
            float DY = (YMAXCOORD - YMINCOORD) / ecl.EGRID.NY;
            float DZ = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

            GL.NewList(welsID, ListMode.Compile);

            System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());

            // Отрисовываем точки

            GL.PointSize(7);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Points);

            bool show_well = false;

            foreach (ECL.WELLDATA well in WELLS)
            {
                foreach (ECL.COMPLDATA compl in well.COMPLS)
                {
                    // Решение о визуализации скважины

                    show_well = false;
                    compl.is_show = false;

                    if (CurrentViewMode == ViewMode.Z)
                    {
                        if (show_all) show_well = true;

                        if (!show_all && (compl.K == ZA))
                        {
                            show_well = true;
                        }
                   
                        if (show_well)
                        {
                            compl.is_show = true;

                            var XC = 0.5f * (compl.Cell.TNW.X + compl.Cell.TSE.X);
                            var YC = 0.5f * (compl.Cell.TNW.Y + compl.Cell.TSE.Y);

                            GL.Vertex3(XC, YC, 0.2);
                        }
                    }

                    if (CurrentViewMode == ViewMode.X)
                    {
                        if (compl.I == XA)
                        {
                            compl.is_show = true;

                            var YC = 0.5 * (compl.Cell.TSE.Y + compl.Cell.BNE.Y) * (1 - StretchFactor) + YMINCOORD + DY * compl.J + 0.5 * DY;  //0.5f * (compl.Cell.TSE.Y + compl.Cell.BNE.Y);
                            var ZC = 0.5 * (compl.Cell.TSE.Z + compl.Cell.BNE.Z) * (1 - StretchFactor) + ZMINCOORD + DZ * compl.K + 0.5 * DZ;

                            GL.Vertex3(YC, ZC, 0.2);
                        }
                    }
                }
            }

            GL.End();

            // Затем отрисовывем ствол скважины линиями

            GL.Color3(Color.Black);
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.Lines);

            foreach (ECL.WELLDATA well in WELLS)
            {
                bool is_first_name = true;
                float last_XC = 0;
                float last_YC = 0;

                foreach (ECL.COMPLDATA compl in well.COMPLS)
                {
                    // Решение о визуализации скважины

                    show_well = false;

                    if (CurrentViewMode == ViewMode.Z)
                    {
                        if (show_all)
                            show_well = true;

                        if (!show_all && (compl.K == ZA))
                        {
                            show_well = true;
                        }
                    }

                    if (CurrentViewMode == ViewMode.X)
                    {
                        if ((compl.I == XA))
                        {
                            show_well = true;
                        }
                    }
                    //

                    if (show_well)
                    {
                        if (is_first_name) // Отрабатывает только один раз, при первом появлении скважины
                        {
                            if (CurrentViewMode == ViewMode.Z)
                            {
                                var XC = 0.5f * (compl.Cell.TNW.X + compl.Cell.TSE.X);
                                var YC = 0.5f * (compl.Cell.TNW.Y + compl.Cell.TSE.Y);

                                last_XC = XC;
                                last_YC = YC;

                                well.XC = XC;
                                well.YC = YC;
                            }

                            if (CurrentViewMode == ViewMode.X)
                            {
                                var YC = 0.5 * (compl.Cell.TSE.Y + compl.Cell.BNE.Y) * (1 - StretchFactor) + YMINCOORD + DY * compl.J + 0.5 * DY; 
                                var ZC = 0.5 * (compl.Cell.TSE.Z + compl.Cell.BNE.Z) * (1 - StretchFactor) + ZMINCOORD + DZ * compl.K + 0.5 * DZ;

                                last_XC = (float)YC;
                                last_YC = (float)ZC;

                                well.XC = (float)YC;
                                well.YC = (float)ZC;
                            }
                            ACTIVE_WELLS.Add(well); // Сохраняется в списке активных скважин
                        }
                        else // если скважина уже существует, рисуем часть ствола
                        {
                            if (CurrentViewMode == ViewMode.Z)
                            {
                                var XC = 0.5f * (compl.Cell.TNW.X + compl.Cell.TSE.X);
                                var YC = 0.5f * (compl.Cell.TNW.Y + compl.Cell.TSE.Y);

                                GL.Vertex3(XC, YC, 0.2);

                                last_XC = XC;
                                last_YC = YC;
                            }

                            if (CurrentViewMode == ViewMode.X)
                            {
                                double YC = 0.5 * (compl.Cell.TSE.Y + compl.Cell.BNE.Y) * (1 - StretchFactor) + YMINCOORD + DY * compl.J + 0.5 * DY;
                                var ZC = 0.5 * (compl.Cell.TSE.Z + compl.Cell.BNE.Z) * (1 - StretchFactor) + ZMINCOORD + DZ * compl.K + 0.5 * DZ;

                                GL.Vertex3(YC, ZC, 0.2);

                                last_XC = YC;
                                last_YC = ZC;
                            }
                        }

                        is_first_name = false;
                    }
                }
            }

            GL.End();
            GL.LineWidth(1);

            GL.EndList();

            System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());
        }

        public void RefreshGrid()
        {
            GenerateGrid(tmp_GetValue);
        }

        public Cell GetCell(int X, int Y, int Z)
        {
            var cell_index = ecl.INIT.GetActive(X, Y, Z);

            if (cell_index > 0)
            {
                return ecl.EGRID.GetCell(X, Y, Z);
            }

            return new Cell();
        }

        public Tuple<int, int, float> GetCellUnderMouseZ(float eX, float eY, byte[] pixel)
        {
            int cell_index = 0;
            float value;
            Color color;
            Cell CELL;

            for (int X = 0; X < ecl.EGRID.NX; ++X)
                for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                {
                    cell_index = ecl.INIT.GetActive(X, Y, ZA);

                    if (cell_index > 0)
                    {
                        value = tmp_GetValue(cell_index - 1);
                        color = colorizer.ColorByValue(value);

                        if (color.R == pixel[0])
                            if (color.G == pixel[1])
                                if (color.B == pixel[2])
                                {
                                    CELL = ecl.EGRID.GetCell(X, Y, ZA);

                                    float[] xcoords = new float[4] { CELL.TNE.X, CELL.TNW.X, CELL.TSE.X, CELL.TSW.X };
                                    float xmin = xcoords.Min();
                                    float xmax = xcoords.Max();

                                    if (eX >= xmin && eX <= xmax)
                                    {
                                        float[] ycoords = new float[4] { CELL.TNE.Y, CELL.TNW.Y, CELL.TSE.Y, CELL.TSW.Y };
                                        float ymin = ycoords.Min();
                                        float ymax = ycoords.Max();
                                        if (eY >= ymin && eY <= ymax)
                                        {
                                            return new Tuple<int, int, float>(X, Y, value);
                                        }
                                    }
                                }
                    }
                }

            return new Tuple<int, int, float>(-1, -1, -1);
        }


        EclipseProject ecl;
        Func<int, float> tmp_GetValue;

        public void SetEclipseProject(EclipseProject ecl)
        {
            this.ecl = ecl;
        }

        public void GenerateGrid(Func<int, float> GetValue)
        {
            this.tmp_GetValue = GetValue;

            IntPtr vertex_ptr;
            IntPtr element_ptr;

            int cell_index = 0;

            Color color;
            float value;
            Cell CELL;
            int index = 0;

            float DX = 0;
            float DY = 0;
            
            if (CurrentViewMode == ViewMode.Z)
            {
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
            } // End for CurrentViewMode Z

            if (CurrentViewMode == ViewMode.X)
            {
              GL.BufferData(
                    BufferTarget.ArrayBuffer,
                    (IntPtr)(ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(float) * 3 * 4 + ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(byte) * 4 * 3),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                vertex_ptr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);    

                GL.BufferData(
                    BufferTarget.ElementArrayBuffer,
                    (IntPtr)(ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(int) * 4),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                element_ptr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

                GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
                GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                DX = (YMAXCOORD - YMINCOORD) / ecl.EGRID.NY;
                DY = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

                unsafe
                {
                    float* vertex_mem = (float*)vertex_ptr;
                    int* index_mem = (int*)element_ptr;
                    byte* color_mem = (byte*)(vertex_ptr + ecl.EGRID.NY * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                    for (int Z = 0; Z < ecl.EGRID.NZ; ++Z)
                        for (int Y = 0; Y < ecl.EGRID.NY; ++Y)
                        {
                            cell_index = ecl.INIT.GetActive(XA, Y, Z);

                            if (cell_index > 0)
                            {
                                CELL = ecl.EGRID.GetCell(XA, Y, Z);

                                value = GetValue(cell_index - 1);

                                color = colorizer.ColorByValue(value);

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.TSE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.TSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor ;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.BSE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.BSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.BNE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.BNE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.TNE.Y * (1 - StretchFactor) + (YMINCOORD + DX * Y) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.TNE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;
                            }
                        }
                }
            } // End for CurrentViewMode X


            if (CurrentViewMode == ViewMode.Y)
            {
                GL.BufferData(
                    BufferTarget.ArrayBuffer,
                    (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(float) * 3 * 4 + ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(byte) * 4 * 3),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                vertex_ptr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

                GL.BufferData(
                    BufferTarget.ElementArrayBuffer,
                    (IntPtr)(ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(int) * 4),
                    IntPtr.Zero,
                    BufferUsageHint.StaticDraw);

                element_ptr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

                GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
                GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                DX = (XMAXCOORD - XMINCOORD) / ecl.EGRID.NX;
                DY = (ZMAXCOORD - ZMINCOORD) / ecl.EGRID.NZ;

                unsafe
                {
                    float* vertex_mem = (float*)vertex_ptr;
                    int* index_mem = (int*)element_ptr;
                    byte* color_mem = (byte*)(vertex_ptr + ecl.EGRID.NX * ecl.EGRID.NZ * sizeof(float) * 3 * 4);

                    for (int Z = 0; Z < ecl.EGRID.NZ; ++Z)
                        for (int X = 0; X < ecl.EGRID.NX; ++X)
                        {
                            cell_index = ecl.INIT.GetActive(X, YA, Z);

                            if (cell_index > 0)
                            {
                                CELL = ecl.EGRID.GetCell(X, YA, Z);

                                value = GetValue(cell_index - 1);

                                color = colorizer.ColorByValue(value);

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.TSW.X * (1 - StretchFactor) + (XMINCOORD + DX * X) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.TSW.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.TSE.X * (1 - StretchFactor) + (XMINCOORD + DX * X + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.TSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.BSE.X * (1 - StretchFactor) + (XMINCOORD + DX * X + DX) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.BSE.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                index_mem[index] = index;
                                vertex_mem[index * 3 + 0] = CELL.BSW.X * (1 - StretchFactor) + (XMINCOORD + DX * X) * StretchFactor;
                                vertex_mem[index * 3 + 1] = CELL.BSW.Z * (1 - StretchFactor) + (ZMINCOORD + DY * Z + DY) * StretchFactor;
                                vertex_mem[index * 3 + 2] = 0.1f;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;
                            }
                        }
                }
            } // End for CurrentViewMode Y

            element_count = index;
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
        }
    }
}
