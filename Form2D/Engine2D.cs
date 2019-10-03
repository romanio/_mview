﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Windows.Forms;

namespace mview
{
    public class ViewPosition
    {
        public float Scale = 0.01f;
        public float Shift_X;
        public float Shift_Y;
        public int XS, YS, ZS;
    }

    public enum ViewMode
    { 
        X, Y, Z
    }

    public class CoordConverter
    {
        Engine2D engine = null;
        public ViewMode CurrentViewMode = ViewMode.X;

        public CoordConverter(Engine2D engine)
        {
            this.engine = engine;
        }

        // Я никогда больше не буду отлаживать эту функцию

        public PointF ConvertWorldToScreen(float XC, float YC)
        {
            float X = 0;
            float Y = 0;

            if (CurrentViewMode == ViewMode.X)
            {
                X = (XC - engine.grid.YMINCOORD - 0.5f * (engine.grid.YMAXCOORD - engine.grid.YMINCOORD) + engine.camera.shift_x + engine.camera.shift_end_x - engine.camera.shift_start_x) * engine.camera.scale + 0.5f * engine.width;
                Y = (-30 / (engine.camera.scale_z * engine.camera.scale) -  0.5f * (engine.grid.ZMAXCOORD - engine.grid.ZMINCOORD) - engine.camera.shift_y + engine.camera.shift_end_y - engine.camera.shift_start_y) * engine.camera.scale * engine.camera.scale_z + 0.5f * engine.height;
            };

            if (CurrentViewMode == ViewMode.Y)
            {
                X = (XC - engine.grid.XMINCOORD - 0.5f * (engine.grid.XMAXCOORD - engine.grid.XMINCOORD) + engine.camera.shift_x + engine.camera.shift_end_x - engine.camera.shift_start_x) * engine.camera.scale + 0.5f * engine.width;
                Y = (-30 / (engine.camera.scale_z * engine.camera.scale) - 0.5f * (engine.grid.ZMAXCOORD - engine.grid.ZMINCOORD) - engine.camera.shift_y + engine.camera.shift_end_y - engine.camera.shift_start_y) * engine.camera.scale * engine.camera.scale_z + 0.5f * engine.height;
            };

            if (CurrentViewMode == ViewMode.Z)
            {
                X = (XC - engine.grid.XMINCOORD - 0.5f * (engine.grid.XMAXCOORD - engine.grid.XMINCOORD) + engine.camera.shift_x + engine.camera.shift_end_x - engine.camera.shift_start_x) * engine.camera.scale + 0.5f * engine.width;
                Y = (YC - engine.grid.YMINCOORD - 0.5f * (engine.grid.YMAXCOORD - engine.grid.YMINCOORD) - engine.camera.shift_y + engine.camera.shift_end_y - engine.camera.shift_start_y) * engine.camera.scale + 0.5f * engine.height;
            };


            return new PointF(X, Y);
        }
    }

    public class Engine2D
    {
        public Grid2D grid = new Grid2D();
        public Camera2D camera = new Camera2D();

        public ViewPosition ViewPositionX = new ViewPosition();
        public ViewPosition ViewPositionY = new ViewPosition();
        public ViewPosition ViewPositionZ = new ViewPosition();

        double XMIN, XMAX, YMIN, YMAX;

        public ViewMode CurrentViewMode = ViewMode.X;

        BitmapRender render;

        int vboID;
        int eboID;

        public void SavePosition()
        {
            System.Diagnostics.Debug.WriteLine("Engine2D [SavePosition]");


            if (CurrentViewMode == ViewMode.X)
            {
                ViewPositionX.Scale = camera.scale;
                ViewPositionX.Shift_X = camera.shift_x;
                ViewPositionX.Shift_Y = camera.shift_y;

                ViewPositionX.XS = XS;
                ViewPositionX.YS = YS;
                ViewPositionX.ZS = ZS;
            }

            if (CurrentViewMode == ViewMode.Y)
            {
                ViewPositionY.Scale = camera.scale;
                ViewPositionY.Shift_X = camera.shift_x;
                ViewPositionY.Shift_Y = camera.shift_y;

                ViewPositionY.XS = XS;
                ViewPositionY.YS = YS;
                ViewPositionY.ZS = ZS;
            }

            if (CurrentViewMode == ViewMode.Z)
            {
                ViewPositionZ.Scale = camera.scale;
                ViewPositionZ.Shift_X = camera.shift_x;
                ViewPositionZ.Shift_Y = camera.shift_y;

                ViewPositionZ.XS = XS;
                ViewPositionZ.YS = YS;
                ViewPositionZ.ZS = ZS;
            }
        }

