using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using System.Drawing;
using OxyPlot.WindowsForms;
using OxyPlot.Legends;
using mview.ECL;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Text;

namespace mview
{
    public partial class SubWellModel : Form
    {
        public event EventHandler UpdateData;
        public event EventHandler UpdateLumpingMethod;

        readonly PlotModel plotModel = null;
        ECL.WELLDATA m_welldata = null;

        public ECL.WELLDATA WellData
        {
            set
            {
                m_welldata = value;
            }
        }

        bool IsLumped = false;

       
        void UpdateForm()
        {
            gridData.Rows.Clear();

            if (IsLumped == false)
            {
                for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                {
                    int row = gridData.Rows.Add();

                    gridData[0, row].Value = m_welldata.COMPLS[iw].I + 1;
                    gridData[1, row].Value = m_welldata.COMPLS[iw].J + 1;
                    gridData[2, row].Value = m_welldata.COMPLS[iw].K + 1;
                    gridData[3, row].Value = m_welldata.COMPLS[iw].Depth;

                    gridData[4, row].Value = m_welldata.COMPLS[iw].LUMPNUM;

                    gridData[5, row].Value = m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR;
                    gridData[6, row].Value = m_welldata.COMPLS[iw].WPR / (m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR);
                    gridData[7, row].Value = m_welldata.COMPLS[iw].GPR / m_welldata.COMPLS[iw].OPR;

                    gridData[8, row].Value = m_welldata.COMPLS[iw].WPIMULT;
                    gridData[9, row].Value = iw;
                }
            }
            else
            {
                var lumped_zones = m_welldata.COMPLS.Select(c => c.LUMPNUM).Distinct().ToArray();
                
                for (int iw = 0; iw < lumped_zones.Length; ++iw)
                {
                    int row = gridData.Rows.Add();

                    gridData[3, row].Value = m_welldata.COMPLS.Where(c => c.LUMPNUM == lumped_zones[iw]).Average(c => c.Depth);
                    gridData[4, row].Value = lumped_zones[iw];
                    
                    var wpr = m_welldata.COMPLS.Where(c => c.LUMPNUM == lumped_zones[iw]).Sum(c => c.WPR);
                    var opr = m_welldata.COMPLS.Where(c => c.LUMPNUM == lumped_zones[iw]).Sum(c => c.OPR);
                    var gpr = m_welldata.COMPLS.Where(c => c.LUMPNUM == lumped_zones[iw]).Sum(c => c.GPR);

                    gridData[5, row].Value = wpr + opr;
                    gridData[6, row].Value = wpr / (wpr + opr);
                    gridData[7, row].Value = gpr / opr;

                    gridData[9, row].Value = iw;
                }
            }
        }

