using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MagicInfoTest1.Properties;

namespace MagicInfoTest1
{
    public partial class frmlSelectImg : Form
    {


        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        public void getContentsfromCMS()
        {
            OpenAPI client = new OpenAPI();
            string token, imgPath, username, password, server;
            int count = 0;
            
            IList<contentItem> contentList = new List<contentItem>();

            username = Settings.Default.username;
            password = Settings.Default.password;
            server = Settings.Default.server;

            token = client.getTokenID(username, password, server);
     
            contentList = client.getContentItems(server, token);

            foreach (var content in contentList)
            {
                
                imgPath = client.downloadImages(server, content, token, username);
                this.dataGridView1.Rows.Add();

                this.dataGridView1.Rows[count].Height = 109;
                Image img;

                img = Image.FromFile(imgPath);

                this.dataGridView1.Rows[count].Cells[0].Value = img;
                this.dataGridView1.Rows[count].Cells[1].Value = content.contentName;
                this.dataGridView1.Rows[count].Cells[2].Value = content.totalSize;
                this.dataGridView1.Rows[count].Cells[3].Value = content.creatorId;
                this.dataGridView1.Rows[count].Cells[4].Value = content.createDate;
                this.dataGridView1.Rows[count].Cells[5].Value = content.contentId;

                count++;
            }
            setRowNumber(this.dataGridView1);


        }
        public frmlSelectImg()
        {
            InitializeComponent();

            getContentsfromCMS();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string a = Convert.ToString(this.dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            DialogResult dialogResult = MessageBox.Show(a, "Do you want to select this promo to current store?", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                Form1.selectedPromo = a;
                this.Close();
            }


        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
