using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;

/*
 Connect settings
 
     
     */


namespace MagicInfoTest1
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void txtServer_Enter(object sender, EventArgs e)
        {
            if( txtServer.Text == "e.g. https://ip:7001/MagicInfo")
            {
                txtServer.Text = "";
            }
        }

        private void txtServer_Leave(object sender, EventArgs e)
        {
            if (txtServer.Text == "")
            {
                txtServer.Text = "e.g. https://ip:7001/MagicInfo";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
