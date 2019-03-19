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
    public partial class Form2D : Form
    {
        Form2DModel model = null;

        public Form2D(EclipseProject ecl)
        {
            InitializeComponent();
            model = new Form2DModel(ecl);

            UpdateData();
        }

        void UpdateData()
        {
            // Статичные свойства из INIT файла

            treeProperties.Nodes[0].Nodes.Clear();

            var static_properties = model.GetStaticProperties();

            treeProperties.BeginUpdate();

            foreach (string item in static_properties)
            {
                treeProperties.Nodes[0].Nodes.Add(item);
            }

            treeProperties.EndUpdate();

            //

            boxRestart.Items.Clear();

            boxRestart.BeginUpdate();
            boxRestart.Items.AddRange(model.GetRestartDates());
            boxRestart.EndUpdate();
            
        }
    }
}
