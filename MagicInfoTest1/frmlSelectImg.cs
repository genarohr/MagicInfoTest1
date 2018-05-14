using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MagicInfoTest1.Properties;

namespace MagicInfoTest1
{
    public partial class frmlSelectImg : Form
    {
        OpenAPI client = new OpenAPI();

        public void getContentsfromCMS()
        {
            



        }
        public frmlSelectImg()
        {
            InitializeComponent();

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGridView1.Rows[e.RowIndex].C
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
