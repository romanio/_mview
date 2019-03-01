using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public partial class FormDetails : Form
    {
        private EclipseProject ecl;

        public FormDetails(EclipseProject ecl)
        {
            this.ecl = ecl;
            InitializeComponent();
            bGetDataOnClick(null, null);
        }

        private void bGetDataOnClick(object sender, EventArgs e)
        {
            gridGeneral.Rows.Clear();
            gridGeneral.Rows.Add("FILENAME", ecl.FILENAME);
            gridGeneral.Rows.Add("ROOT", ecl.ROOT);
            gridGeneral.Rows.Add("PATH", ecl.PATH);

            foreach (KeyValuePair<string, string> item in ecl.FILES)
            {
                gridGeneral.Rows.Add(item.Key, item.Value);
            }

            gridSummary.Rows.Clear();
            gridSummary.Rows.Add("STARTDATE", ecl.SUMMARY.STARTDATE);
            gridSummary.Rows.Add("NLIST", ecl.SUMMARY.NLIST);
            gridSummary.Rows.Add("NDIVX", ecl.SUMMARY.NDIVX);
            gridSummary.Rows.Add("NDIVY", ecl.SUMMARY.NDIVY);
            gridSummary.Rows.Add("NDIVZ", ecl.SUMMARY.NDIVZ);
            gridSummary.Rows.Add("ISTAR", ecl.SUMMARY.ISTAR);
            gridSummary.Rows.Add("RESTARTNAME", ecl.SUMMARY.RESTART);
            gridSummary.Rows.Add("NTIME", ecl.SUMMARY.NTIME);
        }
    }
}
