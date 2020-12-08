using System;
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
        public bool ShowNoFillColor = false;
        public bool ShowVectorField = false;

        public BubbleMode BubbleMode = BubbleMode.Simulation;
        public double MinValue = 0;
        public double MaxValue = 1;
        public double ScaleFactor = 30;
        public double ZScale = 12;
        public double StretchFactor = 0;
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
        }

        public void SetPosition(ViewMode Position)
        {
            System.Diagnostics.Debug.WriteLine("Form2DModel [SetPosition = " + Position + " ]");

            engine.SavePosition();

            if (Position == ViewMode.X)
            {
                engine.CurrentViewMode = ViewMode.X;
                engine.camera.CurrentViewMode = ViewMode.X;
                engine.grid.CurrentViewMode = ViewMode.X;

                engine.RestorePosition();
            }

            if (Position == ViewMode.Y)
            {
                engine.CurrentViewMode = ViewMode.Y;
                engine.camera.CurrentViewMode = ViewMode.Y;
                engine.grid.CurrentViewMode = ViewMode.Y;

                engine.RestorePosition();
            }

            if (Position == ViewMode.Z)
            {
                engine.CurrentViewMode = ViewMode.Z;
                engine.camera.CurrentViewMode = ViewMode.Z;
                engine.grid.CurrentViewMode = ViewMode.Z;

                engine.RestorePosition();
            }
            ApplyStyle();
            
        }
        public void ApplyStyleData()
        {
            engine.SetStyle(style);

            engine.grid.colorizer.SetMinimum(style.MinValue);
            engine.grid.colorizer.SetMaximum(style.MaxValue);
            engine.grid.StretchFactor = (float)style.StretchFactor;

        }

        public void ApplyStyle()
        {
            engine.SetStyle(style);

            engine.grid.colorizer.SetMinimum(style.MinValue);
            engine.grid.colorizer.SetMaximum(style.MaxValue);
            engine.grid.StretchFactor = (float)style.StretchFactor;
            engine.camera.scale_z = (float)style.ZScale;

            engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);

            engine.grid.RefreshGrid();
        }

        void SetMinMaxAndScaleFactor(int width, int height)
        {
            System.Diagnostics.Debug.WriteLine("Form2DModel [SetMinMaxAndScaleFactor]");

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

            engine.grid.ZMAXCOORD = ecl.INIT.GetArrayMax("DEPTH");
            engine.grid.ZMINCOORD = ecl.INIT.GetArrayMin("DEPTH");

            engine.grid.XC = (engine.grid.XMINCOORD + engine.grid.XMAXCOORD) * 0.5f;
            engine.grid.YC = (engine.grid.YMINCOORD + engine.grid.YMAXCOORD) * 0.5f;
            engine.grid.ZC = (engine.grid.ZMINCOORD + engine.grid.ZMAXCOORD) * 0.5f;


            float DX, DY, DZ;
            float MC, SC;

            DX = engine.grid.XMAXCOORD - engine.grid.XMINCOORD;
            DY = engine.grid.YMAXCOORD - engine.grid.YMINCOORD;
            DZ = engine.grid.ZMAXCOORD - engine.grid.ZMINCOORD;

            SC = Math.Min(width, height);

            // Z Scale Default

            MC = Math.Max(DX, DY) * 1.1f;
            engine.ViewPositionZ.Scale = SC / MC;

            // X Scale Default

            MC = Math.Max(DY, DZ * engine.camera.scale_z) * 1.1f;
            engine.ViewPositionX.Scale = SC / MC;

            // Y Scale Default

            MC = Math.Max(DX, DZ * engine.camera.scale_z) * 1.1f;
            engine.ViewPositionY.Scale = SC / MC;

            engine.RestorePosition();
        }

        public string[] GetWellNames()
        {
            return
                (from item in ecl.RESTART.WELLS
                 select item.WELLNAME).ToArray();
         }

        public void ReadWellData()
        {
            ecl.RESTART.ReadWellData();
        }

        public void UpdateLumpingMethod(string name)
        {
            ecl.UpdateLumpingMethod(name);
        }
        public ECL.WELLDATA GetWellData(string wellname)
        {
            return ecl.RESTART.WELLS.FirstOrDefault(c => c.WELLNAME == wellname);
        }
        public void SetFocusOnWell(string wellname)
        {
            var well = engine.grid.WELLS.FirstOrDefault(c => c.WELLNAME == wellname);

            if (well != null)
            {
                if (engine.CurrentViewMode == ViewMode.Z)
                {
                    float XC = well.XC;
                    float YC = well.YC;

                    engine.camera.shift_x = -(XC - engine.grid.XC);
                    engine.camera.shift_y = (YC - engine.grid.YC);
                    engine.OnPaint();
                }
            }                   
        }

        void GenerateWellCoord() 
        {
            // Вспомогательный массив WCOORD содержит в себе
            // перфорации скважин. Если скважина вскрывает ячейку, то в массив WCOORD
            // записывается индекс скважины

            engine.grid.SetEclipseProject(ecl);

            foreach(ECL.WELLDATA well in ecl.RESTART.WELLS)
            {
                if (well.LGR == 0)
                {
                    foreach (ECL.COMPLDATA compl in well.COMPLS)
                    {
                        compl.Cell = ecl.EGRID.GetCell(compl.I, compl.J, compl.K);
                    }
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


        public void ReadVectorField()
        {
            if (style.ShowVectorField)
            {
                ecl.RESTART.ReadVectorFile();
            }
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

        public long[] GetPropertyStatistic()
        {
            return PropertyStatistic;
        }

        public float GetPropertyMinValue()
        {
            return PropertyMinValue;
        }

        public float GetPropertyMaxValue()
        {
            return PropertyMaxValue;
        }

        public string GetGridUnit()
        {
            return GridUnit;
        }

        public Tuple<int, int, int, float> GetXYZVSelected()
        {
            return new Tuple<int, int, int, float>(engine.XS, engine.YS, engine.ZS, engine.VS);
        }

        public int GetNX()
        {
            return ecl.EGRID.NX;
        }

        public int GetNY()
        {
            return ecl.EGRID.NY;
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
            System.Diagnostics.Debug.WriteLine("Form2DModel [SetStaticProperty = " + name + " ]");

            ecl.INIT.ReadGrid(name);

            GridUnit = ecl.INIT.GridUnit;
            PropertyMinValue = ecl.INIT.GetArrayMin(name);
            PropertyMaxValue = ecl.INIT.GetArrayMax(name);

            // Расчет распределения свойства по категориям
            
            PropertyStatistic = new long[20];

            // Уникальный случай, когда минимум равен максимуму

            if (PropertyMinValue == PropertyMaxValue)
            {
                PropertyStatistic[0] = 1;
            }
            else
            {
                for (int iw = 0; iw < ecl.INIT.DATA.Length; ++iw)
                    PropertyStatistic[
                        (int)((float)(ecl.INIT.DATA[iw] - PropertyMinValue) / (float)(PropertyMaxValue - PropertyMinValue) * 19)
                        ]++;
            }
       }

        string GridUnit = null;
        float PropertyMinValue = 0;
        float PropertyMaxValue = 1;
        long[] PropertyStatistic = null;

        public void GenerateStaticGrid()
        {
            engine.grid.GenerateGrid(ecl.INIT.GetValue);
            engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
        }


        public void GenerateRestartGrid()
        {
            engine.grid.GenerateGrid(ecl.RESTART.GetValue);
            engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
            engine.grid.GenerateVectorFiled();
        }

        public void SetDynamicProperty(string name)
        {
            System.Diagnostics.Debug.WriteLine("Form2DModel [SetDynamicProperty = " + name + " ]");

            if (Array.IndexOf(ecl.RESTART.NAME[ecl.RESTART.RESTART_STEP], name) != -1)
            {
                ecl.RESTART.ReadGrid(name);

                GridUnit = ecl.RESTART.GridUnit;
                PropertyMinValue = ecl.RESTART.GetArrayMin(name);
                PropertyMaxValue = ecl.RESTART.GetArrayMax(name);

                PropertyStatistic = new long[20];

                // Уникальный случай, когда минимум равен максимуму

                if (PropertyMinValue == PropertyMaxValue)
                {
                    PropertyStatistic[0] = 1;
                }
                else
                {
                    for (int iw = 0; iw < ecl.RESTART.DATA.Length; ++iw)
                        PropertyStatistic[
                            (int)((float)(ecl.RESTART.DATA[iw] - PropertyMinValue) / (float)(PropertyMaxValue - PropertyMinValue) * 19)
                            ]++;
                }
            }
        }

        public void SetXA(int X)
        {
            engine.grid.XA = X;
        }

        public void SetYA(int Y)
        {
            engine.grid.YA = Y;
        }

        public void SetZA(int Z)
        {
            engine.grid.ZA = Z;
          }

        public void OnLoad()
        {
            engine.OnLoad();
        }


        bool InitResize = false;

        public void OnResize(int width, int height)
        {
            if (!InitResize) // Сработать один раз
            {
                SetMinMaxAndScaleFactor(width, height);
                InitResize = true;
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
            engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
            engine.grid.GenerateVectorFiled();
        }

        public void MouseClick(MouseEventArgs e)
        {
            engine.MouseClick(e);
        }
    }
}
