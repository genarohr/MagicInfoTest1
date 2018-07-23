using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class programSchedule
    {
        public string backgroundMusic { get; set; }
        public string contentMute { get; set; }
        public string contentSyncOn { get; set; }
        public string deployReserve { get; set; }
        public object description { get; set; }
        public string deviceGroupIds { get; set; }
        public string deviceType { get; set; }
        public int deviceTypeVersion { get; set; }
        public List<programScheduleItemlist> itemList { get; set; }
        public int scheduleGroupId { get; set; }
        public string scheduleName { get; set; }
        public string vwlType { get; set; }
    }

    public class programScheduleItemlist
    {
        public int channelNo { get; set; }
        public string frameId { get; set; }
        public string cifsSlideTime { get; set; }
        public string contentId { get; set; }
        public string contentName { get; set; }
        public string contentType { get; set; }
        public string thumbnailPath { get; set; }
        public string duration { get; set; }
        public string inputSource { get; set; }
        public string isSync { get; set; }
        public string monthday { get; set; }
        public string playerMode { get; set; }
        public string repeatType { get; set; }
        public string scheduleType { get; set; }
        public string startDate { get; set; }
        public string startTime { get; set; }
        public string stopDate { get; set; }
        public string weekdays { get; set; }
        public int priority { get; set; }
        public string safetyLock { get; set; }
    }

}
