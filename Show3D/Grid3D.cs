using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using mview.ECL;

namespace mview
{
    public class Grid3D
    {
        public float XC, YC, ZC; // Центр модели
        public float XMINCOORD;
        public float YMINCOORD;
        public float ZMINCOORD;
        public float XMAXCOORD;
        public float YMAXCOORD;
        public float ZMAXCOORD;
        public int NX;
        public int NY;
        public int NZ;

        Colorizer Colorizer = new Colorizer();
        public int ElementCount;

        public void GenerateGraphics(EclipseProject ecl, Func<long, float> GetValue, VisualFilter filter)
        {
            Cell CELL;

            Colorizer.SetMinimum(0);
            Colorizer.SetMaximum(1);

            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)((ulong)ecl.INIT.NACTIV * sizeof(float) * 3 * 8 + (ulong)ecl.INIT.NACTIV * sizeof(byte) * 3 * 8), // Три координаты по float, 8 вершин и 
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            IntPtr VertexPtr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)((ulong)ecl.INIT.NACTIV * sizeof(float) * 3 * 14),
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());
            IntPtr ElementPtr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.INIT.NACTIV * sizeof(float) * 3 * 8);

            int index = 0;
            float value = 0;
            int count = 0;
            long cell_index = 0;
            Color color;

            bool skip_right_face = false;
            bool skip_front_face = false;
            bool skip_bottom_face = false;
            bool skip_left_face = false;
            bool skip_top_face = false;
            bool skip_back_face = false;

            // Применить индексные фильтры

            List<int> XSet = new List<int>();
            List<int> YSet = new List<int>();
            List<int> ZSet = new List<int>();

            if (filter != null)
            {
                int X_start = (filter.ICfrom.First) ? filter.ICfrom.Second - 1 : 0;
                int X_end = (filter.ICto.First) ? filter.ICto.Second - 1 : ecl.INIT.NX;

                int Y_start = (filter.JCfrom.First) ? filter.JCfrom.Second - 1 : 0;
                int Y_end = (filter.JCto.First) ? filter.JCto.Second - 1 : ecl.INIT.NY;

                int Z_start = (filter.KCfrom.First) ? filter.KCfrom.Second - 1 : 0;
                int Z_end = (filter.KCto.First) ? filter.KCto.Second - 1 : ecl.INIT.NZ;

                for (int X = X_start; X < X_end; ++X)
                    XSet.Add(X);

                for (int Y = Y_start; Y < Y_end; ++Y)
                    YSet.Add(Y);

                for (int Z = Z_start; Z < Z_end; ++Z)
                    ZSet.Add(Z);

            }
            else // Если не используется фильтр, обычное индексирование
            {
                for (int X = 0; X < ecl.INIT.NX; ++X)
                {
                    XSet.Add(X);
                }

                for (int Y = 0; Y < ecl.INIT.NY; ++Y)
                {
                    YSet.Add(Y);
                }

                                for (int Z = 0; Z < ecl.INIT.NZ; ++Z)
                {
                    ZSet.Add(Z);
                }


               //ZSet.Add(0);
            }

            unsafe
            {
                float* vertex_mem = (float*)VertexPtr;
                int* index_mem = (int*)ElementPtr;
                byte* color_mem = (byte*)(VertexPtr + ecl.INIT.NACTIV * sizeof(float) * 3 * 8);

                for (int zindex = 0; zindex < ZSet.Count; ++zindex)
                {
                    for (int yindex = 0; yindex < YSet.Count; ++yindex)
                    {
                        for (int xindex = 0; xindex < XSet.Count; ++xindex)
                        {
                            cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex]);
                            
                            if (cell_index > 0)
                            {
                                CELL = ecl.EGRID.GetCell(XSet[xindex], YSet[yindex], ZSet[zindex]);

                                value = GetValue(cell_index - 1);
                                color = Colorizer.ColorByValue(value);

                                // Проверка соседей по X справа

                                skip_right_face = false;

                                if (xindex < XSet.Count - 1) // Только не для последнего элемента
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex + 1], YSet[yindex], ZSet[zindex]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(XSet[xindex + 1], YSet[yindex], ZSet[zindex]);

                                        // Если правая грань по X совпадает с левой гранью по X+1, не надо ничего рисовать

                                        if ((CELL.TNE == NCELL.TNW) &&
                                            (CELL.TSE == NCELL.TSW) &&
                                            (CELL.BNE == NCELL.BNW) &&
                                            (CELL.BSE == NCELL.BSW))
                                        {
                                            skip_right_face = true;
                                        }
                                    }
                                }

                                // Проверка соседей по X слева

                                skip_left_face = false;

                                if (xindex > 0)
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex - 1], YSet[yindex], ZSet[zindex]);

                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(XSet[xindex - 1], YSet[yindex], ZSet[zindex]);

                                        if ((CELL.TNW == NCELL.TNE) &&
                                            (CELL.TSW == NCELL.TSE) &&
                                            (CELL.BNW == NCELL.BNE) &&
                                            (CELL.BSW == NCELL.BSE))
                                        {
                                            skip_left_face = true;
                                        }
                                    }
                                }

              
                     // Проверка соседей по Y справа

                     skip_front_face = false;

                     if (yindex < YSet.Count - 1)
                     {
                         cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex + 1], ZSet[zindex]);
                        if (cell_index > 0)
                         {
                             var NCELL = ecl.EGRID.GetCell(XSet[xindex], YSet[yindex + 1], ZSet[zindex]);


                            if ((CELL.TSW == NCELL.TNW) &&
                                 (CELL.TSE == NCELL.TNE) &&
                                 (CELL.BSW == NCELL.BNW) &&
                                 (CELL.BSE == NCELL.BNE))
                             {
                                 skip_front_face = true;
                             }
                         }
                     }


                                // Проверка соседей по Y слева

                                skip_back_face = false;

                                if (yindex > 0)
                                {
                                    cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex - 1], ZSet[zindex]);
                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(XSet[xindex], YSet[yindex - 1], ZSet[zindex]);

                                        if ((CELL.TNW == NCELL.TSW) &&
                                            (CELL.TNE == NCELL.TSE) &&
                                            (CELL.BNW == NCELL.BSW) &&
                                            (CELL.BNE == NCELL.BSE))
                                        {
                                            skip_back_face = true;
                                        }
                                    }
                                }

                                // Проверка соседей по Z снизу

                         skip_bottom_face = false;

                         if (zindex < ZSet.Count - 1)
                                {
                             cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex + 1]);
                                    if (cell_index > 0)
                             {
                                 var NCELL = ecl.EGRID.GetCell(XSet[xindex], YSet[yindex], ZSet[zindex + 1]);

                                        if ((CELL.BNW == NCELL.TNW) &&
                                     (CELL.BNE == NCELL.TNE) &&
                                     (CELL.BSW == NCELL.TSW) &&
                                     (CELL.BSE == NCELL.TSE))
                                 {
                                     skip_bottom_face = true;
                                 }
                             }
                         }

                                // Проверка соседей по Z сверху

                                skip_top_face = false;

                         if (zindex > 0)
                         {
                             cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex - 1]);
                                    if (cell_index > 0)
                             {
                                 var NCELL = ecl.EGRID.GetCell(XSet[xindex], YSet[yindex], ZSet[zindex - 1]);

                                        if ((CELL.TNW == NCELL.BNW) &&
                                     (CELL.TNE == NCELL.BNE) &&
                                     (CELL.TSW == NCELL.BSW) &&
                                     (CELL.TSE == NCELL.BSE))
                                 {
                                     skip_top_face = true;
                                 }
                             }
                         }

                                // Debug
                                //skip_right_face = false;
                                //skip_top_face = false;

                                //skip_back_face = false;
                                //skip_front_face = false;

                                //skip_left_face = false;
                                //skip_bottom_face = false;

                                // TSE----   TSW
                                // TNE----   TNW
                                // BNE----   BNW
                                // TNW(0) .. TSW(1) ..  TSE(2) .. TNE(3) 
                                // BNW(4) .. BSW(5) .. BSE(6) .. BNE(7)

                                // Top face

                                if (skip_top_face == false)
                                {
                                    index_mem[count++] = index + 2; // TSE - TNE - TSW
                                    index_mem[count++] = index + 3;
                                    index_mem[count++] = index + 1;

                                    index_mem[count++] = index + 1; // TSW - TNE - TNW
                                    index_mem[count++] = index + 3;
                                    index_mem[count++] = index + 0;
                                }


                                // Front face

                                if (skip_back_face == false)
                                {
                                    index_mem[count++] = index + 3; // TNE - BNE - TNW
                                    index_mem[count++] = index + 7;
                                    index_mem[count++] = index + 0;

                                    index_mem[count++] = index + 0; // TNW - BNE - BNW
                                    index_mem[count++] = index + 7;
                                    index_mem[count++] = index + 4;
                                }

                                // Right  face

                                if (skip_right_face == false)
                                {
                                    index_mem[count++] = index + 2; // TSE - BSE - TNE
                                    index_mem[count++] = index + 6;
                                    index_mem[count++] = index + 3;

                                    index_mem[count++] = index + 3; // TNE - BSE - BNE
                                    index_mem[count++] = index + 6;
                                    index_mem[count++] = index + 7;
                                }


                                // TSE----   TSW
                                // TNE----   TNW
                                // BNE----   BNW
                                // TNW(0) .. TSW(1) ..  TSE(2) .. TNE(3) 
                                // BNW(4) .. BSW(5) .. BSE(6) .. BNE(7)

                                // Left face

                                if (skip_left_face == false)
                                {
                                    index_mem[count++] = index + 0; // TNW - BNW - TSW
                                    index_mem[count++] = index + 4;
                                    index_mem[count++] = index + 1;

                                    index_mem[count++] = index + 1; // TSW - BNW - BSW
                                    index_mem[count++] = index + 4;
                                    index_mem[count++] = index + 5;
                                }

                                // Front face

                                if (skip_front_face == false)
                                {
                                    index_mem[count++] = index + 2; // TSE - TSW - BSE
                                    index_mem[count++] = index + 1;
                                    index_mem[count++] = index + 6;

                                    index_mem[count++] = index + 6; // BSE - TSW - BSW
                                    index_mem[count++] = index + 1;
                                    index_mem[count++] = index + 5;
                                }


                                // TSE----   TSW
                                // TNE----   TNW
                                // BNE----   BNW
                                // TNW(0) .. TSW(1) ..  TSE(2) .. TNE(3) 
                                // BNW(4) .. BSW(5) .. BSE(6) .. BNE(7)

                                // Bottom face

                                if (skip_bottom_face == false)
                                {

                                    index_mem[count++] = index + 7; // BNE - BSW - BSE
                                    index_mem[count++] = index + 6;
                                    index_mem[count++] = index + 5;

                                    index_mem[count++] = index + 5; // BSW - BNE - BNW
                                    index_mem[count++] = index + 4;
                                    index_mem[count++] = index + 7;
                                }

                                //count = count + pos;

                                vertex_mem[index * 3 + 0] = CELL.TNW.X;
                                vertex_mem[index * 3 + 1] = CELL.TNW.Y;
                                vertex_mem[index * 3 + 2] = CELL.TNW.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.TSW.X;
                                vertex_mem[index * 3 + 1] = CELL.TSW.Y;
                                vertex_mem[index * 3 + 2] = CELL.TSW.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.TSE.X;
                                vertex_mem[index * 3 + 1] = CELL.TSE.Y;
                                vertex_mem[index * 3 + 2] = CELL.TSE.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.TNE.X;
                                vertex_mem[index * 3 + 1] = CELL.TNE.Y;
                                vertex_mem[index * 3 + 2] = CELL.TNE.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BNW.X;
                                vertex_mem[index * 3 + 1] = CELL.BNW.Y;
                                vertex_mem[index * 3 + 2] = CELL.BNW.Z;


                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BSW.X;
                                vertex_mem[index * 3 + 1] = CELL.BSW.Y;
                                vertex_mem[index * 3 + 2] = CELL.BSW.Z;


                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;


                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BSE.X;
                                vertex_mem[index * 3 + 1] = CELL.BSE.Y;
                                vertex_mem[index * 3 + 2] = CELL.BSE.Z;


                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BNE.X;
                                vertex_mem[index * 3 + 1] = CELL.BNE.Y;
                                vertex_mem[index * 3 + 2] = CELL.BNE.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;
                                //
                            }
                        }
                    }
                }
            }

            ElementCount = count;
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
        }
    }
}
