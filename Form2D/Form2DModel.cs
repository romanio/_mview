using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public class Form2DModel
    {
        Engine2D engine = null;
        EclipseProject ecl = null;

        public Form2DModel(EclipseProject ecl)
        {
            this.ecl = ecl;
            engine = new Engine2D();

            ecl.ReadEGRID();
            ecl.ReadINIT();
        }

        public void ShowOptions()
        {
            Form2DOptions tmp = new Form2DOptions();
            tmp.Show();
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

            engine.grid.GenerateWellDrawList();
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
        }

        public void SetDynamicProperty(string name)
        {
            if (Array.IndexOf(ecl.RESTART.NAME[ecl.RESTART.RESTART_STEP], name) != -1)
            {
                ecl.RESTART.ReadGrid(name);
                engine.grid.GenerateGrid(ecl, ecl.RESTART.GetValue);
            }
        }

        public void SetMinValue(float value)
        {
            engine.grid.colorizer.SetMinimum(value);
        }

        public void SetMaxValue(float value)
        {
            engine.grid.colorizer.SetMaximum(value);
        }

        public void SetZA(int Z)
        {
            engine.grid.ZA = Z;
          }

        public void OnLoad()
        {
            engine.OnLoad();
        }

        public void OnResize(int width, int height)
        {
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

        public void SetGridlineStatus(bool state)
        {
            engine.SetGridlineState(state);
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
