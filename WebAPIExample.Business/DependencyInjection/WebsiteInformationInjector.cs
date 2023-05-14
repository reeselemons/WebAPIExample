using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Interfaces;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Business.DependencyInjection
{
    public class WebsiteInformationInjector : WebsiteInformation, IWebsiteInformation
    {
        public WebsiteInformationInjector(WebsiteType websiteId) : base(websiteId)
        {
        }

        public WebsiteInformation CreateModel()
        {
            return this;
        }
    }
}
