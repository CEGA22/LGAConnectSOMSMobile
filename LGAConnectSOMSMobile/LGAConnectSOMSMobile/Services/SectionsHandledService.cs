using LGAConnectSOMSMobile.Gateway;
using LGAConnectSOMSMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Services
{
    public class SectionsHandledService
    {
        public static async Task<IEnumerable<SectionsHandled>> GetSectionsHandled(int ID)
        {
            var apiGateway = new SectionsHandledGateway();
            var content = await apiGateway.GetSectionsHandled(ID);
            return content;
        }
    }
}
