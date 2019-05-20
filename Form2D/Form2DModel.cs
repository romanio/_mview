﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public enum BubbleMode
    {
        Simulation,
        Historical,
        SimVSHist
    }

    public class Form2DModelStyle
    {
        public bool ShowGridLines = true;
        public bool ShowAllWelltrack = true;
        public bool ShowBubbles = true;
        public BubbleMode BubbleMode = BubbleMode.Simulation;
        public double min_value = 0;
        public double max_value = 100;
        public double scale_factor = 100;
    }


    public class Form2DModel
    {
        Engine2D engine = null;
        EclipseProject ecl = null;
        public Form2DModelStyle style = new Form2DModelStyle();

        public Form2DModel(EclipseProject ecl)
        {
            this.ecl = ecl;
            engine = new Engine2D();

            ecl.ReadEGRID();
            ecl.ReadINIT();
            SetMinMaxAndScaleFactor();
        }

        public void ApplyStyle()
        {
            engine.SetStyle(style);
            engine.grid.colorizer.SetMinimum(style.min_value);
            engine.grid.colorizer.SetMaximum(style.max_value);
            engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
            engine.grid.RefreshGrid();
        }

        void SetMinMaxAndScaleFactor()
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

            engine.grid.XMINCOORD = XCORD.Min();
            engine.grid.XMAXCOORD = XCORD.Max();

            // Координата Y четырех углов сетки

            List<float> YCORD = new List<float>()
            {
                 ecl.EGRID.COORD[1],
                 ecl.EGRID.COORD[6 *  ecl.EGRID.NX + 1],
                 ecl.EGRID.COORD[6 * (ecl.EGRID.NX + 1) *  ecl.EGRID.NY + 1],
                 ecl.EGRID.COORD[6 * (( ecl.EGRID.NX + 1) * ( ecl.EGRID.NY + 1) - 1) + 1]
            };

            engine.grid.YMINCOORD = YCORD.Min();
            engine.grid.YMAXCOORD = YCORD.Max();

            engine.grid.XC = (engine.grid.XMINCOORD + engine.grid.XMAXCOORD) * 0.5f;
            engine.grid.YC = (engine.grid.YMINCOORD + engine.grid.YMAXCOORD) * 0.5f;
            engine.grid.ZC = (engine.grid.ZMINCOORD + engine.grid.ZMAXCOORD) * 0.5f;
        }

        void GenerateWellCoord() 
        {
            // Вспомогательный массив WCOORD содержит в себе
            // перфорации скважин. Если скважина вскрывает ячейку, то в массив WCOORD
            // записывается индекс скважины

            engine.grid.WCOORD = new int[ecl.INIT.NACTIV];

            foreach(ECL.WELLDATA well in ecl.RESTART.WELLS)
            {
                foreach (ECL.COMPLDATA compl in well.COMPLS)
                {
                    engine.grid.WCOORD[ecl.INIT.GetActive(compl.I, compl.J, compl.K) - 1] = well.WINDEX;
                    compl.XC = 0.5f * (ecl.EGRID.GetCell(compl.I, compl.J, compl.K).TNW.X + ecl.EGRID.GetCell(compl.I, compl.J, compl.K).TSE.X);
                    compl.YC = 0.5f * (ecl.EGRID.GetCell(compl.I, compl.J, compl.K).TNW.Y + ecl.EGRID.GetCell(compl.I, compl.J, compl.K).TSE.Y);
                    compl.ZC = 0.5f * (ecl.EGRID.GetCell(compl.I, compl.J, compl.K).TNW.Z + ecl.EGRID.GetCell(compl.I, compl.J, compl.K).TSE.Z);
                }
            }

            engine.grid.WELLS = ecl.RESTART.WELLS; // Опасное создание указателя на существующий набор данных

            engine.grid.GenerateWellDrawList(true);
        }

        public void ReadRestart(int step)
        {
            ecl.ReadRestart(step);
            GenerateWellCoord();
        }

        public List<string> GetStaticProperties()
        {
            var StaticProperties = new List<string>();

            for (int iw = 0; iw < ecl.INIT.NAME.Count; ++iw)
                for (int it = 0; it < ecl.INIT.NAME[iw].Length; ++it)
                    if (ecl.INIT.NUMBER[iw][it] == ecl.INIT.NACTIV)
                        StaticProperties.Add(ecl.INIT.NAME[iw][it]);

            return StaticProperties;
        }

        public List<string> GetAllDinamicProperties()
        {
            var DynamicProperties = new List<string>();

            for (int it = 0; it < ecl.RESTART.NAME.Count; ++it)
            {
                DynamicProperties.AddRange(GetDinamicProperties(it));
            }

            return DynamicProperties.Distinct().ToList();
        }

        public List<string> GetDinamicProperties(int istep) // Вектора могут быть разными на разных рестар файлах
        {
            var DynamicProperties = new List<string>();

            for (int it = 0; it < ecl.RESTART.NAME[istep].Length; ++it)
                if (ecl.RESTART.NUMBER[istep][it] == ecl.INIT.NACTIV)
                    DynamicProperties.Add(ecl.RESTART.NAME[istep][it]);

            return DynamicProperties;
        }

        public int GetNZ()
        {
            return ecl.EGRID.NZ;
        }

        public string[] GetRestartDates()
        {
            return
                (from item in ecl.RESTART.DATE
                 select item.ToString()).ToArray();
        }

        public void SetStaticProperty(string name)
        {
            ecl.INIT.ReadGrid(name);
            engine.grid.GenerateGrid(ecl, ecl.INIT.GetValue);
            engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
        }

        public void SetDynamicProperty(string name)
        {
            if (Array.IndexOf(ecl.RESTART.NAME[ecl.RESTART.RESTART_STEP], name) != -1)
            {
                ecl.RESTART.ReadGrid(name);
                engine.grid.GenerateGrid(ecl, ecl.RESTART.GetValue);
                engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
            }
        }

        public void SetZA(int Z)
        {
            engine.grid.ZA = Z;
          }

        public void OnLoad()
        {
            engine.OnLoad();
        }

        bool resize_init = true;

        public void OnResize(int width, int height)
        {
            if (resize_init) // Установить начальный масштабный фактор
            {

                float DX = engine.grid.XMAXCOORD - engine.grid.XMINCOORD;
                float DY = engine.grid.YMAXCOORD - engine.grid.YMINCOORD;

                float MC = Math.Max(DX, DY) * 1.1f;
                float SC = Math.Min(width, height);

                engine.camera.scale = SC / MC;
                resize_init = false;
            }

            engine.OnResize(width, height);
        }

        public void OnUnload()
        {
            engine.OnUnload();
        }

        public void OnPaint()
        {
            engine.OnPaint();
        }

        public void MouseMove(MouseEventArgs e)
        {
            engine.MouseMove(e);
        }

        public void MouseWheel(MouseEventArgs e)
        {
            engine.MouseWheel(e);
        }
    }
}
