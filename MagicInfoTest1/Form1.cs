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
        public static string selectedDdays;

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
        private void selectDdays()
        {
            Form frmSelectDays = new frmSelectDays();
            frmSelectDays.Show();
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

            this.dataGridView1.Rows.Clear();
            for( int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow currentRow = dt.Rows[i];
                DataGridViewRow dgvRow = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                dgvRow.Cells[0].Value = currentRow.ItemArray[0].ToString();
                dgvRow.Cells[1].Value = currentRow.ItemArray[1].ToString();
                dgvRow.Cells[2].Value = Convert.ToDateTime(currentRow.ItemArray[2].ToString());
                dgvRow.Cells[3].Value = Convert.ToDateTime(currentRow.ItemArray[3].ToString());
                dgvRow.Cells[4].Value = currentRow.ItemArray[4].ToString();
                
                this.dataGridView1.Rows.Add(dgvRow);
            }
            
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                
                try
                {
                    string schedule = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string content = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string init = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string end = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string days = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                    publishSchedule publish = new publishSchedule();
                    publish.publish(schedule, content, init, end, days);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            setRowNumber(this.dataGridView1);
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridView1.CurrentCell.ColumnIndex;
            string colName = dataGridView1.Columns[column].Name;
            if (colName == "colPromocion")
            {
                TextBox tb = e.Control as TextBox;
                Form frmSelectIMG = new frmlSelectImg();
                frmSelectIMG.ShowDialog();
                try
                {
                    tb.Text = selectedPromo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (colName == "colDias")
            {
                TextBox tb = e.Control as TextBox;
                Form frmSelectDias = new frmSelectDays();
                frmSelectDias.ShowDialog();
                try
                {
                    tb.Text = selectedDdays;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }

        private void dataGridView1_EditModeChanged(object sender, EventArgs e)
        {
           
        }
    }
}
