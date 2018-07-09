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

using MagicInfoTest1.Properties;

/*
 Connect settings
 
     
     */


namespace MagicInfoTest1
{
    public partial class frmConfig : Form
    {

        private void populateTexts()
        {
            txtPass.Text = Settings.Default.password;
            txtUsername.Text = Settings.Default.username;
            txtServer.Text = Settings.Default.server;
        }

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
            settings config = new settings();
            config.setSettings(txtServer.Text, txtUsername.Text, txtPass.Text);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            OpenAPI client = new OpenAPI();

            string token;
            IList<contentItem> contentList = new List<contentItem>();


            token = client.getTokenID(txtUsername.Text, txtPass.Text, txtServer.Text);

            contentList = client.getContentItems(txtServer.Text, token);

            txtTest.Text += token;

            txtTest.Text += "\n";



        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            populateTexts();
            if (txtServer.Text == "")
            {
                txtServer.Text = "e.g. https://ip:7001/MagicInfo";
            }
        }
    }
}
