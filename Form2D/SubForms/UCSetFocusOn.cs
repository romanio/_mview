using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public partial class UCSetFocusOn : UserControl
    {
        public UCSetFocusOn()
        {
            InitializeComponent();
        }

        public event EventHandler SelectedIndexChanged;

        private void listWells_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listWells.SelectedItem == null) return;

            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(sender, e);
            }
        }
    }
}
