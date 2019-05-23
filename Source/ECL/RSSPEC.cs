using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mview.ECL
{
    public class COMPLDATA
    {
        public int I;
        public int J;
        public int K;
        public float XC;
        public float YC;
        public float ZC;
    }


    public class WELLDATA
    {
        public int WINDEX;
        public string WELLNAME;
        public int I;
        public int J;
        public int K;
        public int COMPLNUM;
        public int GROUPNUM;
        public int WELLTYPE;
        public int WELLSTATUS;
        public float WOPRH;
        public float WWPRH;
        public float WGPRH;
        public float WLPRH;
        public float REF_DEPTH;
        public float WEFA;
        public float BHPH;
        public double WOPR;
        public double WWPR;
        public double WLPR;
        public double WBHP;
        public double WWCT;
        public double WOPT;
        public double WWPT;
        public double WWIT;
        public double WPI;
        public double WOPTH;
        public double WWPTH;
        public double WWITH;
        public float XC;
        public float YC;
        public List<COMPLDATA> COMPLS = new List<COMPLDATA>();
    }

    public class RSSPEC
    {
        public List<double> TIME = new List<double>(); // Количество дней с начала расчёта
        public List<int> REPORT = new List<int>();
        public List<int> TYPE_RESTART = new List<int>();
        public List<DateTime> DATE = new List<DateTime>();
        public List<string[]> NAME = new List<string[]>(); // Имя массива
        public List<string[]> TYPE = new List<string[]>(); // Тип массива
        public List<int[]> NUMBER = new List<int[]>(); // Размер векторов
        public List<int[]> POINTER = new List<int[]>(); // Lower part of the address
        public List<int[]> POINTERB = new List<int[]>(); // Upper part of the address
        public List<float[]> ARRAYMAX = new List<float[]>(); // Maximum values
        public List<float[]> ARRAYMIN = new List<float[]>(); // Minimum values
        public List<string[]> UNITS = new List<string[]>(); // Единица измерения
        public string FILENAME = null;

        public RSSPEC(string filename)
        {
            FileReader br = new FileReader();
            br.OpenBinaryFile(filename);

            if (br.Length > 0)
            {
                while (br.Position < br.Length - 24)
                {
                    br.ReadHeader();

                    if (br.header.keyword == "TIME")
                    {
                        br.ReadBytes(4);
                        TIME.Add(br.ReadDouble());
                        br.ReadBytes(4);
                        continue;
                    }

                    if (br.header.keyword == "ITIME")
                    {
                        // Eclipse должен содержать 11 элементов ITIME, 
                        // но tNavi игнорирует выгрузку этих элементов, параметры рестарт файла считываются из самих рестартов

                        int[] ITIME = br.ReadIntList();
                        if (ITIME.Length == 1)
                        {
                            REPORT.Add(ITIME[0]);
                        }
                        else
                        {
                            REPORT.Add(ITIME[0]);
                            TYPE_RESTART.Add(ITIME[5]);
                            if (ITIME.Length > 10)
                                DATE.Add(new DateTime(ITIME[3], ITIME[2], ITIME[1], ITIME[10], ITIME[11], (int)(ITIME[12] * 1e-6)));
                            else
                                DATE.Add(new DateTime(ITIME[3], ITIME[2], ITIME[1]));
                        }
                        continue;
                    }

                    if (br.header.keyword == "NAME")
                    {
                        NAME.Add(br.ReadStringList());
                        continue;
                    }

                    if (br.header.keyword == "TYPE")
                    {
                        TYPE.Add(br.ReadStringList());
                        continue;
                    }

                    if (br.header.keyword == "UNITS")
                    {
                        UNITS.Add(br.ReadStringList());
                        continue;
                    }

                    if (br.header.keyword == "NUMBER")
                    {
                        NUMBER.Add(br.ReadIntList());
                        continue;
                    }

                    if (br.header.keyword == "ARRAYMAX")
                    {
                        ARRAYMAX.Add(br.ReadFloatList(br.header.count));
                        continue;
                    }

                    if (br.header.keyword == "ARRAYMIN")
                    {
                        ARRAYMIN.Add(br.ReadFloatList(br.header.count));
                        continue;
                    }

                    if (br.header.keyword == "POINTER")
                    {
                        POINTER.Add(br.ReadIntList());
                        continue;
                    }

                    if (br.header.keyword == "POINTERB")
                    {
                        POINTERB.Add(br.ReadIntList());
                        continue;
                    }

                    br.SkipEclipseData();
                }
                br.CloseBinaryFile();
            }
        }
        public int NX, NY, NZ; // Размер по X, Y, Z
        public int NACTIV; // Количество активных ячеек
        public int IPHS; // Индикатор фазы
        public int NWELLS; // Количество скважин
        public int NCWMAX; // Максимальное количество перфораций на одну скважину
        public int NIWELZ; // Количество элементов данных в IWEL (int значения)
        public int NSWELZ; // Количество элементов данных в SWEL (float значения)
        public int NXWELZ; // Количество элементов данных в XWEL (double значения)
        public int NZWELZ; // Количество элементов данных в ZWEL (string значения)
        public int NICONZ; // Количество элементов данных в ICON (int значения)
        public int NSCONZ; // Количество элементов данных в SCON (float значения)
        public int NXCONZ; // Количество элементов данных в XCON (double значения)

        // Разворачивание в человеческий вид содержимое рестарт файла

        public List<WELLDATA> WELLS;
        public int RESTART_STEP;
        public float[] DATA = null;

        public void ReadRestart(string filename, int step)
        {
            FILENAME = filename;
            RESTART_STEP = step;

            FileReader br = new FileReader();

            Action<string> SetPosition = (name) =>
            {
                int index = Array.IndexOf(NAME[step], name);
                long pointer = POINTER[step][index];
                long pointerb = POINTERB[step][index];
                br.SetPosition(pointerb * 2147483648 + pointer);
            };
            
            WELLS = new List<WELLDATA>();

            br.OpenBinaryFile(filename);
            SetPosition("INTEHEAD");
            br.ReadHeader();
            int[] INTH = br.ReadIntList();
            NX = INTH[8];
            NY = INTH[9];
            NZ = INTH[10];
            NACTIV = INTH[11];
            IPHS = INTH[14];
            NWELLS = INTH[16];
            NCWMAX = INTH[17];
            NIWELZ = INTH[24];
            NSWELZ = INTH[25];
            NXWELZ = INTH[26];
            NZWELZ = INTH[27];
            NICONZ = INTH[32];
            NSCONZ = INTH[33];
            NXCONZ = INTH[34];

            if (NWELLS != 0)
            {
                SetPosition("IWEL");
                br.ReadHeader();
                int[] IWEL = br.ReadIntList();

                for (int iw = 0; iw < NWELLS; ++iw)
                {
                    WELLS.Add(new WELLDATA
                    {
                        WINDEX = iw,
                        I = IWEL[iw * NIWELZ + 0],
                        J = IWEL[iw * NIWELZ + 1],
                        K = IWEL[iw * NIWELZ + 2],
                        COMPLNUM = IWEL[iw * NIWELZ + 4],
                        GROUPNUM = IWEL[iw * NIWELZ + 5],
                        WELLTYPE = IWEL[iw * NIWELZ + 6],
                        WELLSTATUS = IWEL[iw * NIWELZ + 10]
                    });
                }

                SetPosition("SWEL");
                br.ReadHeader();

                float[] SWEL = br.ReadFloatList(br.header.count);

                for (int iw = 0; iw < NWELLS; ++iw)
                {
                    WELLS[iw].WOPRH = SWEL[iw * NSWELZ + 0];
                    WELLS[iw].WWPRH = SWEL[iw * NSWELZ + 1];
                    WELLS[iw].WGPRH = SWEL[iw * NSWELZ + 2];
                    WELLS[iw].WLPRH = SWEL[iw * NSWELZ + 3];
                    WELLS[iw].REF_DEPTH = SWEL[iw * NSWELZ + 9];
                    WELLS[iw].WEFA = SWEL[iw * NSWELZ + 24];
                    WELLS[iw].BHPH = SWEL[iw * NSWELZ + 68];
                }

                SetPosition("XWEL");
                br.ReadHeader();

                double[] XWEL = br.ReadDoubleList();

                for (int iw = 0; iw < NWELLS; ++iw)
                {
                    WELLS[iw].WOPR = XWEL[iw * NXWELZ + 0];
                    WELLS[iw].WWPR = XWEL[iw * NXWELZ + 1];
                    WELLS[iw].WLPR = XWEL[iw * NXWELZ + 3];
                    WELLS[iw].WBHP = XWEL[iw * NXWELZ + 6];
                    WELLS[iw].WWCT = XWEL[iw * NXWELZ + 7];
                    WELLS[iw].WOPT = XWEL[iw * NXWELZ + 18];
                    WELLS[iw].WWPT = XWEL[iw * NXWELZ + 19];
                    WELLS[iw].WWIT = XWEL[iw * NXWELZ + 23];
                    WELLS[iw].WPI = XWEL[iw * NXWELZ + 55];
                    WELLS[iw].WOPTH = XWEL[iw * NXWELZ + 75];
                    WELLS[iw].WWPTH = XWEL[iw * NXWELZ + 76];
                    WELLS[iw].WWITH = XWEL[iw * NXWELZ + 81];
                }

                SetPosition("ZWEL");
                br.ReadHeader();

                string[] ZWEL = br.ReadStringList();

                for (int iw = 0; iw < NWELLS; ++iw)
                {
                    for (int ic = 0; ic < NZWELZ; ++ic)
                    {
                        WELLS[iw].WELLNAME = WELLS[iw].WELLNAME + ZWEL[iw * NZWELZ + ic];
                    }
                    WELLS[iw].WELLNAME.Trim();
                }
                SetPosition("ICON");
                br.ReadHeader();

                int[] ICON = br.ReadIntList();

                for (int iw = 0; iw < NWELLS; ++iw) // Для всех скважин и для всех перфораций
                    for (int ic = 0; ic < NCWMAX; ++ic)
                    {
                        if (ICON[iw * NICONZ * NCWMAX + ic * NICONZ + 0] != 0) // Если перфорация существует
                        {
                            WELLS[iw].COMPLS.Add(new COMPLDATA
                            {
                                I = ICON[iw * NICONZ * NCWMAX + ic * NICONZ + 1] - 1,
                                J = ICON[iw * NICONZ * NCWMAX + ic * NICONZ + 2] - 1,
                                K = ICON[iw * NICONZ * NCWMAX + ic * NICONZ + 3] - 1
                            });
                        }
                    }
            }
     
            br.CloseBinaryFile();
        }

        public void ReadGrid(string property)
        {
            FileReader br = new FileReader();

            Action<string> SetPosition = (name) =>
            {
                int index = Array.IndexOf(NAME[RESTART_STEP], name);
                long pointer = POINTER[RESTART_STEP][index];
                long pointerb = POINTERB[RESTART_STEP][index];
                br.SetPosition(pointerb * 2147483648 + pointer);
            };

            br.OpenBinaryFile(FILENAME);
            SetPosition(property);
            br.ReadHeader();
            DATA = br.ReadFloatList(br.header.count);
            //
            br.CloseBinaryFile();
        }

        public float GetValue(int index)
        {
            return DATA[index];
        }

    }

}
