using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class playlist
    {
        public string apiVersion { get; set; }
        public string status { get; set; }
        public object errorCode { get; set; }
        public object errorMessage { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public List<playlistItem> items { get; set; }
        public int startIndex { get; set; }
    }

    public class playlistItem
    {
        public string playlistId { get; set; }
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
        public string thumbFilePath { get; set; }
        public string thumbFileName { get; set; }
    }
    
}
