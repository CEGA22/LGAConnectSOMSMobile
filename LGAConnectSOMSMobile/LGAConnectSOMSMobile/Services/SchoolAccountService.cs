using LGAConnectSOMSMobile.Gateway;
using LGAConnectSOMSMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Services
{
    public class SchoolAccountService
    {
        public async Task<bool> UpdateStudentPassword(SchoolAccountRequest request)
        {
            var apiGateway = new SchoolAccountGateway();
            var content = await apiGateway.UpdateStudentPassword(request);
            return JsonConvert.DeserializeObject<bool>(content);
        }
    }
}
