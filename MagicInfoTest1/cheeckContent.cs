
using MagicInfoTest1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicInfoTest1
{
    class cheeckContent
    {
        public void check(string contentID)
        {
            OpenAPI client = new OpenAPI();
            string token, username, password, server;

            string contentName, contentmediaType;
            contentDetail currenetContent = new contentDetail();

            username = Settings.Default.username;
            password = Settings.Default.password;
            server = Settings.Default.server;

            token = client.getTokenID(username, password, server);

            currenetContent = client.GetContentDetails(server, token, contentID);

            contentName = currenetContent.items.contentName;
            contentmediaType = currenetContent.items.mediaType;

            MessageBox.Show(contentName + " \n" + contentmediaType);
        }

    }
}
