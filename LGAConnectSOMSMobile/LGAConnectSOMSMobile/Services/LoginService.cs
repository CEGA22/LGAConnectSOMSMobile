using LGAConnectSOMSMobile.Gateway;
using LGAConnectSOMSMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Services
{
    public class LoginService
    {
        public async Task<LoginResult> AccountLogin(LoginRequest request)
        {
            var apiGateway = new LoginGateway();
            var content = await apiGateway.AccountLogin(request);
            return JsonConvert.DeserializeObject<LoginResult>(content);
        }
    }
}
