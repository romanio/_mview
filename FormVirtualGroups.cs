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

        EclipseProject ecl = null;

        public FormVirtualGroups(EclipseProject ecl)
        {
            InitializeComponent();


            this.ecl = ecl;

            if (ecl.VirtualGroup != null)
            {
                listGroups.Items.Clear();

                var pads = (from item in ecl.VirtualGroup
                            select item.pad).Distinct().ToArray();

                listGroups.Items.AddRange(pads);
            }
        }

        private void bbLoadGroups_Click(object sender, EventArgs e)
        {
            var fd = new System.Windows.Forms.OpenFileDialog() { Filter = "User group file|*.csv" };

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ecl.VirtualGroup = new List<VirtualGroupItem>();

                using (TextReader text = new StreamReader(fd.FileName, Encoding.GetEncoding("Windows-1251")))
                {
                    string line;

                    while ((line = text.ReadLine()) != null)
                    {
                        string[] split = line.Split(new char[] { ';' });

                        if (split.Length == 2)
                        {
                            ecl.VirtualGroup.Add(new VirtualGroupItem
                            {
                                wellname = split[0].Trim(),
                                pad = split[1].Trim()
                            });
                        }
                    }
                    text.Close();

                    listGroups.Items.Clear();

                    var pads = (from item in ecl.VirtualGroup
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

            var wells = (from item in ecl.VirtualGroup
                         where item.pad == selected_pad
                         select item.wellname).ToArray();

            listWells.Items.AddRange(wells);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ecl.VirtualGroup = null;
        }
    }
}
