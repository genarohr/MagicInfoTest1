using MagicInfoTest1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{
    class publishPlaylist
    {
          public void publish(string schedule, string content, string init, string finish, string days)
        {
            OpenAPI client = new OpenAPI();
            string token, username, password, server;

            DateTime inicio, fin;
            string strInit, strEnd;


            programSchedule publish = new programSchedule();
            programScheduleItemlist itms = new programScheduleItemlist();

            schedules currenetSchedule = new schedules(); //retrive  information  from current schedule
            string frameID, thumbnailPath;
            string deviceGroupIds; //this is the variable to be taken in order to publish to the same device group
            int programGroupId;

            playlistDetails currenetPlaylist = new playlistDetails();////retrive  information  from playlist
            string contentName;


            username = Settings.Default.username;
            password = Settings.Default.password;
            server = Settings.Default.server;


            inicio = Convert.ToDateTime(init);
            fin = Convert.ToDateTime(finish);
            
            strInit = inicio.ToString("yyyy-M-d"); 
            strEnd  = fin.ToString("yyyy-M-d");


            token = client.getTokenID(username, password, server);

            currenetSchedule = client.GetScheduleDetails(server, token, schedule);
            currenetPlaylist = client.GetPlaylistDetails(server, token, content);

            contentName = currenetPlaylist.items.playlistName;
            thumbnailPath = currenetPlaylist.items.contentList[0].thumbFilePath;

            frameID = currenetSchedule.items.data.channelList[0].frameList[0].frameId;
            deviceGroupIds = currenetSchedule.items.data.deviceGroupId;

            programGroupId = currenetSchedule.items.data.programGroupId;

            if (days == "")
            {
                days = "mon,tue,wed,thu,fri,sat,sun";
            }

            

            itms.channelNo = 1;
            itms.cifsSlideTime = "5";
            itms.contentId = content;
            itms.contentName = contentName;
            itms.contentType = "PLAYLIST";
            itms.duration = "86399";
            itms.frameId = frameID;
            itms.inputSource = "";
            itms.isSync = "";
            itms.monthday = "";
            itms.playerMode = "single";
            itms.priority = 1;
            itms.repeatType = "day_of_week";
            itms.safetyLock = "";
            itms.scheduleType = "LFD";
            itms.startDate = strInit;
            itms.startTime = "00:00:00";
            itms.stopDate = strEnd;
            itms.thumbnailPath = thumbnailPath;
            itms.weekdays = days;

            List<programScheduleItemlist> Itemlist = new List<programScheduleItemlist>();
            Itemlist.Add(itms);

            publish.backgroundMusic = "";
            publish.contentMute = "";
            publish.contentSyncOn = "0";
            publish.deployReserve = "false";
            publish.description = null;
            publish.deviceGroupIds = deviceGroupIds;
            publish.deviceType = "SPLAYER";
            publish.itemList = Itemlist;
            publish.deviceTypeVersion = 4; //Splayer  SSSP4
            publish.scheduleGroupId = programGroupId;
            publish.scheduleName = "Publicaado desde API";
            publish.vwlType = "";


            client.putSchedule(server, token, publish, schedule);
            System.Threading.Thread.Sleep(1000);
            client.deploySchedule(server, token, deviceGroupIds, schedule);


        }
    
    }
}
