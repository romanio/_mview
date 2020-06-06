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

namespace mview
{
    public partial class SubWellModel : Form
    {
        public event EventHandler UpdateData;

        readonly PlotModel plotModel = null;
        readonly PlotModel plotModelModi = null;

        ECL.WELLDATA m_welldata = null;

        public ECL.WELLDATA WellData
        {
            set
            {
                m_welldata = value;
                UpdateForm();
            }
        }

        void UpdateForm()
        {
            gridCommon.Rows.Clear();

            gridCommon.Rows.Add("STATUS", m_welldata.WELLSTATUS);
            gridCommon.Rows.Add("TYPE", m_welldata.WELLTYPE);
            gridCommon.Rows.Add("GROUP", m_welldata.GROUPNUM);
            gridCommon.Rows.Add("REF DEPTH", m_welldata.REF_DEPTH);
            gridCommon.Rows.Add("WPI", m_welldata.WPI);
            gridCommon.Rows.Add("WEFA", m_welldata.WEFA);
            gridCommon.Rows.Add("LPR/LPRH", m_welldata.WLPR.ToString("N2") + " / " + m_welldata.WLPRH.ToString());
            gridCommon.Rows.Add("OPR/OPRH", m_welldata.WOPR.ToString("N2") + " / " + m_welldata.WOPRH.ToString());
            gridCommon.Rows.Add("BHP/BHPH", m_welldata.WBHP.ToString("N2") + " / " + m_welldata.WBHPH.ToString());

            gridData.Rows.Clear();

            for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
            {
                int row = gridData.Rows.Add();
                gridData[0, row].Value = m_welldata.COMPLS[iw].I + 1;
                gridData[1, row].Value = m_welldata.COMPLS[iw].J + 1;
                gridData[2, row].Value = m_welldata.COMPLS[iw].K + 1;
                gridData[3, row].Value = m_welldata.COMPLS[iw].Depth;

                gridData[4, row].Value = m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR;
                gridData[5, row].Value = m_welldata.COMPLS[iw].WPR / (m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR);
                gridData[6, row].Value = m_welldata.COMPLS[iw].GPR / m_welldata.COMPLS[iw].OPR;

                gridData[7, row].Value = 1;
                gridData[8, row].Value = iw;
            }

            plotModelModi.Series.Clear();

            switch (boxChartMode.SelectedIndex)
            {
                case 0: // Pressure drop 

                    plotModel.Axes[0].Title = "(P - Pw), bar";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.OrangeRed
                    });

                    DrawGraph((x) => x.PRESS - x.Hw - m_welldata.WBHP);

                    break;

