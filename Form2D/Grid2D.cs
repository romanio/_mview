﻿using System;
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
        public int ZA = 0;

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

                    if (show_all)
                        show_well = true;

                    if (!show_all && (compl.K == ZA))
                    {
                        show_well = true;
                    }
                    //
                     
                    if (show_well)
                    {
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

        EclipseProject tmp_ecl;
        Func<int, float> tmp_GetValue;

        public void GenerateGrid(EclipseProject ecl, Func<int, float> GetValue)
        {
            this.tmp_ecl = ecl;
            this.tmp_GetValue = GetValue;

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
