using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIExample.Business.DataModels;

namespace WebAPIExample.Business.Interfaces
{
    public interface IWebsiteInformation
    {
        public WebsiteInformation CreateModel(); 
    }
}
