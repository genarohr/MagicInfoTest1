using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class schedules
    {
        public string apiVersion { get; set; }
        public string status { get; set; }
        public scheduleItems items { get; set; }
        public object errorMessage { get; set; }
        public object errorCode { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public int startIndex { get; set; }
    }

    public class scheduleItems
    {
        public bool isAdSchedule { get; set; }
        public bool canWriteContent { get; set; }
        public string programId { get; set; }
        public List<scheduleDevicestatuslist> deviceStatusList { get; set; }
        public string deviceType { get; set; }
        public scheduleData data { get; set; }
    }

    public class scheduleData
    {
        public string sessionId { get; set; }
        public string programId { get; set; }
        public int version { get; set; }
        public string programName { get; set; }
        public string programType { get; set; }
        public string isAdschedule { get; set; }
        public string contentSyncOn { get; set; }
        public string deviceType { get; set; }
        public float deviceTypeVersion { get; set; }
        public object scheudleDesText { get; set; }
        public object bgmName { get; set; }
        public string bgm { get; set; }
        public string scheduleMuteContent { get; set; }
        public int programGroupId { get; set; }
        public string programGroupName { get; set; }
        public string deviceGroupId { get; set; }
        public string deviceGroupName { get; set; }
        public int channelNo { get; set; }
        public string frameId { get; set; }
        public int numberOfChannel { get; set; }
        public List<scheduleChannellist> channelList { get; set; }
        public string scheduleName { get; set; }
        public string scheudleGroup { get; set; }
        public long lastModified { get; set; }
        public string type { get; set; }
        public string scheduleType { get; set; }
        public int deviceUseCount { get; set; }
        public string programStatus { get; set; }
        public int value { get; set; }
        public object description { get; set; }
    }

    public class scheduleChannellist
    {
        public string channelName { get; set; }
        public int channelNo { get; set; }
        public string mainFrameId { get; set; }
        public List<scheduleFramelist> frameList { get; set; }
    }

    public class scheduleFramelist
    {
        public string frameId { get; set; }
        public string frameName { get; set; }
        public int frameIndex { get; set; }
        public string isMainFrame { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float width { get; set; }
        public float height { get; set; }
        public string lineData { get; set; }
        public int maxIndex { get; set; }
        public List<Schedulelist> scheduleList { get; set; }
    }

    public class Schedulelist
    {
        public string id { get; set; }
        public string fileName { get; set; }
        public string fileId { get; set; }
        public string contentType { get; set; }
        public string contentId { get; set; }
        public string title { get; set; }
        public string safetyLock { get; set; }
        public string thumbnailPath { get; set; }
        public string repeatType { get; set; }
        public string weekdays { get; set; }
        public string monthdays { get; set; }
        public string playerMode { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string stopDate { get; set; }
        public List<scheduleRange> ranges { get; set; }
        public string dow { get; set; }
        public int index { get; set; }
        public string scheduleId { get; set; }
        public string color { get; set; }
        public int size { get; set; }
        public bool allDay { get; set; }
        public int cifsSlideTime { get; set; }
    }

    public class scheduleRange
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class scheduleDevicestatuslist
    {
        public int total { get; set; }
        public string device_group_name { get; set; }
        public int complete { get; set; }
        public string device_id { get; set; }
        public string device_name { get; set; }
    }
}