        void UpdateCharts()
        {
            plotModel.Series.Clear();

            plotModel.Series.Add(new RectangleBarSeries
            {
                StrokeThickness = 0,
            });

            plotModel.Series.Add(new RectangleBarSeries
            {
                StrokeThickness = 1,
                StrokeColor = OxyColors.Black,
                FillColor = OxyColors.Transparent
            }); ; ;

            plotModel.Series.Add(new RectangleBarSeries
            {
                StrokeThickness = 2,
                StrokeColor = OxyColors.Black,
                FillColor = OxyColors.Transparent
            });

            if (IsLumped == false)
            {
                switch (boxChartMode.SelectedIndex)
                {
                    case 0: // Pressure drop 

                        plotModel.Axes[0].Title = "(P - Pw), bar";
                        plotModel.Axes[1].Title = "Depth, m";

                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.OrangeRed;
                        DrawGraph((x) => x.PRESS - x.Hw - m_welldata.WBHP, PDD_LIST);

                        break;

                    case 1: // Liquid production

                        plotModel.Axes[0].Title = "Liquid, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Aqua;

                        DrawGraph((x) => x.WPR + x.OPR, LIQ_LIST);
                        break;

                    case 2: // Oil production
                        plotModel.Axes[0].Title = "Oil, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        DrawGraph((x) => x.OPR, OIL_LIST);
                        break;

                    case 3: // Water production
                        plotModel.Axes[0].Title = "Water, m3/day";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.BlueViolet;

                        DrawGraph((x) => x.WPR, WATER_LIST);
                        break;

                    case 4: // Water Cut
                        plotModel.Axes[0].Title = "Water Cut";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.CadetBlue;

                        DrawGraph((x) => x.WPR / (x.WPR + x.OPR), WCUT_LIST);
                        break;

                    case 5: // Connection Factor
                        plotModel.Axes[0].Title = "PI, m3/day/bar";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        DrawGraph((x) => (x.OPR + x.WPR) / (x.PRESS - x.Hw - m_welldata.WBHP), CPI_LIST);
                        break;
                }
            }
            else
            {
                switch (boxChartMode.SelectedIndex)
                {
                    case 0: // Pressure drop 

                        plotModel.Axes[0].Title = "(P - Pw), bar";
                        plotModel.Axes[1].Title = "Depth, m";

                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.OrangeRed;
                        //DrawLumpGraph((x) => x.PRESS - x.Hw - m_welldata.WBHP, PDD_LIST);

                        break;

                    case 1: // Liquid production

                        plotModel.Axes[0].Title = "Liquid, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Aqua;

                        DrawLumpGraph(LUMP_LIQ_LIST, LUMP_M_LIQ_LIST);
                        break;

                    case 2: // Oil production
                        plotModel.Axes[0].Title = "Oil, m3/day";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        DrawLumpGraph(LUMP_OIL_LIST, LUMP_M_OIL_LIST);
                        break;

                    case 3: // Water production
                        plotModel.Axes[0].Title = "Water, m3/day";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.BlueViolet;

                        DrawLumpGraph(LUMP_WATER_LIST, LUMP_M_WATER_LIST);
                        break;

                    case 4: // Water Cut
                        plotModel.Axes[0].Title = "Water Cut";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.CadetBlue;

                        DrawLumpGraph(LUMP_WCUT_LIST, LUMP_M_WCUT_LIST);
                        break;

                    case 5: // Connection Factor
                        plotModel.Axes[0].Title = "PI, m3/day/bar";
                        plotModel.Axes[1].Title = "Depth, m";
                        ((RectangleBarSeries)plotModel.Series[0]).FillColor = OxyColors.Orange;

                        //DrawGraph((x) => (x.OPR + x.WPR) / (x.PRESS - x.Hw - m_welldata.WBHP), CPI_LIST);
                        break;
                }
            }
        }

        double[] CPI_LIST = null;
        double[] CPI_INIT_LIST = null;
        double[] LIQ_LIST = null;
        double[] WATER_LIST = null;
        double[] OIL_LIST = null;
        double[] WCUT_LIST = null;
        double[] PDD_LIST = null;
        double[] Q_POT_LIST = null;

        int LUMPNUM = 0;
        int[] LUMPED_ZONE = null;
        double[] LUMP_M_LIQ_LIST = null;
        double[] LUMP_M_WATER_LIST = null;
        double[] LUMP_M_OIL_LIST = null;
        double[] LUMP_M_WCUT_LIST = null;

        double[] LUMP_LIQ_LIST = null;
        double[] LUMP_WATER_LIST = null;
        double[] LUMP_OIL_LIST = null;
        double[] LUMP_WCUT_LIST = null;


