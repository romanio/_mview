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
    public partial class FormVirtualGroups : Form
    {
        public event UpdateDataDelegate ApplyStyle;

        bool after_init = false;

        public FormVirtualGroups(EclipseProject ecl)
        {
            InitializeComponent();

            boxMinimum.Text = ecl.FILENAME;
            
            after_init = true;
        }

        private void checkShowGridLines_CheckedChanged(object sender, EventArgs e)
        {
            if (after_init) ApplyStyle();
        }

        private void boxMaximum_Validating(object sender, CancelEventArgs e)
        {
            double value;

            if (double.TryParse(boxMaximum.Text, out value))
            {
                if (after_init) ApplyStyle();
            }
        }

        private void boxMinimum_Validating(object sender, CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BOX MINIMUM : VALIDATING");

            double value;

            if (double.TryParse(boxMinimum.Text, out value))
            {
                if (after_init) ApplyStyle();
            }
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
    }
}
