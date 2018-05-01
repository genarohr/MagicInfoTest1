using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicInfoTest1
{
    class me
    {
        public string apiversion { get; set; }
        public string status { get; set; }
        public Dictionary<string,items> item { get; set; }
    }
    class items
    {
        public string userId {get; set;}
        public string userName { get; set; }
        public string email { get; set; }
        public string organization { get; set; }
        public string groupName { get; set; }
        public string role { get; set; }
    }
}