        double PI = 0;
        double Q_POT = 0;
        void UpdateModifications()
        {
            CPI_LIST = new double[m_welldata.COMPLNUM];
            LIQ_LIST = new double[m_welldata.COMPLNUM];
            WATER_LIST = new double[m_welldata.COMPLNUM];
            OIL_LIST = new double[m_welldata.COMPLNUM];
            WCUT_LIST = new double[m_welldata.COMPLNUM];
            PDD_LIST = new double[m_welldata.COMPLNUM];
            CPI_INIT_LIST = new double[m_welldata.COMPLNUM];
            Q_POT_LIST = new double[m_welldata.COMPLNUM];

            PI = 0;
            Q_POT = 0;

            for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
            {
                if (m_welldata.COMPLS[iw].STATUS == 1)
                {
                    double CPI =
                        (m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR) /
                        (m_welldata.COMPLS[iw].PRESS - m_welldata.WBHP - m_welldata.COMPLS[iw].Hw);

                    CPI_INIT_LIST[iw] = CPI;

                    CPI_LIST[iw] = CPI * m_welldata.COMPLS[iw].WPIMULT;
                    PI = PI + CPI_LIST[iw];
                    Q_POT_LIST[iw] = CPI_LIST[iw] * (m_welldata.COMPLS[iw].PRESS - m_welldata.COMPLS[iw].Hw);
                    Q_POT = Q_POT + Q_POT_LIST[iw];
                }
            }

            double BHP = (Q_POT - m_welldata.WLPR) / PI;
            double LPR = 0;
            double WPR = 0;

            for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
            {
                if (m_welldata.COMPLS[iw].STATUS == 1)
                {
                    LIQ_LIST[iw] = CPI_LIST[iw] * (m_welldata.COMPLS[iw].PRESS - m_welldata.COMPLS[iw].Hw - BHP);
                    WCUT_LIST[iw] = m_welldata.COMPLS[iw].WPR / (m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR);
                    WATER_LIST[iw] = LIQ_LIST[iw] * WCUT_LIST[iw];
                    OIL_LIST[iw] = LIQ_LIST[iw] - WATER_LIST[iw];

                    PDD_LIST[iw] = m_welldata.COMPLS[iw].PRESS - m_welldata.COMPLS[iw].Hw - BHP;

                    LPR = LPR + LIQ_LIST[iw];
                    WPR = WPR + WATER_LIST[iw];
                }
            }

            StringBuilder info = new StringBuilder("BHP/BHPH" + '\n' + BHP.ToString("N2") + "/" + m_welldata.WBHPH + '\n' +
                "WCUT/WCUTH" + '\n' + (WPR / LPR).ToString("N3") + "/" + (m_welldata.WWPRH / m_welldata.WLPRH).ToString("N3") + "\n" +
                "OPR/OPRH" + '\n' + (LPR - WPR).ToString("N1") + "/" + (m_welldata.WOPRH).ToString("N1") + '\n');

            if (IsLumped)
            {
                LUMPED_ZONE = m_welldata.COMPLS.Select(c => c.LUMPNUM).Distinct().ToArray();
                LUMPNUM = LUMPED_ZONE.Length;

                LUMP_LIQ_LIST = new double[LUMPNUM];
                LUMP_WATER_LIST = new double[LUMPNUM];
                LUMP_OIL_LIST = new double[LUMPNUM];
                LUMP_WCUT_LIST = new double[LUMPNUM];

                LUMP_M_LIQ_LIST = new double[LUMPNUM];
                LUMP_M_WATER_LIST = new double[LUMPNUM];
                LUMP_M_OIL_LIST = new double[LUMPNUM];
                LUMP_M_WCUT_LIST = new double[LUMPNUM];

                for (int iw = 0; iw < LUMPNUM; ++iw)
                {
                    var wpr = m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Sum(c => c.WPR);
                    var opr = m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Sum(c => c.OPR);
                    var gpr = m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Sum(c => c.GPR);

                    double oprm = 0;
                    double wprm = 0;

                    for (int C = 0; C < m_welldata.COMPLS.Count; ++C)
                    {
                        if (m_welldata.COMPLS[C].LUMPNUM == LUMPED_ZONE[iw])
                        {
                            oprm = oprm + OIL_LIST[C];
                            wprm = wprm + WATER_LIST[C];
                        }
                    }

                    LUMP_M_LIQ_LIST[iw] = oprm + wprm;
                    LUMP_M_OIL_LIST[iw] = oprm;
                    LUMP_M_WATER_LIST[iw] = wprm;
                    LUMP_M_WCUT_LIST[iw] = (wprm / (oprm + wprm));

                    LUMP_LIQ_LIST[iw] = opr + wpr;
                    LUMP_OIL_LIST[iw] = opr;
                    LUMP_WATER_LIST[iw] = wpr;
                    LUMP_WCUT_LIST[iw] = (wpr / (opr + wpr));

                    /*
                    info.Append('\n' + "LUMP " + lumped_zones[iw] + '\n');
                    info.Append("LPR/LPRM" + '\n' + (opr + wpr).ToString("N2") +"/" + (oprm + wprm).ToString("N2") + '\n');
                    info.Append("OPR/OPRM" + '\n' + (opr).ToString("N2") + "/" + oprm.ToString("N2") + '\n');
                    info.Append("WCUT/WCUTM" + '\n' + (wpr/(opr + wpr)).ToString("N3") + "/" + (wprm/(oprm+wprm)).ToString("N3") + '\n');
                    */
                }

            }

            plotModel.Legends[0].LegendFontSize = double.NaN;
            plotModel.Legends[0].LegendTitle = info.ToString();

            //
        }

