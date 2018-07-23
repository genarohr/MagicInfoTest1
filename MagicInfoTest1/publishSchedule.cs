using MagicInfoTest1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{
    class publishSchedule
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

            contentDetail currenetContent = new contentDetail();////retrive  information  from content
            string contentName, mediaType;


            username = Settings.Default.username;
            password = Settings.Default.password;
            server = Settings.Default.server;


            inicio = Convert.ToDateTime(init);
            fin = Convert.ToDateTime(finish);
            
            strInit = inicio.ToString("yyyy-M-d"); 
            strEnd  = fin.ToString("yyyy-M-d");


            token = client.getTokenID(username, password, server);

            currenetSchedule = client.GetScheduleDetails(server, token, schedule);
            currenetContent = client.GetContentDetails(server, token, content);

            contentName = currenetContent.items.contentName;
            mediaType = currenetContent.items.mediaType;
            thumbnailPath = currenetContent.items.thumbFilePath;

            frameID = currenetSchedule.items.data.channelList[0].frameList[0].frameId;

            if (days == "")
            {
                days = "mon,tue,wed,thu,fri,sat,sun";
            }

            

            itms.channelNo = 1;
            itms.cifsSlideTime = "5";
            itms.contentId = content;
            itms.contentName = contentName;
            itms.contentType = mediaType;
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
            publish.deviceGroupIds = "50";//TODO
            publish.deviceType = "SPLAYER";
            publish.itemList = Itemlist;
            publish.deviceTypeVersion = 4; //Splayer  SSSP4
            publish.scheduleGroupId = 14; //TODO
            publish.scheduleName = "Publicaado desde API";
            publish.vwlType = "";


            client.putSchedule(server, token, publish, schedule);



        }
    }
}
