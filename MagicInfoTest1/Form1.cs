using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;

using MagicInfoTest1.Properties;

namespace MagicInfoTest1
{
    public partial class Form1 : Form
    {

        public static string selectedPromo;

        private string path = "";


        private void checkPath()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpenAPI");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }

        private void selectImg()
        {
            Form frmSelectIMG = new frmlSelectImg();

            frmSelectIMG.Show();

        }

        private void checkConfig()
        {
            if (Settings.Default.server == "" | Settings.Default.username == "" | Settings.Default.password == "")
            {
                Form frmConfig = new frmConfig();
                frmConfig.ShowDialog();
            }
        }
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        public Form1()
        {
            InitializeComponent();
            checkConfig();
            checkPath();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            setRowNumber(this.dataGridView1);
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string filePath = openFileDialog1.FileName;
            xlsRead xr = new xlsRead();
            DataTable dt = new DataTable();

            try
            {
                dt = xr.readXLS(filePath);
            }
            catch
            {
                MessageBox.Show("No compatible data");
            }

        }




        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string tmpPromo = selectedPromo;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colPromocion")
            {
                //selectImg();

                Form frmSelectIMG = new frmlSelectImg();

                frmSelectIMG.ShowDialog();

                try
                {
                    //this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[e.RowIndex].Height = 109;
                    Image img;
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpenAPI");
                    string imgPath = Path.Combine(path, selectedPromo + ".png");
                    img = Image.FromFile(imgPath);
                    this.dataGridView1.Rows[e.RowIndex].Cells[1].Value = img;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            setRowNumber(this.dataGridView1);
        }
    }
}
