using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace MagicInfoTest1
{
    class OpenAPI
    {
        public string getTokenID(string user, string pass, string baseURL)
        {
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
    }



    internal class MIUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
