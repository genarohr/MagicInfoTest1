using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class contentDetail
    {
        public string apiVersion { get; set; }
        public string status { get; set; }
        public contentItems items { get; set; }
        public object errorMessage { get; set; }
        public object errorCode { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public int startIndex { get; set; }
    }

    public class contentItems
    {
        public string contentId { get; set; }
        public int versionId { get; set; }
        public string contentName { get; set; }
        public string mediaType { get; set; }
        public string creatorId { get; set; }
        public string createDate { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public int totalSize { get; set; }
        public int playTime { get; set; }
        public string resolution { get; set; }
        public string isDeleted { get; set; }
        public string isActive { get; set; }
        public int shareFlag { get; set; }
        public int groupId { get; set; }
        public string groupName { get; set; }
        public string mainFileId { get; set; }
        public string thumbFileId { get; set; }
        public string sfiFileId { get; set; }
        public string mainFileName { get; set; }
        public string thumbFilePath { get; set; }
        public string thumbFileName { get; set; }
        public string isLinearVwl { get; set; }
        public int screenCount { get; set; }
        public int xCount { get; set; }
        public int yCount { get; set; }
        public int xRange { get; set; }
        public int yRange { get; set; }
        public string isStreaming { get; set; }
        public int organizationId { get; set; }
        public string orgCreatorId { get; set; }
        public bool existFlv { get; set; }
        public string mainFileExtension { get; set; }
        public int contentOrder { get; set; }
        public int contentDuration { get; set; }
        public int vwlVersion { get; set; }
        public bool multiVwl { get; set; }
        public string deviceType { get; set; }
        public float deviceTypeVersion { get; set; }
        public int pollingInterval { get; set; }
        public string playTimeMilli { get; set; }
        public string isUsedTemplate { get; set; }
        public int templatePageCount { get; set; }
        public string approvalStatus { get; set; }
        public string approvalOpinion { get; set; }
        public string streamingUrl { get; set; }
    }
}
