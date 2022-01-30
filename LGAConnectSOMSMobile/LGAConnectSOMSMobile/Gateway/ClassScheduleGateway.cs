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
    public class ClassScheduleGateway
    {
        static string BaseUrl = "http://cega22-001-site1.ftempurl.com/api/lga/classSchedule";

        public async Task<IEnumerable<ClassSchedule>> GetClassScheduleFaculty(int ID)
        {
            try
            {
                string url = $"{BaseUrl}/get_all_faculty/{ID}";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<ClassSchedule>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<ClassSchedule>();
            }
        }
    }
}
