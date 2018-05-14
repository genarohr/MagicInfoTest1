using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{
    class contentDashboard
    {
        public string apiVersion { get; set; }
        public string status { get; set; }
        public contentDashboardItems items { get; set; }
        public object errorMessage { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public object errorCode { get; set; }
        public int startIndex { get; set; }
    }
    public class contentDashboardItems
    {
        public int totalCount { get; set; }
        public int usedCount { get; set; }
    }
}




