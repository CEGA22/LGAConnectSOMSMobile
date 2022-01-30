﻿using LGAConnectSOMSMobile.Helpers;
using LGAConnectSOMSMobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGAConnectSOMSMobile.Gateway
{
    public class AboutGateway
    {
        static string BaseUrl = "http://cega22-001-site1.ftempurl.com/api/lga/about";

        public async Task<IEnumerable<About>> GetAbout()
        {

            try
            {
                string url = BaseUrl + "/get_all";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<About>>(content);
                return result;
            }
            catch
            {
                return Enumerable.Empty<About>();
            }
        }
    }
}