        void DrawLumpGraph(double[] lump, double[] modi)
        {
            double top = 0;
            double bottom = 0;

            switch (boxDepthMode.SelectedIndex)
            {
                case 0: // Depth
                    plotModel.Axes[1].Title = "Depth, m";
                    break;
                case 1: // // K-value
                    plotModel.Axes[1].Title = "K";
                    break;
            }

            for (int iw = 0; iw < LUMPNUM; ++iw)
            {
                if (!Double.IsNaN(lump[iw]))
                {
                    switch (boxDepthMode.SelectedIndex)
                    {
                        case 0: // Depth 
                            double depth = m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Average(c => c.Depth);

                            top = m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Average(c => c.Cell.TSE.Z);
                            bottom = m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Average(c => c.Cell.BSE.Z);
                            break;
                        case 1: // K-value
                            top = (m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Min(c => c.K) + 1) - 0.5;
                            bottom = (m_welldata.COMPLS.Where(c => c.LUMPNUM == LUMPED_ZONE[iw]).Max(c => c.K) + 1) + 0.5;
                            break;
                    }

                    ((RectangleBarSeries)plotModel.Series[0]).Items.Add(new RectangleBarItem(0, top, lump[iw], bottom));
                    ((RectangleBarSeries)plotModel.Series[1]).Items.Add(new RectangleBarItem(0, top, modi[iw], bottom));

                    if (checkShowModiValue.Checked)
                        ((RectangleBarSeries)plotModel.Series[1]).Items.Last().Title = modi[iw].ToString("N2");

                    if (iw == SelectedCell)
                        ((RectangleBarSeries)plotModel.Series[2]).Items.Add(new RectangleBarItem(0, top, modi[iw], bottom));
                }
            }
            plotModel.InvalidatePlot(true);
        }

        void DrawGraph(Func<ECL.COMPLDATA, double> get_value, double[] modi)
        {
            double top = 0;
            double bottom = 0;

            switch (boxDepthMode.SelectedIndex)
            {
                case 0: // Depth
                    plotModel.Axes[1].Title = "Depth, m";
                    break;
                case 1: // // K-value
                    plotModel.Axes[1].Title = "K";
                    break;
            }

            for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
            {
                double value = get_value(m_welldata.COMPLS[iw]);

                if (!Double.IsNaN(value))
                {
                    switch (boxDepthMode.SelectedIndex)
                    {
                        case 0: // Depth 
                            top = (m_welldata.COMPLS[iw].Cell.TSE.Z + m_welldata.COMPLS[iw].Cell.TSW.Z + m_welldata.COMPLS[iw].Cell.TNE.Z + m_welldata.COMPLS[iw].Cell.TNW.Z) / 4;
                            bottom = (m_welldata.COMPLS[iw].Cell.BSE.Z + m_welldata.COMPLS[iw].Cell.BSW.Z + m_welldata.COMPLS[iw].Cell.BNE.Z + m_welldata.COMPLS[iw].Cell.BNW.Z) / 4;
                            break;
                        case 1: // K-value
                            top = (m_welldata.COMPLS[iw].K + 1) - 0.5;
                            bottom = (m_welldata.COMPLS[iw].K + 1) + 0.5;
                            break;
                    }

                    ((RectangleBarSeries)plotModel.Series[0]).Items.Add(new RectangleBarItem(0, top, value, bottom));
                    ((RectangleBarSeries)plotModel.Series[1]).Items.Add(new RectangleBarItem(0, top, modi[iw], bottom));

                    if (checkShowModiValue.Checked)
                        ((RectangleBarSeries)plotModel.Series[1]).Items.Last().Title = modi[iw].ToString("N2");

                    if (iw == SelectedCell)
                        ((RectangleBarSeries)plotModel.Series[2]).Items.Add(new RectangleBarItem(0, top, modi[iw], bottom));
                }
            }

            plotModel.InvalidatePlot(true);
        }

        bool editVisualData = false;
        public SubWellModel(Form2DModelStyle Style)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, gridData, new object[] { true });

            plotModel = new PlotModel
            {
                DefaultFont = "Segoe UI",
                DefaultFontSize = 10,
            };

