using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using System.IO;

namespace mview
{
    public enum GroupMode
    {
        Normal,
        Average,
        Sum
    }

    public class SeriesStyle
    {
        public string Name;
        public System.Drawing.Color LineColor;
        public System.Drawing.Color MarkerColor;
        public System.Drawing.Color MarkerFillColor;
        public int MarkerSize;
        public int LineWidth;
        public bool LineSmooth;
        public MarkerType MarkerType;
        public LineStyle LineStyle;
        public GroupMode GroupMode;
    }

    public class ChartController
    {
        List<SeriesStyle> listSeriesStyle = new List<SeriesStyle>();

        public LineStyle AxisXStyle = LineStyle.None;
        public int AxisXWidth = 1;
        public System.Drawing.Color AxisXColor;

        public LineStyle AxisYStyle = LineStyle.None;
        public int AxisYWidth = 1;
        public System.Drawing.Color AxisYColor;

       
        public OxyPlot.Legends.LegendPosition LegendPosition = OxyPlot.Legends.LegendPosition.TopRight;

        public string AxisX = "TIME";
        public string AxisY = "Normal";

        public void UpdateStyle(SeriesStyle style)
        {
            int index = GetIndex(style.Name);
            if (index == -1)
                listSeriesStyle.Add(style);
            else
            {
                listSeriesStyle[index] = style;
            }
        }

        public void SaveSettings()
        {
            using (TextWriter text = new StreamWriter(System.Windows.Forms.Application.StartupPath + "/mview.ini", false))
            {
                // Сохраним настройки графика

                text.WriteLine(AxisXStyle);
                text.WriteLine(AxisXWidth);
                text.WriteLine(AxisXColor.ToArgb());

                text.WriteLine(AxisYStyle);
                text.WriteLine(AxisYWidth);
                text.WriteLine(AxisYColor.ToArgb());

                text.WriteLine(LegendPosition);

                // Сохраним настройки линий графика

                text.WriteLine(listSeriesStyle.Count);

                for (int iw = 0; iw < listSeriesStyle.Count; ++iw)
                {
                    text.WriteLine(listSeriesStyle[iw].Name);

                    text.WriteLine(listSeriesStyle[iw].LineColor.ToArgb());
                    text.WriteLine(listSeriesStyle[iw].MarkerColor.ToArgb());
                    text.WriteLine(listSeriesStyle[iw].MarkerFillColor.ToArgb());

                    text.WriteLine(listSeriesStyle[iw].MarkerSize);
                    text.WriteLine(listSeriesStyle[iw].LineWidth);
                    text.WriteLine(listSeriesStyle[iw].LineSmooth);

                    text.WriteLine(listSeriesStyle[iw].MarkerType);
                    text.WriteLine(listSeriesStyle[iw].LineStyle);
                    text.WriteLine(listSeriesStyle[iw].GroupMode);
                }
                text.Close();
            }
        }

        public void LoadSettings()
        {
            string filename = System.Windows.Forms.Application.StartupPath + "/mview.ini";
            if (System.IO.File.Exists(filename))
            {
                using (TextReader text = new StreamReader(filename))
                {
                    AxisXStyle = (LineStyle)Enum.Parse(typeof(LineStyle), text.ReadLine(), true);
                    AxisXWidth = Int32.Parse(text.ReadLine());
                    AxisXColor = System.Drawing.Color.FromArgb(Int32.Parse(text.ReadLine()));

                    AxisYStyle = (LineStyle)Enum.Parse(typeof(LineStyle), text.ReadLine(), true);
                    AxisYWidth = Int32.Parse(text.ReadLine());
                    AxisYColor = System.Drawing.Color.FromArgb(Int32.Parse(text.ReadLine()));

                    LegendPosition = (OxyPlot.Legends.LegendPosition)Enum.Parse(typeof(OxyPlot.Legends.LegendPosition), text.ReadLine(), true);

                    int count = Int32.Parse(text.ReadLine());

                    for (int iw = 0; iw < count; ++iw)
                    {
                        var tmp_style = new SeriesStyle();
                        tmp_style.Name = text.ReadLine();
                        tmp_style.LineColor = System.Drawing.Color.FromArgb(Int32.Parse(text.ReadLine()));
                        tmp_style.MarkerColor = System.Drawing.Color.FromArgb(Int32.Parse(text.ReadLine()));
                        tmp_style.MarkerFillColor = System.Drawing.Color.FromArgb(Int32.Parse(text.ReadLine()));
                        tmp_style.MarkerSize = Int32.Parse(text.ReadLine());
                        tmp_style.LineWidth = Int32.Parse(text.ReadLine());
                        tmp_style.LineSmooth = Boolean.Parse(text.ReadLine());
                        tmp_style.MarkerType = (MarkerType)Enum.Parse(typeof(MarkerType), text.ReadLine(), true);
                        tmp_style.LineStyle = (LineStyle)Enum.Parse(typeof(LineStyle), text.ReadLine(), true);
                        tmp_style.GroupMode = (GroupMode)Enum.Parse(typeof(GroupMode), text.ReadLine(), true);

                        listSeriesStyle.Add(tmp_style);
                    }
                    text.Close();
                }
            }

        }

        public SeriesStyle GetStyle(string name)
        {
            int index = GetIndex(name);
            if (index != -1) return GetStyle(index);
            return null;
        }

        public SeriesStyle GetStyle(int index)
        {
            return listSeriesStyle[index];
        }

        public int GetIndex(string name)
        {
            for (int iw = 0; iw < listSeriesStyle.Count; ++iw)
            {
                if (listSeriesStyle[iw].Name == name)
                    return iw;
            }
            return -1;
        }

        class UserFunctionItem
        {
            public string wellname;
            public DateTime time;
            public float value;
            public string annotation;
        }

        public class AnnotationItem
        {
            public DateTime time;
            public float value;
            public string text;
        }

        List<UserFunctionItem> UserFunction = null;

        public void LoadUserFunctions()
        {
            var fd = new System.Windows.Forms.OpenFileDialog() { Filter = "User file|*.csv" };

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UserFunction = new List<UserFunctionItem>();
                using (TextReader text = new StreamReader(fd.FileName, Encoding.GetEncoding("Windows-1251")))
                {
                    string line;

                    while ((line = text.ReadLine()) != null)
                    {
                        string[] split = line.Split(new char[] { ';' });

                        if (split.Length == 3)
                        {
                            UserFunction.Add(new UserFunctionItem
                            {
                                wellname = split[0].Trim(),
                                time = Convert.ToDateTime(split[1]),
                                value = Convert.ToSingle(split[2]),
                            });
                        }

                        if (split.Length == 4)
                        {
                            UserFunction.Add(new UserFunctionItem
                            {
                                wellname = split[0].Trim(),
                                time = Convert.ToDateTime(split[1]),
                                value = Convert.ToSingle(split[2]),
                                annotation = split[3]
                            });
                        }
                    }

                    text.Close();
                }
            }
        }

        public List<OxyPlot.DataPoint> GetUserFunction(string name)
        {
            return
                (from item in UserFunction
                 where item.wellname == name
                 select new OxyPlot.DataPoint(OxyPlot.Axes.DateTimeAxis.ToDouble(item.time), item.value)).ToList();
        }

        public List<AnnotationItem> GetAnnotation(string name)
        {
           return
                (from item in UserFunction
                 where item.wellname == name && item.annotation != ""
                 select new AnnotationItem { time = item.time, value = item.value, text = item.annotation }).ToList();
        }
    }
}
