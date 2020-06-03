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

namespace mview
{
    public partial class SubWellModel : Form
    {
        public event EventHandler UpdateData;

        readonly PlotModel plotModel = null;
        

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
            gridCommon.Rows.Add("LPR/LPRH", m_welldata.WLPR.ToString("N3") + " / " + m_welldata.WLPRH.ToString());
            gridCommon.Rows.Add("OPR/OPRH", m_welldata.WOPR.ToString("N3") + " / " + m_welldata.WOPRH.ToString());
            gridCommon.Rows.Add("BHP/BHPH", m_welldata.WBHP.ToString("N3") + " / " + m_welldata.WBHPH.ToString());

            gridData.Rows.Clear();

            for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
            {
                int row = gridData.Rows.Add();
                gridData[0, row].Value = m_welldata.COMPLS[iw].I + 1;
                gridData[1, row].Value = m_welldata.COMPLS[iw].J + 1;
                gridData[2, row].Value = m_welldata.COMPLS[iw].K + 1;
                gridData[3, row].Value = m_welldata.COMPLS[iw].Depth;
                gridData[4, row].Value = m_welldata.COMPLS[iw].kh;
                gridData[5, row].Value = m_welldata.COMPLS[iw].PRESS;
                gridData[6, row].Value = m_welldata.COMPLS[iw].CF;
                gridData[7, row].Value = m_welldata.COMPLS[iw].Complex;
                gridData[8, row].Value = m_welldata.COMPLS[iw].s38;
                gridData[9, row].Value = m_welldata.COMPLS[iw].Hw;
            }

            switch (boxChartMode.SelectedIndex)
            {
                case 0:
                    plotModel.Axes[0].Title = "P, bar";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Axes[1].AbsoluteMinimum = 0;

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new LineSeries
                    {
                        LineStyle = LineStyle.None,
                        MarkerType = MarkerType.Circle,
                        MarkerStroke = Color.Black.ToOxyColor(),
                        MarkerStrokeThickness = 1,
                        MarkerFill = Color.White.ToOxyColor(),
                        MarkerSize = 4,
                        Title = "PRESS"
                    });

                    plotModel.Series.Add(new LineSeries
                    {
                        LineStyle = LineStyle.None,
                        MarkerType = MarkerType.Circle,
                        MarkerStroke = Color.Black.ToOxyColor(),
                        MarkerStrokeThickness = 1,
                        MarkerFill = Color.Orange.ToOxyColor(),
                        MarkerSize = 4,
                        Title = "BHP"
                    });


                    for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                    {
                        ((LineSeries)plotModel.Series[0]).Points.Add(new DataPoint(m_welldata.COMPLS[iw].PRESS, m_welldata.COMPLS[iw].Depth));
                        ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(m_welldata.WBHP + m_welldata.COMPLS[iw].Hw, m_welldata.COMPLS[iw].Depth));
                    }
                    plotModel.InvalidatePlot(true);
                    break;

                case 1:
                    plotModel.Axes[0].Title = "P, bar";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new LineSeries
                    {
                        LineStyle = LineStyle.None,
                        MarkerType = MarkerType.Circle,
                        MarkerStroke = Color.Black.ToOxyColor(),
                        MarkerStrokeThickness = 1,
                        MarkerFill = Color.White.ToOxyColor(),
                        MarkerSize = 4,
                        Title = "PRESS"
                    });

                    plotModel.Series.Add(new LineSeries
                    {
                        LineStyle = LineStyle.None,
                        MarkerType = MarkerType.Circle,
                        MarkerStroke = Color.Black.ToOxyColor(),
                        MarkerStrokeThickness = 1,
                        MarkerFill = Color.Orange.ToOxyColor(),
                        MarkerSize = 4,
                        Title = "BHP"
                    });

                    for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                    {
                        ((LineSeries)plotModel.Series[0]).Points.Add(new DataPoint(m_welldata.COMPLS[iw].PRESS - m_welldata.COMPLS[iw].Hw, m_welldata.COMPLS[iw].Depth));
                        ((LineSeries)plotModel.Series[1]).Points.Add(new DataPoint(m_welldata.WBHP, m_welldata.COMPLS[iw].Depth));
                    }
                    plotModel.InvalidatePlot(true);
                    break;
                case 2:
                    plotModel.Axes[0].Title = "Liquid, m3/day";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.Aqua
                        /*
                        LineStyle = LineStyle.None,
                        MarkerType = MarkerType.Circle,
                        MarkerStroke = Color.Black.ToOxyColor(),
                        MarkerStrokeThickness = 2,
                        MarkerFill = Color.White.ToOxyColor(),
                        MarkerSize = 4
                        */
                    });

                    for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                    {
                        ((RectangleBarSeries)plotModel.Series[0]).Items.Add(
                            new RectangleBarItem(0, m_welldata.COMPLS[iw].Depth - 0.2, m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR, m_welldata.COMPLS[iw].Depth + 0.2));
                    }
                    
                    plotModel.InvalidatePlot(true);
                    
                    break;

                case 3: // Oil production
                    plotModel.Axes[0].Title = "Oil, m3/day";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.Orange
                    });

                    for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                    {
                        ((RectangleBarSeries)plotModel.Series[0]).Items.Add(
    new RectangleBarItem(0, m_welldata.COMPLS[iw].Depth - 0.2, m_welldata.COMPLS[iw].OPR, m_welldata.COMPLS[iw].Depth + 0.2));
                    }
                    plotModel.InvalidatePlot(true);
                    break;
                case 4: // Water production
                    plotModel.Axes[0].Title = "Water, m3/day";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.BlueViolet
                    });

                    for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                    {
                        ((RectangleBarSeries)plotModel.Series[0]).Items.Add(
                        new RectangleBarItem(0, m_welldata.COMPLS[iw].Depth - 0.2, m_welldata.COMPLS[iw].WPR, m_welldata.COMPLS[iw].Depth + 0.2));
                        //
                    }
                    plotModel.InvalidatePlot(true);
                    break;
                case 5: // Water Cut
                    plotModel.Axes[0].Title = "Water Cut";
                    plotModel.Axes[1].Title = "Depth, m";

                    plotModel.Series.Clear();
                    plotModel.Series.Add(new RectangleBarSeries
                    {
                        StrokeThickness = 1,
                        StrokeColor = OxyColors.Black,
                        FillColor = OxyColors.CadetBlue
                    });

                    for (int iw = 0; iw < m_welldata.COMPLNUM; ++iw)
                    {
                        ((RectangleBarSeries)plotModel.Series[0]).Items.Add(
new RectangleBarItem(0, m_welldata.COMPLS[iw].Depth - 0.2, m_welldata.COMPLS[iw].WPR / (m_welldata.COMPLS[iw].WPR + m_welldata.COMPLS[iw].OPR), m_welldata.COMPLS[iw].Depth + 0.2));
                    }
                    plotModel.InvalidatePlot(true);
                    break;
            }
        }

        public SubWellModel(Form2DModelStyle Style)
        {
            InitializeComponent();

            typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,  null, gridData, new object[] { true });
            typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, gridCommon, new object[] { true });

            plotModel = new PlotModel
            {
                DefaultFont = "Segoe UI",
                DefaultFontSize = 11,
            };

            plotModel.Legends.Add(new Legend {LegendPosition = LegendPosition.RightTop });


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
                AxisTitleDistance = 8,
                MajorGridlineStyle = LineStyle.Dash
            });

            plotView.Model = plotModel ;
        }

        private void SubFormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void boxChartMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void listWells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listWells.SelectedItem == null) return;
            UpdateData(sender, e);

            UpdateForm();
        }
    }
}
