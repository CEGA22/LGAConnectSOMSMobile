using LGAConnectSOMSMobile.Gateway;
using LGAConnectSOMSMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Services
{
    public class NewsAndAnnouncementsService
    {
        public static async Task<IEnumerable<NewsAndAnnouncements>> GetNewsAndAnnouncements()
        {
            var apiGateway = new NewsAndAnnouncementsGateway();
            var content = await apiGateway.GetNewsAndAnnouncements();
            return content;
        }
    }
}