        public void RestorePosition()
        {
            System.Diagnostics.Debug.WriteLine("Engine2D [RestorePosition]");

            if (CurrentViewMode == ViewMode.X)
            {
                camera.scale = ViewPositionX.Scale;
                camera.shift_x = ViewPositionX.Shift_X;
                camera.shift_y = ViewPositionX.Shift_Y;

                XS = ViewPositionX.XS;
                YS = ViewPositionX.YS;
                ZS = ViewPositionX.ZS;

                XMIN = grid.YMINCOORD;
                XMAX = grid.YMAXCOORD;
                YMIN = grid.ZMINCOORD;
                YMAX = grid.ZMAXCOORD;
            }

            if (CurrentViewMode == ViewMode.Y)
            {
                camera.scale = ViewPositionY.Scale;
                camera.shift_x = ViewPositionY.Shift_X;
                camera.shift_y = ViewPositionY.Shift_Y;

                XS = ViewPositionY.XS;
                YS = ViewPositionY.YS;
                ZS = ViewPositionY.ZS;

                XMIN = grid.XMINCOORD;
                XMAX = grid.XMAXCOORD;
                YMIN = grid.ZMINCOORD;
                YMAX = grid.ZMAXCOORD;
            }

            if (CurrentViewMode == ViewMode.Z)
            {
                camera.scale = ViewPositionZ.Scale;
                camera.shift_x = ViewPositionZ.Shift_X;
                camera.shift_y = ViewPositionZ.Shift_Y;

                XS = ViewPositionZ.XS;
                YS = ViewPositionZ.YS;
                ZS = ViewPositionZ.ZS;

                XMIN = grid.XMINCOORD;
                XMAX = grid.XMAXCOORD;
                YMIN = grid.YMINCOORD;
                YMAX = grid.YMAXCOORD;
            }
        }
        
        public void OnLoad()
        {
            System.Diagnostics.Debug.WriteLine("Engine [OnLoad]");

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.PolygonOffsetFill);
            GL.ClearColor(Color.White);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            vboID = GL.GenBuffer();
            eboID = GL.GenBuffer();
            grid.welsID = GL.GenLists(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, eboID);


            grid.Scale = camera.scale;
            grid.ScaleZ = camera.scale_z;
        }

        public void OnUnload()
        {
            System.Diagnostics.Debug.WriteLine("Engine [OnUnLoad]");

            GL.DeleteBuffer(vboID);
            GL.DeleteBuffer(eboID);
            GL.DeleteLists(grid.welsID, 1);
        }

        public int width, height; // Параметры окна вывода

        public void OnResize(int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("Engine [OnResize]");

            this.width = width;
            this.height = height;

            // При изменении размера окна, необходимо определить новые координаты OpenGL
            // и задать новые размеры текстуры, для вывода текста

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            // Центр координат устанавливается в центре окна.

            GL.Ortho(-0.5 * width, +0.5 * width, +0.5 * height, -0.5 * height, -1, +1);
            GL.Viewport(0, 0, width, height);
            GL.ClearColor(Color.White);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //
            if (render != null)
                render.Dispose(); // Удаляем старый рендер текста

            render = new BitmapRender(width, height); // И объявляем новый
        }

        Font WellsFont = new Font("Segoe Pro Cond", 11, FontStyle.Bold);

        public void DrawWells()
        {
            GL.CallList(grid.welsID);

            CoordConverter cordconv = new CoordConverter(this);
            cordconv.CurrentViewMode = CurrentViewMode;

            foreach (ECL.WELLDATA well in grid.ACTIVE_WELLS)
            {
                if (well.COMPLS.Count > 0)
                {
                    render.DrawWell(well, WellsFont, Brushes.Black, cordconv, style);
                }
            }
        }

