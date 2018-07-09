using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace MagicInfoTest1
{
    class OpenAPI
    {
        public string getTokenID(string user, string pass, string baseURL)
        {
            if (!baseURL.StartsWith("http://", StringComparison.OrdinalIgnoreCase)) baseURL = "http://" + baseURL;

            var client = new RestClient(baseURL);
            var request = new RestRequest("auth", Method.POST);

            request.RequestFormat = DataFormat.Json;

 

            request.AddBody(new MIUser
                                {
                                    username = user,
                                    password = pass
                                }
             );

            IRestResponse response = client.Execute(request);
            var res = response.Content; // raw content as string

            try
            {
                dynamic auth = JsonConvert.DeserializeObject(res);

                string authToken = auth.token;
                return authToken;
            }
            catch
            {
                MessageBox.Show("Peease check your Username and Password", "Auth Token not retrivied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;

            }
        }

        public string getStatus(string baseURL, string auth)
        {

            var client = new RestClient(baseURL);
            var request = new RestRequest("restapi/v1.0/ums/users/me", Method.GET);

            request.RequestFormat = DataFormat.Json;

            request.AddHeader("api_key", auth);

            IRestResponse response = client.Execute(request);
            var res = response.Content; // raw content as string

            try
            {
                dynamic me = JsonConvert.DeserializeObject(res);

                string status = me.status;

                return status;
            }
            catch
            {
                MessageBox.Show("Peease check your Username and Password", "Token not retrivied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;

            }

        }

        public string getContentSize(string baseURL, string auth)
        {
            var client = new RestClient(baseURL);
            var request = new RestRequest("restapi/v1.0/cms/contents/dashboard", Method.GET);

            request.RequestFormat = DataFormat.Json;

            request.AddHeader("api_key", auth);

            IRestResponse response = client.Execute(request);
            var res = response.Content; // raw content as string

            try
            {
                dynamic contentDashboard = JsonConvert.DeserializeObject(res);

                string size = contentDashboard.totalCount;

                return size;
            }
            catch
            {
                MessageBox.Show("Peease check your Username and Password", "Token not retrivied", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;

            }
        }

        public IList<contentItem> getContentItems(string baseURL, string auth)
        {
            var client = new RestClient(baseURL);
            var request = new RestRequest("restapi/v1.0/cms/contents", Method.GET);
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("startIndex", "1", ParameterType.QueryString);
            request.AddParameter("pageSize", "100", ParameterType.QueryString);

            request.AddHeader("api_key", auth);

            IRestResponse response = client.Execute(request);
            var res = response.Content; // raw content as string

            IList<contentItem> contentList = new List<contentItem>();


            try
            {
                //dynamic contents = JsonConvert.DeserializeObject(res);

                JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(res);
                List<contentItem> items = jsonResponse["items"].ToObject<List<contentItem>>();

                foreach (var item in items)
                {
                    contentList.Add(item);
                }

                return contentList;
            }
            catch
            {
                return null;
            }

        }

        public string downloadImages(string baseURL, contentItem item , string tokenKey, string user)
        {
            string  path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpenAPI");

            string downloadURL = baseURL + item.thumbFilePath + "&api_key=" + tokenKey + "&userId=" + user +"&width=105" + "&height=80";
            string filename = item.contentId + ".png";
            if(!File.Exists(Path.Combine(path, filename)))
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(downloadURL), @Path.Combine(path, filename));
                }
            }


            return Path.Combine(path, filename);

        }
        
    }




    internal class MIUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
