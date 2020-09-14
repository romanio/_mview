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

