
            
            GL.BufferData(BufferTarget.ElementArrayBuffer, IntPtr.Zero, IntPtr.Zero, BufferUsageHint.StaticDraw);
    
            
            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)(ActiveCellCount * sizeof(int) * 3 * 16), // 16 треугольников
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            ElementPointer = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

            int[] Indices = new int[ActiveCellCount * 3 * 16];


            unsafe
            {
                int* index_mem = (int*)ElementPointer;

                for (int zindex = 0; zindex < ZSet.Count; ++zindex)
                {
                    for (int yindex = 0; yindex < YSet.Count; ++yindex)
                    {
                        for (int xindex = 0; xindex < XSet.Count; ++xindex)
                        {
                            cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex]);
                            
                            if (cell_index > 0)
                            {
                                var CELL = Cells[cell_index - 1];

                                index = 8 * ((int)cell_index - 1);

                                // Проверка соседей по X справа

                                skip_right_face = false;
                                skip_left_face = false;
                                skip_front_face = false;
                                skip_back_face = false;
                                skip_bottom_face = false;
                                skip_top_face = false;

                                if (filter == null)
                                {
                                    if (xindex < XSet.Count - 1) // Только не для последнего элемента
                                    {
                                        cell_index = ecl.INIT.GetActive(XSet[xindex + 1], YSet[yindex], ZSet[zindex]);

                                        if (cell_index > 0)
                                        {
                                            var NCELL = Cells[cell_index - 1];

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


                                    if (xindex > 0)
                                    {
                                        cell_index = ecl.INIT.GetActive(XSet[xindex - 1], YSet[yindex], ZSet[zindex]);

                                        if (cell_index > 0)
                                        {
                                            var NCELL = Cells[cell_index - 1];

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

                                    if (yindex < YSet.Count - 1)
                                    {
                                        cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex + 1], ZSet[zindex]);
                                        if (cell_index > 0)
                                        {
                                            var NCELL = Cells[cell_index - 1];

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

                                    if (yindex > 0)
                                    {
                                        cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex - 1], ZSet[zindex]);
                                        if (cell_index > 0)
                                        {
                                            var NCELL = Cells[cell_index - 1];

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

                                    if (zindex < ZSet.Count - 1)
                                    {
                                        cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex + 1]);
                                        if (cell_index > 0)
                                        {
                                            var NCELL = Cells[cell_index - 1];

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

                                    if (zindex > 0)
                                    {
                                        cell_index = ecl.INIT.GetActive(XSet[xindex], YSet[yindex], ZSet[zindex - 1]);
                                        if (cell_index > 0)
                                        {
                                            var NCELL = Cells[cell_index - 1];

                                            if ((CELL.TNW == NCELL.BNW) &&
                                         (CELL.TNE == NCELL.BNE) &&
                                         (CELL.TSW == NCELL.BSW) &&
                                         (CELL.TSE == NCELL.BSE))
                                            {
                                                skip_top_face = true;
                                            }
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
                             
                                index += 8;
                            }
                        }
                    }
                }
            
          //}

            ElementCount = count;
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);

1. Размеры кнопок
Size 118; 24


            /*
            foreach (ECL.COMPLDATA compl in well.COMPLS)
            {
                if (compl.is_show)
                {
                    PointF point_cpl = cordconv.ConvertWorldToScreen(compl.XC, compl.YC);
                    if (compl.OPR > 0)
                    {
                        gfx.FillRectangle(Brushes.SteelBlue, point_cpl.X + 5, point_cpl.Y - 6, (float)((compl.OPR + compl.WPR) * 50), 12);
                        gfx.FillRectangle(Brushes.BurlyWood, point_cpl.X + 5, point_cpl.Y - 6, (float)(compl.OPR * 50), 12);
                        gfx.DrawRectangle(Pens.Black, point_cpl.X + 5, point_cpl.Y - 6, (float)((compl.OPR + compl.WPR) * 50), 12);
                    }

                    if (compl.WPR < 0)
                    {
                        gfx.FillRectangle(Brushes.LightBlue, point_cpl.X + 5, point_cpl.Y - 6, (float)((-compl.WPR) * 50), 12);
                        gfx.DrawRectangle(Pens.Black, point_cpl.X + 5, point_cpl.Y - 6, (float)((-compl.WPR) * 50), 12);

                    }

                    gfx.DrawEllipse(new Pen(Color.Black, 1), new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size));
                    gfx.FillPie(Brushes.BurlyWood, new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size), 0, (float)Math.Round(360.0 * (1 - wcut)));
                    gfx.FillPie(Brushes.SteelBlue, new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size), (float)Math.Round(360.0 * (1 - wcut)), 360 - (float)Math.Round(360.0 * (1 - wcut)));

                    }
            }


           */


 Модель T

 Цветовое кодирование

 TSE   ----   TSW
 /             /
 /             /
 TNE   ----   TNW


BSE   ----   BSW
 /             /
 /             /
BNE   ----   BNW


 Модель S


 TSE   ----   TSW
 /             /
 /             /
 X   ----   TNW

