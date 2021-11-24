using LGAConnectSOMSMobile.Helpers;
using LGAConnectSOMSMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Gateway
{
    public class LoginGateway
    {
        static string BaseUrl = "http://ceejaygabrang-001-site1.itempurl.com/api/lga/account/login";


        public async Task<string> AccountLogin(LoginRequest request)
        {
            var uri = new Uri(string.Format(BaseUrl, "login"));
            return await WebMethods.MakePostRequest(uri, request);
        }
    }
}
