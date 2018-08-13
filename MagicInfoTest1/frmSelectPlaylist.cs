using MagicInfoTest1.Properties;
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
    public partial class frmSelectPlaylist : Form
    {
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        public void getPlaylistsFromCMS()
        {
            OpenAPI client = new OpenAPI();
            string token, imgPath, username, password, server;
            int count = 0;

            IList<playlistItem> playlistItem = new List<playlistItem>();
            playlistFilter filter = new playlistFilter();



            username = Settings.Default.username;
            password = Settings.Default.password;
            server = Settings.Default.server;

            token = client.getTokenID(username, password, server);

            filter.creatorId = "admin";
            filter.deviceType = null;
            filter.endDate = "";
            filter.groupId = "0";
            filter.listType = "ALL";
            filter.pageSize = 100;
            filter.playlistType = "0"; //TODO discover indexes 0 General
            filter.searchText = "";
            filter.sortColumn = "last_modified_date";
            filter.sortOrder = "desc";
            filter.startDate = "";
            filter.startIndex = 1;
            filter.userId = "admin";

            playlistItem = client.getPlaylistItems(server, token, filter);

            foreach (var pi in playlistItem)
            {

                imgPath = client.downloadImages(server, pi.playlistId, pi.thumbFilePath, token, username);
                this.dataGridView1.Rows.Add();

                this.dataGridView1.Rows[count].Height = 109;
                Image img;

                img = Image.FromFile(imgPath);

                this.dataGridView1.Rows[count].Cells[0].Value = img;
                this.dataGridView1.Rows[count].Cells[1].Value = pi.playlistName.ToString();
                this.dataGridView1.Rows[count].Cells[2].Value = pi.playlistId.ToString();


                count++;
            }
            setRowNumber(this.dataGridView1);
        }

        public frmSelectPlaylist()
        {
            InitializeComponent();
            getPlaylistsFromCMS();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = Convert.ToString(this.dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            DialogResult dialogResult = MessageBox.Show(a, "Do you want to select this promo to current store?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1.selectedPromo = a;
                this.Close();
            }
        }

        private void frmSelectPlaylist_Load(object sender, EventArgs e)
        {

        }
    }
}
