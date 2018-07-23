using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class deploySchedule
    {
        public string backgroundMusic { get; set; }
        public string contentMute { get; set; }
        public string contentSyncOn { get; set; }
        public bool deployReserve { get; set; }
        public string deviceGroupIds { get; set; }
        public string deviceType { get; set; }
        public string deviceTypeVersion { get; set; }
        public List<object> itemList { get; set; }
        public int scheduleGroupId { get; set; }
        public string scheduleName { get; set; }
        public string vwlType { get; set; }
        public object deployReserveResource { get; set; }
    }
}
