using WebAPIExample.Business.DataModels;
using WebAPIEXample.Business;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Data
{
    public class WebsiteDatabase
    {
        public List<WebsiteInformation> GetWebsites()
        {
            return new List<WebsiteInformation>()
            {
                new WebsiteInformation(WebsiteType.WebAPISite),
                new WebsiteInformation(WebsiteType.AngualarSite),
                new WebsiteInformation(WebsiteType.StandardCoreSite),
                new WebsiteInformation(WebsiteType.ReactSite),
            };
        }
    }
}