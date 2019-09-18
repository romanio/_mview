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
        public int[] WCOORD = null;
        public int welsID;

        public void GenerateWellDrawList(bool show_all)
        {
            System.Diagnostics.Debug.WriteLine("GRID : GenerateWellDrawList");

            ACTIVE_WELLS = new List<WELLDATA>();

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

                    if (show_all)
                        show_well = true;

                    if (!show_all && (compl.K == ZA))
                    {
                        show_well = true;
                    }
                    //
                     
                    if (show_well)
                    {
                        compl.is_show = true;
                        GL.Vertex3(compl.XC, compl.YC, 0.2);
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

                    if (show_all)
                        show_well = true;

                    if (!show_all && (compl.K == ZA))
                    {
                        show_well = true;
                    }
                    //

                    if (show_well)
                    {
                        if (is_first_name) // Отрабатывает только один раз, при первом появлении скважины
                        {
                            last_XC = compl.XC;
                            last_YC = compl.YC;

                            well.XC = compl.XC;
                            well.YC = compl.YC;

                            ACTIVE_WELLS.Add(well); // Сохраняется в списке активных скважин
                        }
                        else // если скважина уже существует, рисуем часть ствола
                        {
                            GL.Vertex3(last_XC, last_YC, 0.2);
                            GL.Vertex3(compl.XC, compl.YC, 0.2);

                            last_XC = compl.XC;
                            last_YC = compl.YC;
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
            GenerateGrid(tmp_ecl, tmp_GetValue);
        }

        public Cell GetCell(int X, int Y, int Z)
        {
            var cell_index = tmp_ecl.INIT.GetActive(X, Y, Z);

            if (cell_index > 0)
            {
                return tmp_ecl.EGRID.GetCell(X, Y, Z);
            }

            return new Cell();
        }

        public Tuple<int, int, float> GetCellUnderMouseZ(float eX, float eY, byte[] pixel)
        {
            int cell_index = 0;
            float value;
            Color color;
            Cell CELL;

            for (int X = 0; X < tmp_ecl.EGRID.NX; ++X)
                for (int Y = 0; Y < tmp_ecl.EGRID.NY; ++Y)
                {
                    cell_index = tmp_ecl.INIT.GetActive(X, Y, ZA);

                    if (cell_index > 0)
                    {
                        value = tmp_GetValue(cell_index - 1);
                        color = colorizer.ColorByValue(value);

                        if (color.R == pixel[0])
                            if (color.G == pixel[1])
                                if (color.B == pixel[2])
                                {
                                    CELL = tmp_ecl.EGRID.GetCell(X, Y, ZA);

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


        EclipseProject tmp_ecl;
        Func<int, float> tmp_GetValue;

        public void GenerateGrid(EclipseProject ecl, Func<int, float> GetValue)
        {
            this.tmp_ecl = ecl;
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
