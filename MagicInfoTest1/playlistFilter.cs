using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{

    public class playlistFilter
    {
        public int startIndex { get; set; }
        public int pageSize { get; set; }
        public string sortColumn { get; set; }
        public string sortOrder { get; set; }
        public string searchText { get; set; }
        public string creatorId { get; set; }
        public string endDate { get; set; }
        public string startDate { get; set; }
        public string userId { get; set; }
        public string listType { get; set; }
        public string groupId { get; set; }
        public object deviceType { get; set; }
        public object playlistType { get; set; }
    }
}
