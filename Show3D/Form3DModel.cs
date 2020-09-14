using System;
using System.Collections.Generic;
using System.Linq;
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
            Engine.grid = new Grid3D();

            if (ecl != null)
            {
                ecl.ReadEGRID();
            }

            if (ecl!= null && ecl.EGRID.FILEHEAD != null)
            {
                ecl.ReadINIT();
            }
        }

        public void OnLoad()
        {
            Engine.OnLoad();

            if (ecl != null && ecl.INIT.FILENAME != null)
            {
                ecl.INIT.ReadGrid("PORO", ref ecl.INIT.DATA);
                SetMinMaxAndScaleFactor();
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
            Engine.OnMouseClick(e);
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
    }
}
