using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TangleEdit
{
    public partial class Main : Form
    {
        public Properties PropertiesForm = new Properties();

        public Main()
        {
            InitializeComponent();
            PropertiesForm.Show();
        }

        private void Mainform_Load(object sender, EventArgs e)
        {

        }

        public IntPtr getDrawSurface()
        {
            return pctSurface.Handle;
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PropertiesForm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

    }
}
