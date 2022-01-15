using LGAConnectSOMSMobile.Gateway;
using LGAConnectSOMSMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Services
{
    public class AboutService
    {
        public static async Task<IEnumerable<About>> GetAboutDetails()
        {
            var apiGateway = new AboutGateway();
            var content = await apiGateway.GetAbout();
            return content;
        }
    }
}