        public void DrawFrame() // Рамка вокруг модели
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Black);
            GL.Vertex3(XMIN, YMIN, 0);
            GL.Vertex3(XMIN, YMAX, 0);
            GL.Vertex3(XMIN, YMAX, 0);
            GL.Vertex3(XMAX, YMAX, 0);
            GL.Vertex3(XMAX, YMAX, 0);
            GL.Vertex3(XMAX, YMIN, 0);
            GL.Vertex3(XMAX, YMIN, 0);
            GL.Vertex3(XMIN, YMIN, 0);
            GL.End();
        }

        public void OnPaint()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Масштабирование и перенос области отображения

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Scale(camera.scale, camera.scale, 1);

            if (CurrentViewMode != ViewMode.Z)
            {
                GL.Scale(1, camera.scale_z, 1);
            }

            // Центрирование

            GL.Translate(camera.shift_x + (camera.shift_end_x - camera.shift_start_x), -camera.shift_y + camera.shift_end_y - camera.shift_start_y, 0); // Сдвиг за счет мышки

            if (CurrentViewMode == ViewMode.Z)
            {
                GL.Translate(-grid.XC, -grid.YC, 0);
            }

            if (CurrentViewMode == ViewMode.X)
            {
                GL.Translate(-grid.YC, -grid.ZC, 0);
            }

            if (CurrentViewMode == ViewMode.Y)
            {
                GL.Translate(-grid.XC, -grid.ZC, 0);
            }

            if (grid.element_count > 0)
            {

                render.Clear(Color.Transparent);

                DrawWells();

                // Отрисовка ячеек

                GL.PolygonOffset(+1, +1);
                GL.EnableClientState(ArrayCap.ColorArray);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
                GL.DrawElements(PrimitiveType.Quads, grid.element_count, DrawElementsType.UnsignedInt, 0);

                // Отрисовка границ ячеек

                if (style.ShowGridLines == true)
                {
                    GL.PolygonOffset(0, 0);
                    GL.DisableClientState(ArrayCap.ColorArray);
                    GL.Color3(Color.Black);
                    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                    GL.DrawElements(PrimitiveType.Quads, grid.element_count, DrawElementsType.UnsignedInt, 0);
                }
            }

            // Отрисовка выбранной ячейки

            if (CurrentViewMode == ViewMode.X && (YS > -1))
            {
                var CELL = grid.GetCell(XS, YS, ZS);
                
                if ((CELL.TNE.X + CELL.TNW.X + CELL.TSE.X) != 0)
                {
                    float DY = (grid.YMAXCOORD - grid.YMINCOORD) / grid.NY;
                    float DZ = (grid.ZMAXCOORD - grid.ZMINCOORD) / grid.NZ;

                    GL.LineWidth(3);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.Black);

                    GL.Vertex3(CELL.TSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.BNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.BNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.TNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.TNE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS) * grid.StretchFactor, CELL.TNE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TSE.Y * (1 - grid.StretchFactor) + (grid.YMINCOORD + DY * YS + DY) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);


                    GL.End();

                    GL.LineWidth(1);
                }
            }

            if (CurrentViewMode == ViewMode.Y && (XS > -1))
            {
                var CELL = grid.GetCell(XS, YS, ZS);

                if ((CELL.TNE.X + CELL.TNW.X + CELL.TSE.X) != 0)
                {
                    float DX = (grid.XMAXCOORD - grid.XMINCOORD) / grid.NX;
                    float DZ = (grid.ZMAXCOORD - grid.ZMINCOORD) / grid.NZ;

                    GL.LineWidth(3);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.Black);

                    GL.Vertex3(CELL.TSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.TSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.TSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.TSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BSE.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS + DX) * grid.StretchFactor, CELL.BSE.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.BSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.BSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);

                    GL.Vertex3(CELL.BSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.BSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS + DZ) * grid.StretchFactor, 0.3);
                    GL.Vertex3(CELL.TSW.X * (1 - grid.StretchFactor) + (grid.XMINCOORD + DX * XS) * grid.StretchFactor, CELL.TSW.Z * (1 - grid.StretchFactor) + (grid.ZMINCOORD + DZ * ZS) * grid.StretchFactor, 0.3);


                    GL.End();

                    GL.LineWidth(1);
                }
            }

            if (CurrentViewMode == ViewMode.Z && (XS > -1))
            {
                var CELL = grid.GetCell(XS, YS, ZS);

                if ((CELL.TNE.X + CELL.TNW.X + CELL.TSE.X) != 0)
                {
                    GL.LineWidth(3);
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.Black);

                    GL.Vertex3(CELL.TNW.X, CELL.TNW.Y, 0.3);
                    GL.Vertex3(CELL.TNE.X, CELL.TNE.Y, 0.3);

                    GL.Vertex3(CELL.TNE.X, CELL.TNE.Y, 0.3);
                    GL.Vertex3(CELL.TSE.X, CELL.TSE.Y, 0.3);

                    GL.Vertex3(CELL.TSE.X, CELL.TSE.Y, 0.3);
                    GL.Vertex3(CELL.TSW.X, CELL.TSW.Y, 0.3);

                    GL.Vertex3(CELL.TSW.X, CELL.TSW.Y, 0.3);
                    GL.Vertex3(CELL.TNW.X, CELL.TNW.Y, 0.3);

                    GL.End();

                    GL.LineWidth(1);
                }
            }

            DrawFrame();

            // Вывод текста текстурой
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, render.Texture);

            GL.LoadIdentity();

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Begin(PrimitiveType.Quads);
            GL.Color4(Color.White);

            GL.TexCoord2(0, 1); GL.Vertex3(-0.5 * width, +0.5 * height, +0.3);
            GL.TexCoord2(1, 1); GL.Vertex3(+0.5 * width, +0.5 * height, +0.3);
            GL.TexCoord2(1, 0); GL.Vertex3(+0.5 * width, -0.5 * height, +0.3);
            GL.TexCoord2(0, 0); GL.Vertex3(-0.5 * width, -0.5 * height, +0.3);

            GL.End();

            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
        
        }

        Form2DModelStyle style = new Form2DModelStyle()
        {
            ShowBubbles = true,
            ShowGridLines = true,
            ShowAllWelltrack = true,
            BubbleMode = BubbleMode.Simulation,
            scale_factor = 100
        };
        
        public void SetStyle(Form2DModelStyle style)
        {
            this.style = style;
            OnPaint();
        }

        public void MouseWheel(MouseEventArgs e)
        {
            camera.MouseWheel(e);

            // Изменение Scale приводит к изменению масштаба по оси Z.
            // Приходится перерисовывать стволы

            grid.Scale = camera.scale;
            grid.ScaleZ = camera.scale_z;
        }

        public void MouseMove(MouseEventArgs e)
        {
            camera.MouseMove(e);
        }

        public int XS, YS, ZS; // Координаты выбранной ячейки
        public float VS; // Значение выбранной ячейки

        public void MouseClick(MouseEventArgs e)
        {
            if (grid.element_count == 0) return;

            if (e.Button == MouseButtons.Left)
            {
                int[] viewport = new int[4];
                GL.GetInteger(GetPName.Viewport, viewport);
                byte[] pixel = null;
                IntPtr p = new IntPtr();

                GL.ReadPixels(e.X, viewport[3] - e.Y, 1, 1, PixelFormat.Rgb, PixelType.UnsignedByte, ref p);

                pixel = BitConverter.GetBytes(p.ToInt32());  // Цвет под мышкой

                float XT = 0;
                float YT = 0;

                if (CurrentViewMode == ViewMode.X)
                {
                    XS = grid.XA;
                    YS = -1;
                    ZS = -1;

                    XT = (e.X - 0.5f * width) / camera.scale + grid.YMINCOORD + 0.5f * (grid.YMAXCOORD - grid.YMINCOORD) - camera.shift_x - camera.shift_end_x + camera.shift_start_x;
                    YT = (e.Y - 0.5f * height) / (camera.scale * camera.scale_z) + grid.ZMINCOORD + 0.5f * (grid.ZMAXCOORD - grid.ZMINCOORD) + camera.shift_y - camera.shift_end_y + camera.shift_start_y;
                    var res = grid.GetCellUnderMouseX(XT, YT, pixel);
                    YS = res.Item1;
                    ZS = res.Item2;
                    VS = res.Item3;
                }

                if (CurrentViewMode == ViewMode.Y)
                {
                    XS = -1;
                    YS = grid.YA;
                    ZS = -1;

                    XT = (e.X - 0.5f * width) / camera.scale + grid.XMINCOORD + 0.5f * (grid.XMAXCOORD - grid.XMINCOORD) - camera.shift_x - camera.shift_end_x + camera.shift_start_x;
                    YT = (e.Y - 0.5f * height) / (camera.scale * camera.scale_z) + grid.ZMINCOORD + 0.5f * (grid.ZMAXCOORD - grid.ZMINCOORD) + camera.shift_y - camera.shift_end_y + camera.shift_start_y;
                    var res = grid.GetCellUnderMouseY(XT, YT, pixel);
                    XS = res.Item1;
                    ZS = res.Item2;
                    VS = res.Item3;
                }

                if (CurrentViewMode == ViewMode.Z)
                {
                    XS = -1;
                    YS = -1;
                    ZS = grid.ZA;

                    XT = (e.X - 0.5f * width) / camera.scale + grid.XMINCOORD + 0.5f * (grid.XMAXCOORD - grid.XMINCOORD) - camera.shift_x - camera.shift_end_x + camera.shift_start_x;
                    YT = (e.Y - 0.5f * height) / camera.scale + grid.YMINCOORD + 0.5f * (grid.YMAXCOORD - grid.YMINCOORD) + camera.shift_y - camera.shift_end_y + camera.shift_start_y;
                    var res = grid.GetCellUnderMouseZ(XT, YT, pixel);
                    XS = res.Item1;
                    YS = res.Item2;
                    VS = res.Item3;
                }
            }
        }
    }
}