            plotModel.Legends.Add(new OxyPlot.Legends.Legend {
                LegendPosition = LegendPosition.RightTop,
                LegendPlacement = LegendPlacement.Outside,
                LegendFontSize = 8,
                LegendBackground = OxyColors.White
            });

            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Title = "Value",
                Position = AxisPosition.Bottom,
                StringFormat = "N1",
                MajorGridlineStyle = LineStyle.Dash
            });


            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Title = "Depth",
                Position = OxyPlot.Axes.AxisPosition.Left,
                EndPosition = 0,
                StartPosition = 1,
                AxisTitleDistance = 8,
                MajorGridlineStyle = LineStyle.Dash
            });


            plotView.Model = plotModel;

            editVisualData = true;

            boxChartMode.SelectedIndex = 0;
            boxDepthMode.SelectedIndex = 0;
            boxLumping.SelectedIndex = 0;

            editVisualData = false;
        }

        private void SubFormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void boxChartMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editVisualData) return;
            UpdateForm();
        }

        private void listWells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listWells.SelectedItem == null) return;

            UpdateData(listWells.SelectedItem, e);

            UpdateModifications();
            UpdateForm();
            UpdateCharts();
        }

        private void boxDepthMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editVisualData) return;
            UpdateForm();
        }

        private void gridData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int modi_column = 8;
            int id_column = 9;
            int lump_column = 4;

            // Check value modi

            string modi = gridData.Rows[e.RowIndex].Cells[modi_column].Value.ToString();
            int index = Convert.ToInt32(gridData.Rows[e.RowIndex].Cells[id_column].Value);
            int lump = Convert.ToInt32(gridData.Rows[e.RowIndex].Cells[lump_column].Value);

            float modi_value;

            if (Single.TryParse(modi, out modi_value))
            {
                if (IsLumped == false)
                {
                    m_welldata.COMPLS[index].WPIMULT = modi_value;
                }
                else
                {
                    for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                        if (m_welldata.COMPLS[iw].LUMPNUM == lump) m_welldata.COMPLS[iw].WPIMULT = modi_value;
                }

                UpdateModifications();
                UpdateCharts();
            }
            else
            {
                if (IsLumped == false)
                {
                    gridData.Rows[e.RowIndex].Cells[modi_column].Value = m_welldata.COMPLS[index].WPIMULT;
                }
                else
                {
                    gridData.Rows[e.RowIndex].Cells[modi_column].Value = 1;
                }
            }
        }


        int index_nearest_bar = -1;

        private void SubWellModel_MouseUp(object sender, OxyMouseEventArgs e)
        {
            index_nearest_bar = -1;
            e.Handled = true;
        }

        void CalculateMultByLiquid(int index, double lpr)
        {
            int modi_column = 8;
            int id_column = 9;

            double Q_POT_W = Q_POT - Q_POT_LIST[index];
            double PI_W = PI - CPI_INIT_LIST[index];

            double CPI = CPI_INIT_LIST[index];
            double  C = (m_welldata.COMPLS[index].PRESS - m_welldata.COMPLS[index].Hw) - (CPI * m_welldata.COMPLS[index].PRESS + Q_POT_W - m_welldata.WLPR) / (PI_W + CPI);
            double CN = lpr / C;
            double eps = 1;

            while (eps > 0.000001)
            {
                C = lpr / ((m_welldata.COMPLS[index].PRESS - m_welldata.COMPLS[index].Hw) - (CN * m_welldata.COMPLS[index].PRESS + Q_POT_W - m_welldata.WLPR) / (PI_W + CN));
                eps = Math.Abs(C - CN);
                CN = C;
            }

            double mult = (CN / CPI);

            if (mult < 0) mult = 0.1;

            for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
            {
                int index_grid = Convert.ToInt32(gridData.Rows[iw].Cells[id_column].Value);

                if (index == index_grid)
                {
                    gridData.Rows[iw].Cells[modi_column].Value = mult;
                    m_welldata.COMPLS[index_grid].WPIMULT = (float)mult;
                    UpdateModifications();
                    UpdateCharts();
                    break;
                }
            }
        }

        private void SubWellModel_MouseMove(object sender, OxyMouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(index_nearest_bar);

            if (index_nearest_bar >= 0)
            {
                double X = ((RectangleBarSeries)sender).InverseTransform(e.Position).X;
                ((RectangleBarSeries)sender).Items[index_nearest_bar].X1 = X;
                
                //CalculateMultByLiquid(index_nearest_bar, X);

                plotModel.InvalidatePlot(true);
                e.Handled = true;
            }
        }

        private void SubWellModel_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            if (e.ChangedButton == OxyMouseButton.Left)
            {
                index_nearest_bar = (int)Math.Round(e.HitTestResult.Index);
                e.Handled = true;
            }
        }

        private void boxLumping_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (editVisualData) return;
            if (m_welldata == null) return;

            if (boxLumping.SelectedIndex == 1) // BY K-VALUE
            {
                IsLumped = true;

                for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                {
                    m_welldata.COMPLS[iw].LUMPNUM = m_welldata.COMPLS[iw].K;
                }
                UpdateModifications();
            }

            if (boxLumping.SelectedIndex > 1)
            {
                IsLumped = true;
                UpdateLumpingMethod(sender, e);
                UpdateModifications();
            }

            if (boxLumping.SelectedIndex == 0)
            {
                IsLumped = false;
            }

            UpdateForm();
        }

 
        int SelectedCell = -1;
        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (editVisualData) return;

            SelectedCell = Convert.ToInt32(gridData.Rows[e.RowIndex].Cells[9].Value);
            UpdateCharts();
        }

        private void checkShowModiValue_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCharts();
        }
    }
}
