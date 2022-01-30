using LGAConnectSOMSMobile.Helpers;
using LGAConnectSOMSMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Gateway
{
    public class SchoolAccountGateway
    {
        static string BaseUrl = "http://cega22-001-site1.ftempurl.com/api/lga/school";

        public async Task<string> UpdateStudentPassword(SchoolAccountRequest request)
        {
            Uri url = new Uri(BaseUrl + "/update_password");
            return await WebMethods.MakePostRequest(url, request);
        }
    }
}
