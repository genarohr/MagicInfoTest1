using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicInfoTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void magicInfoSerrverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmConfig = new frmConfig();

            frmConfig.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new frmAbout();

            frmAbout.Show();

        }
    }
}
