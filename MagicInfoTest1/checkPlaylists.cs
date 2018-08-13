using MagicInfoTest1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicInfoTest1
{
    class checkPlaylists
    {
        public void check()
        {
            OpenAPI client = new OpenAPI();
            string token, username, password, server;

            string PlaylistID = "";
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
            filter.playlistType = "0"; //TODO discover indexes
            filter.searchText = "";
            filter.sortColumn = "last_modified_date";
            filter.sortOrder = "desc";
            filter.startDate = "";
            filter.startIndex = 1;
            filter.userId = "admin";

            playlistItem = client.getPlaylistItems(server, token, filter);

            foreach (playlistItem pi in playlistItem)
            {
                PlaylistID = PlaylistID + pi.playlistId.ToString() + "\n";
            }

            MessageBox.Show(PlaylistID);
        }
    }
}
