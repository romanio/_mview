﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Drawing;


namespace mview
{
    // Отрисовка текста и прочей графики в текстуру.
    // Используется для вывода текста в режиме OpenGL
    // Код взят с сайта opentk.com на одном из форумов

    class BitmapRender : IDisposable
    {
        Bitmap bmp;
        Graphics gfx;
        int texture;
        Rectangle dirty_region;
        bool disposed;

        public BitmapRender(int width, int height)
        {
            if (width == 0) return;
            if (height == 0) return;

            if (GraphicsContext.CurrentContext == null)
                throw new InvalidOperationException("No GraphicsContext is current on the calling thread.");

            bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            gfx = Graphics.FromImage(bmp);
            gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            texture = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0,
                PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);
        }

        public void Clear(Color color)
        {
            gfx.Clear(color);
            dirty_region = new Rectangle(0, 0, bmp.Width, bmp.Height);
        }

        Font InfoFont = new Font("Segoe Pro Cond", 09, FontStyle.Regular);

        public void DrawWell(ECL.WELLDATA well, Font font, Brush brush, PointF point, bool RenderBubble, BubbleMode bubbleMode, double scale)
        {
            // 100 m3 = 10 pt

            int size = 0; // Размер круга
            float wcut = 1; // Обводненность

            if (bubbleMode == BubbleMode.Simulation)
            {
                size = (int)(Math.Abs(well.WLPR) * scale * 0.01);
                if (size < 4) size = 4;

                wcut = well.WLPR == 0 ? 0 : (float)(well.WWPR / well.WLPR);
            }

            if (bubbleMode == BubbleMode.Historical)
            {
                size = (int)(Math.Abs(well.WLPRH) * scale * 0.01);
                if (size < 4) size = 4;

                wcut = well.WLPRH == 0 ? 0 : (float)(well.WWPRH / well.WLPRH);
            }

            if (well.WLPR > 0)
            {
                if (RenderBubble)
                {
                    gfx.DrawEllipse(new Pen(Color.Black, 1), new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size));
                    gfx.FillPie(Brushes.BurlyWood, new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size), 0, (float)Math.Round(360.0 * (1 - wcut)));
                    gfx.FillPie(Brushes.SteelBlue, new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size), (float)Math.Round(360.0 * (1 - wcut)), 360 - (float)Math.Round(360.0 * (1 - wcut)));
                }
                gfx.DrawString(well.WLPR.ToString("N1") + " / " + (100 * wcut).ToString("N1"), InfoFont, brush, (int)(point.X) - 16, (int)(point.Y) + 16);
            }

            if (well.WLPR < 0) // Меньше нуля, это у нас закачка
            {
                if (RenderBubble)
                {
                    gfx.DrawEllipse(new Pen(Color.Black, 1), new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size));
                    gfx.FillPie(Brushes.LightBlue, new Rectangle((int)(point.X) - size / 2, (int)(point.Y) - size / 2, size, size), 0, 360);
                }

                gfx.DrawString((-well.WLPR).ToString("N1") + " / " + (100 * wcut).ToString("N1"), InfoFont, brush, (int)(point.X) - 16, (int)(point.Y) + 16);
            }

            gfx.FillEllipse(Brushes.White, (int)(point.X) - 4, (int)(point.Y) - 4, 8, 8);
            gfx.DrawEllipse(Pens.Black, (int)(point.X) - 4, (int)(point.Y) - 4, 8, 8);

            gfx.DrawString(well.WELLNAME, font, brush, (int)(point.X) - 8, (int)(point.Y) - 32);
        }

        public int Texture
        {
            get
            {
                UploadBitmap();
                return texture;
            }
        }

        void UploadBitmap()
        {
            if (dirty_region != RectangleF.Empty)
            {
                System.Drawing.Imaging.BitmapData data = bmp.LockBits(dirty_region, System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.BindTexture(TextureTarget.Texture2D, texture);
                GL.TexSubImage2D(TextureTarget.Texture2D, 0, dirty_region.X, dirty_region.Y, dirty_region.Width, dirty_region.Height, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                bmp.UnlockBits(data);
                dirty_region = Rectangle.Empty;
            }
        }

        void Dispose(bool manual)
        {
            if (!disposed)
            {
                if (manual)
                {
                    if (bmp != null)
                        bmp.Dispose();

                    if (gfx != null)
                        gfx.Dispose();

                    if (GraphicsContext.CurrentContext != null)
                        GL.DeleteTexture(texture);
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BitmapRender()
        {
            Console.WriteLine("[Warning] Resource leaked: {0}.", typeof(TextRenderer));
        }
    }

}