                case 1: // Liquid production
                    plotModel.Axes[0].Title = "Liquid, m3/day";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.Aqua
                    });

                    DrawGraph((x) => x.WPR + x.OPR);

                    break;

                case 2: // Oil production
                    plotModel.Axes[0].Title = "Oil, m3/day";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.Orange
                    });

                    DrawGraph((x) => x.OPR);

                    break;

                case 3: // Water production
                    plotModel.Axes[0].Title = "Water, m3/day";


                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.BlueViolet
                    });

                    DrawGraph((x) => x.WPR);

                    break;

                case 4: // Water Cut
                    plotModel.Axes[0].Title = "Water Cut";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.CadetBlue
                    });

                    DrawGraph((x) => x.WPR / (x.WPR + x.OPR));

                    break;

                case 5: // Connection Factor
                    plotModel.Axes[0].Title = "CF";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.Orange
                    });

                    DrawGraph((x) => x.CF);

                    break;
            }
        }

        void DrawGraph(Func<ECL.COMPLDATA, double> get_value)
        {
            double top, bottom;
            plotModel.Annotations.Clear();


            switch (boxDepthMode.SelectedIndex)
            {
                case 0: // Depth
                    plotModel.Axes[1].Title = "Depth, m";
                    break;
                case 1: // // K-value
                    plotModel.Axes[1].Title = "K";
                    break;
                case 2: // // Cell
                    plotModel.Axes[1].Title = "Cell";
                    break;
            }

            if (boxDepthMode.SelectedIndex == 0 || boxDepthMode.SelectedIndex == 1)
            {
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
                                ((RectangleBarSeries)plotModel.Series[0]).Items.Add(new RectangleBarItem(0, top, value, bottom));
                                break;
                            case 1: // K-value
                                top = (m_welldata.COMPLS[iw].K + 1) - 0.5;
                                bottom = (m_welldata.COMPLS[iw].K + 1) + 0.5;
                                ((RectangleBarSeries)plotModel.Series[0]).Items.Add(new RectangleBarItem(0, top, value, bottom));
                                break;
                        }
                    }
                }
            }

            if (boxDepthMode.SelectedIndex == 2) // Cell mode
            {
                var sorted_comp = m_welldata.COMPLS.OrderBy(c => c.K).ToArray();
                for (int iw = 0; iw < sorted_comp.Length; ++iw)
                {
                    double value = get_value(sorted_comp[iw]);

                    if (!Double.IsNaN(value))
                    {
                        top = (iw + 1) - 0.5;
                        bottom = (iw + 1) + 0.5;

                        ((RectangleBarSeries)plotModel.Series[0]).Items.Add(new RectangleBarItem(0, top, value, bottom));

                        // Точки на графике

                        plotModel.Annotations.Add(new OxyPlot.Annotations.TextAnnotation
                        {
                            FontSize = 10,
                            Text = "[" + (sorted_comp[iw].I + 1) + "; " + (sorted_comp[iw].J + 1) + "; " + (sorted_comp[iw].K + 1) + "]",
                            StrokeThickness = 0,
                            TextPosition = new DataPoint(value * 1.1, (iw + 1) - 0.5)
                        });
                    }
                }
            }

            plotModel.InvalidatePlot(true);
        }

        bool editVisualData = false;
        public SubWellModel(Form2DModelStyle Style)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, gridData, new object[] { true });
            typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, gridCommon, new object[] { true });

            plotModel = new PlotModel
            {
                DefaultFont = "Segoe UI",
                DefaultFontSize = 10,
            };

            plotModelModi = new PlotModel
            {
                DefaultFont = "Segoe UI",
                DefaultFontSize = 10,
            };

            plotModel.Legends.Add(new OxyPlot.Legends.Legend { LegendPosition = LegendPosition.RightTop, LegendFontSize = 8 });
            plotModelModi.Legends.Add(new OxyPlot.Legends.Legend { LegendPosition = LegendPosition.RightTop, LegendFontSize = 8 });

            plotModelModi.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Title = "Value",
                Position = AxisPosition.Bottom,
                StringFormat = "N1",
                MajorGridlineStyle = LineStyle.Dash
            });

            plotModelModi.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Title = "Depth",
                Position = OxyPlot.Axes.AxisPosition.Left,
                EndPosition = 0,
                StartPosition = 1,
                AxisTitleDistance = 8,
                MajorGridlineStyle = LineStyle.Dash
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
            plotViewModi.Model = plotModelModi;

            editVisualData = true;

            boxChartMode.SelectedIndex = 0;
            boxDepthMode.SelectedIndex = 0;

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
            UpdateData(sender, e);
            UpdateForm();

            if (m_welldata.COMPLNUM > 0)
            {
                gridData_CellEndEdit(null, new DataGridViewCellEventArgs(9, 0));
            }
        }

        private void boxDepthMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editVisualData) return;
            UpdateForm();
        }

        double[] modi_list = null;
        double[] cpi_list = null;
        double[] q_pot_list = null;
        double[] liq_list = null; 
        double[] water_list = null;
        double PI = 0;
        double Q_POT = 0;
        private void gridData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Check value modi
            string modi = gridData.Rows[e.RowIndex].Cells[7].Value.ToString();
            double modi_value;

            if (Double.TryParse(modi, out modi_value))
            {
                plotModelModi.Series.Clear();
                plotModelModi.Series.Add(new RectangleBarSeries
                {
                    StrokeThickness = 1,
                    StrokeColor = OxyColors.Black,
                    FillColor = OxyColors.AliceBlue,
                    Title = "LPR sim"
                }); ;

                plotModelModi.Series.Add(new RectangleBarSeries
                {
                    StrokeThickness = 1,
                    StrokeColor = OxyColors.Black,
                    FillColor = OxyColors.BlueViolet,
                    Title = "LPR est"

                }); ;

                //plotModelModi.Series[1].MouseDown += SubWellModel_MouseDown;
                //plotModelModi.Series[1].MouseMove += SubWellModel_MouseMove;
                //plotModelModi.Series[1].MouseUp += SubWellModel_MouseUp;

                // Calculation

                modi_list = new double[m_welldata.COMPLNUM];
                cpi_list = new double[m_welldata.COMPLNUM];
                q_pot_list = new double[m_welldata.COMPLNUM];
                liq_list = new double[m_welldata.COMPLNUM];
                water_list = new double[m_welldata.COMPLNUM];

                int index;

                for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                {
                    index = Convert.ToInt32(gridData.Rows[iw].Cells[8].Value);
                    modi_list[index] = Convert.ToDouble(gridData.Rows[iw].Cells[7].Value);
                }

                 PI = 0;
                 double CPI = 0;

                Q_POT = 0;
                double CQ_POT = 0;
                double BHP;

                for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                {
                    CPI =
                    (m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR) /
                    (m_welldata.COMPLS[iw].PRESS - m_welldata.WBHP - m_welldata.COMPLS[iw].Hw);

                    cpi_list[iw] = CPI;

                    CQ_POT = CPI * modi_list[iw] * (m_welldata.COMPLS[iw].PRESS - m_welldata.COMPLS[iw].Hw);

                    q_pot_list[iw] = CQ_POT;

                    PI = PI + CPI * modi_list[iw];

                    Q_POT = Q_POT + CPI * modi_list[iw] * (m_welldata.COMPLS[iw].PRESS - m_welldata.COMPLS[iw].Hw);
                }

                BHP = (Q_POT - m_welldata.WLPR) / PI;



                double LPR = 0;
                double WPR = 0;
                   

                for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                {
                    liq_list[iw] = cpi_list[iw] * modi_list[iw] * (m_welldata.COMPLS[iw].PRESS - m_welldata.COMPLS[iw].Hw - BHP);
                    water_list[iw] = liq_list[iw] * m_welldata.COMPLS[iw].WPR / (m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR);

                    LPR = LPR + liq_list[iw];
                    WPR = WPR + water_list[iw];
                }

                plotModelModi.Legends[0].LegendFontSize = double.NaN;
                plotModelModi.Legends[0].LegendTitle =
                    "BHP/BHPH" + '\n' + BHP.ToString("N2") + "/" + m_welldata.WBHPH + '\n' +
                    "WCUT/WCUTH" + '\n' + (WPR / LPR).ToString("N3") + "/" + (m_welldata.WWPRH / m_welldata.WLPRH).ToString("N3") + "\n" +
                    "OPR/OPRH" + '\n' + (LPR - WPR).ToString("N1") + "/" + (m_welldata.WOPRH).ToString("N1");

                //

                double top, bottom, value;

                for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                {
                    value = m_welldata.COMPLS[iw].OPR + m_welldata.COMPLS[iw].WPR;
                    top = (m_welldata.COMPLS[iw].Cell.TSE.Z + m_welldata.COMPLS[iw].Cell.TSW.Z + m_welldata.COMPLS[iw].Cell.TNE.Z + m_welldata.COMPLS[iw].Cell.TNW.Z) / 4;
                    bottom = (m_welldata.COMPLS[iw].Cell.BSE.Z + m_welldata.COMPLS[iw].Cell.BSW.Z + m_welldata.COMPLS[iw].Cell.BNE.Z + m_welldata.COMPLS[iw].Cell.BNW.Z) / 4;
         
                    ((RectangleBarSeries)plotModelModi.Series[0]).Items.Add(new RectangleBarItem(0, top, value, bottom));
                    ((RectangleBarSeries)plotModelModi.Series[1]).Items.Add(new RectangleBarItem(0, top, liq_list[iw], bottom));
                }

                plotModelModi.InvalidatePlot(true);
            }
            else
            {
                gridData.Rows[e.RowIndex].Cells[7].Value = 1;
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
            double Q_POT_W = Q_POT - q_pot_list[index];
            double PI_W = PI - cpi_list[index];

            double CPI = cpi_list[index];
            double C = (m_welldata.COMPLS[index].PRESS - m_welldata.COMPLS[index].Hw) - (CPI * m_welldata.COMPLS[index].PRESS + Q_POT_W - m_welldata.WLPR) / (PI_W + CPI);
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
                int index_grid = Convert.ToInt32(gridData.Rows[iw].Cells[10].Value);

                if (index == index_grid)
                {
                    gridData.Rows[iw].Cells[9].Value = mult;

                    gridData_CellEndEdit(null, new DataGridViewCellEventArgs(9, iw));                    
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
                System.Diagnostics.Debug.WriteLine("X = " + X + " X0 = " + ((RectangleBarSeries)sender).Items[index_nearest_bar].X0);
                ((RectangleBarSeries)sender).Items[index_nearest_bar].X1 = X;
                
                CalculateMultByLiquid(index_nearest_bar, X);

                plotModelModi.InvalidatePlot(true);
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
    }
}
