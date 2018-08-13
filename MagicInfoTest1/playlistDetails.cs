using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class playlistDetails
    {
        public string apiVersion { get; set; }
        public string status { get; set; }
        public object errorCode { get; set; }
        public object errorMessage { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public playlistDetailsItems items { get; set; }
        public int startIndex { get; set; }
    }

    public class playlistDetailsItems
    {
        public string deviceType { get; set; }
        public string deviceTypeVersion { get; set; }
        public string playlistName { get; set; }
        public string groupId { get; set; }
        public string groupName { get; set; }
        public int shareFlag { get; set; }
        public string metaData { get; set; }
        public string shuffleFlag { get; set; }
        public int contentCount { get; set; }
        public int playTime { get; set; }
        public int totalSize { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public string creatorId { get; set; }
        public string playlistType { get; set; }
        public int versionId { get; set; }
        public List<playlistDetailsContentlist> contentList { get; set; }
        public string thumbFilePath { get; set; }
        public string thumbFileName { get; set; }
        public List<object> categoryList { get; set; }
    }

    public class playlistDetailsContentlist
    {
        public string playlistId { get; set; }
        public int versionId { get; set; }
        public string contentId { get; set; }
        public string contentName { get; set; }
        public string thumbFileId { get; set; }
        public string thumbFileName { get; set; }
        public string thumbFilePath { get; set; }
        public string playTime { get; set; }
        public bool hasDefaultPlayTime { get; set; }
        public int contentOrder { get; set; }
        public int contentDuration { get; set; }
        public string contentDurationMilli { get; set; }
        public string startDate { get; set; }
        public string expiredDate { get; set; }
        public string mediaType { get; set; }
        public bool subPlaylist { get; set; }
    }
}
