using MagicInfoTest1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicInfoTest1
{
    class checkSchedule
    {
        public void check(string schedule)
        {
            OpenAPI client = new OpenAPI();
            string token, username, password, server;
            string scheduleName, scheeduleframeId; 
            schedules currenetSchedule = new schedules();

            username = Settings.Default.username;
            password = Settings.Default.password;
            server = Settings.Default.server;

            token = client.getTokenID(username, password, server);

            currenetSchedule = client.GetScheduleDetails(server, token, schedule);

            scheduleName = currenetSchedule.items.data.scheduleName;
            scheeduleframeId = currenetSchedule.items.data.frameId;

            MessageBox.Show(scheduleName + " \n" + scheeduleframeId);
        }
    }
}
