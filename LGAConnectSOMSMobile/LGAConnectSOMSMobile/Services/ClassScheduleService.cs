using LGAConnectSOMSMobile.Gateway;
using LGAConnectSOMSMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Services
{
    public class ClassScheduleService
    {
        public static async Task<IEnumerable<ClassSchedule>> GetClassScheduleDetailsFaculty(int ID)
        {
            var apiGateway = new ClassScheduleGateway();
            var content = await apiGateway.GetClassScheduleFaculty(ID);
            return content;
        }
    }
}
