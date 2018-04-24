using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Authenticators;

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
            var token = response.Content; // raw content as string

            return token;
        }
    }

    

    internal class MIUser
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
