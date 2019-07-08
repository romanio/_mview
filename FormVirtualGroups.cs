using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mview
{
    public partial class FormVirtualGroups : Form
    {
        public event UpdateDataDelegate ApplyStyle;

        bool after_init = false;

        public FormVirtualGroups(EclipseProject ecl)
        {
            InitializeComponent();
            after_init = true;
        }

        private void checkShowGridLines_CheckedChanged(object sender, EventArgs e)
        {
            if (after_init) ApplyStyle();
        }

        private void boxMaximum_Validating(object sender, CancelEventArgs e)
        {
            double value;
        }

        private void boxMinimum_Validating(object sender, CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BOX MINIMUM : VALIDATING");

            double value;
        }

        private void checkShowBubbles_CheckedChanged(object sender, EventArgs e)
        {
            if (after_init) ApplyStyle();
        }

        private void boxBubbleMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (after_init) ApplyStyle();

        }

        private void numericScaleFactor_ValueChanged(object sender, EventArgs e)
        {

            if (after_init) ApplyStyle();
        }

        private void checkShowAllWell_CheckedChanged(object sender, EventArgs e)
        {

            if (after_init) ApplyStyle();
        }

        class VirtualGroupItem
        {
            public string wellname;
            public string pad;
        }

        List<VirtualGroupItem> VirtualGroup = null;

        private void bbLoadGroups_Click(object sender, EventArgs e)
        {
            var fd = new System.Windows.Forms.OpenFileDialog() { Filter = "User group file|*.csv" };

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VirtualGroup = new List<VirtualGroupItem>();

                using (TextReader text = new StreamReader(fd.FileName, Encoding.GetEncoding("Windows-1251")))
                {
                    string line;

                    while ((line = text.ReadLine()) != null)
                    {
                        string[] split = line.Split(new char[] { ';' });

                        if (split.Length == 2)
                        {
                            VirtualGroup.Add(new VirtualGroupItem
                            {
                                wellname = split[0].Trim(),
                                pad = split[1].Trim()
                            });
                        }
                    }
                    text.Close();

                    listGroups.Items.Clear();

                    var pads = (from item in VirtualGroup
                                select item.pad).Distinct().ToArray();

                    listGroups.Items.AddRange(pads);
                }
            }
        }

        private void listGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGroups.SelectedItem == null) return;

            string selected_pad = listGroups.SelectedItem.ToString();

            listWells.Items.Clear();

            var wells = (from item in VirtualGroup
                         where item.pad == selected_pad
                         select item.wellname).ToArray();

            listWells.Items.AddRange(wells);
        }
    }
}
