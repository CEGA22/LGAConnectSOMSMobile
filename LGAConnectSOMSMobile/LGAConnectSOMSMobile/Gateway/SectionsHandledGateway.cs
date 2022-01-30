using LGAConnectSOMSMobile.Helpers;
using LGAConnectSOMSMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Gateway
{
    public class SectionsHandledGateway
    {
        static string BaseUrl = "http://cega22-001-site1.ftempurl.com/api/lga/sectionsHandled";

        public async Task<IEnumerable<SectionsHandled>> GetSectionsHandled(int ID)
        {
            try
            {
                string url = $"{BaseUrl}/get_all/{ID}";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<SectionsHandled>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<SectionsHandled>();
            }
        }
    }
}
