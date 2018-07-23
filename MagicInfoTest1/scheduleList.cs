using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class scheduleList
    {
        public string apiVersion { get; set; }
        public string status { get; set; }
        public scheduleListItems items { get; set; }
        public object errorMessage { get; set; }
        public object errorCode { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public int startIndex { get; set; }
    }

    public class scheduleListItems
    {
        public object header { get; set; }
        public int recordsReturned { get; set; }
        public int recordsFiltered { get; set; }
        public string typeFilterList { get; set; }
        public int startIndex { get; set; }
        public string sort { get; set; }
        public string dir { get; set; }
        public int results { get; set; }
        public List<scheduleListData> data { get; set; }
        public object firstContentName { get; set; }
        public int selectedContentCnt { get; set; }
        public int totalRecords { get; set; }
    }

    public class scheduleListData 
    {
        public int groupId { get; set; }
        public string contentId { get; set; }
        public object creatorId { get; set; }
        public string isSync { get; set; }
        public string creatorMapped { get; set; }
        public int channelCount { get; set; }
        public string device_group_id { get; set; }
        public string framevals { get; set; }
        public string programName { get; set; }
        public string contentExist { get; set; }
        public string checkbox { get; set; }
        public string deviceGroupName { get; set; }
        public string deployTime { get; set; }
        public string publishStatus { get; set; }
        public string isAdSchedule { get; set; }
        public string deviceType { get; set; }
        public string programType { get; set; }
        public int publishTotalCount { get; set; }
        public DateTime modifyDate { get; set; }
        public bool onVWLMenu { get; set; }
        public int deviceCount { get; set; }
        public string lastdeployDate { get; set; }
        public int publishCurrentCount { get; set; }
        public float deviceTypeVersion { get; set; }
        public string groupName { get; set; }
        public string useSyncPlay { get; set; }
        public string isVwl { get; set; }
        public string programId { get; set; }
    }

}
