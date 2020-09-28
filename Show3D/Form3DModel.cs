using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace mview
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    public class VisualFilter
    {
        public Pair<bool, int> ICfrom = new Pair<bool, int>();
        public Pair<bool, int> ICto = new Pair<bool, int>();
        public Pair<bool, int> JCfrom = new Pair<bool, int>();
        public Pair<bool, int> JCto = new Pair<bool, int>();
        public Pair<bool, int> KCfrom = new Pair<bool, int>();
        public Pair<bool, int> KCto = new Pair<bool, int>();
        public Pair<bool, float> min = new Pair<bool, float>();
        public Pair<bool, float> max = new Pair<bool, float>();
    }


    public class Form3DModel
    {
        private readonly EclipseProject ecl = null;
        public Engine3D Engine = null;

        public List<string> Wellnames { get; set; }
        public List<string> RestartDates { get; set; }
        ///public List<WELLDATA> WellRestart { get; set; }
        public List<string> StaticProperties { get; set; }
        public List<string> DynamicProperties { get; set; }

        public Form3DModel(EclipseProject ecl)
        {
            this.ecl = ecl;
            Engine = new Engine3D();
            
            if (ecl != null)
            {
                ecl.ReadEGRID();
            }

            if (ecl!= null && ecl.EGRID.FILEHEAD != null)
            {
                ecl.ReadINIT();

                Engine.grid = new Grid3D(ecl);

            }
        }

        public void OnLoad()
        {
            Engine.OnLoad();

            if (ecl != null && ecl.INIT.FILENAME != null)
            {
                ecl.INIT.ReadGrid("PORO", ref ecl.INIT.DATA);
                SetMinMaxAndScaleFactor();
                Engine.grid.GenerateVertexAndColors(ecl, ecl.INIT.GetValue);
                Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, null);

                Engine.Camera.Scale = 0.004f;
                Engine.IsLoaded = true;
            }
        }

        public void OnResize(int width, int height)
        {
            Engine.OnResize(width, height);
        }

        public void OnUnload()
        {
            Engine.OnUnload();
        }

        public void OnPaint()
        {
            Engine.OnPaint();
        }

        public void MouseMove(MouseEventArgs e)
        {
            Engine.OnMouseMove(e);
        }

        public void MouseWheel(MouseEventArgs e)
        {
            Engine.OnMouseWheel(e);
           // engine.grid.GenerateWellDrawList(style.ShowAllWelltrack);
            //engine.grid.GenerateVectorFiled();
        }

        public void MouseClick(MouseEventArgs e)
        {
          //  Engine.OnMouseClick(e);
        }

        void SetMinMaxAndScaleFactor()// int width, int height)
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

            Engine.grid.XMINCOORD = XCORD.Min();
            Engine.grid.XMAXCOORD = XCORD.Max();

            // Координата Y четырех углов сетки

            List<float> YCORD = new List<float>()
            {
                 ecl.EGRID.COORD[1],
                 ecl.EGRID.COORD[6 *  ecl.EGRID.NX + 1],
                 ecl.EGRID.COORD[6 * (ecl.EGRID.NX + 1) *  ecl.EGRID.NY + 1],
                 ecl.EGRID.COORD[6 * (( ecl.EGRID.NX + 1) * ( ecl.EGRID.NY + 1) - 1) + 1]
            };

            Engine.grid.YMINCOORD = YCORD.Min();
            Engine.grid.YMAXCOORD = YCORD.Max();

            Engine.grid.ZMAXCOORD = ecl.INIT.GetArrayMax("DEPTH");
            Engine.grid.ZMINCOORD = ecl.INIT.GetArrayMin("DEPTH");

            Engine.grid.XC = (Engine.grid.XMINCOORD + Engine.grid.XMAXCOORD) * 0.5f;
            Engine.grid.YC = (Engine.grid.YMINCOORD + Engine.grid.YMAXCOORD) * 0.5f;
            Engine.grid.ZC = (Engine.grid.ZMINCOORD + Engine.grid.ZMAXCOORD) * 0.5f;

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

        public void SetZA(int Z)
        {
            if (Z == -1)
            {
                Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, null);
            }
            else
            {
                Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, new VisualFilter { KCfrom = new Pair<bool, int>(true, Z), KCto = new Pair<bool, int>(true, Z) });
            }
        }

        public void SetYA(int Y)
        {
            if (Y == -1)
            {
                Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, null);

            }
            else
            {
                Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, new VisualFilter { JCfrom = new Pair<bool, int>(true, Y), JCto = new Pair<bool, int>(true, Y) });
            }
        }


        public void SetXA(int X)
        {
            if (X == -1)
            {
                Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, null);

            }
            else
            {
                Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, new VisualFilter { ICfrom = new Pair<bool, int>(true, X), ICto = new Pair<bool, int>(true, X) });
            }
        }

        public void ReadRestart(int step)
        {
            ecl.ReadRestart(step);
            GenerateWellCoord();
        }

        void GenerateWellCoord()
        {
            // Вспомогательный массив WCOORD содержит в себе
            // перфорации скважин. Если скважина вскрывает ячейку, то в массив WCOORD
            // записывается индекс скважины

            foreach (ECL.WELLDATA well in ecl.RESTART.WELLS)
            {
                if (well.LGR == 0)
                {
                    foreach (ECL.COMPLDATA compl in well.COMPLS)
                    {
                        compl.Cell = ecl.EGRID.GetCell(compl.I, compl.J, compl.K);
                    }
                }
            }

            Engine.grid.WELLS = ecl.RESTART.WELLS; // Опасное создание указателя на существующий набор данных
            Engine.grid.Scale = Engine.Camera.Scale;
            Engine.grid.ScaleZ = Engine.Camera.Scale * 12;

            Engine.grid.GenerateWellDrawList(true);
        }

        public void SetStaticProperty(string name)
        {
            ecl.INIT.ReadGrid(name, ref ecl.INIT.DATA);

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
            Engine.grid.Scale = Engine.Camera.Scale;
            Engine.grid.ScaleZ = Engine.Camera.Scale * 12;
            
            Engine.grid.GenerateVertexAndColors(ecl, ecl.INIT.GetValue);
            Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, null);
            Engine.grid.GenerateWellDrawList(true);
        }


        public void GenerateRestartGrid()
        {
            Engine.grid.Scale = Engine.Camera.Scale;
            Engine.grid.ScaleZ = Engine.Camera.Scale * 12;

            Engine.grid.GenerateVertexAndColors(ecl, ecl.RESTART.GetValue);
            Engine.grid.GenerateGraphics(ecl, ecl.INIT.GetValue, null);
            Engine.grid.GenerateWellDrawList(true);
        }

        public void SetDynamicProperty(string name)
        {
            System.Diagnostics.Debug.WriteLine("Form3DModel.cs / void SetDynamicProperty {0} ", name);

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
    }


}
