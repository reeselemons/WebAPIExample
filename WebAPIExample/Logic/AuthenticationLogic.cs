using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Models;
using WebAPIExample.Data;

namespace WebAPIExample.Logic
{
    public class WebsiteInformationLogic
    {
        public WebsiteInformationResponseModel GetWebsite(WebsiteInformationRequestModel model)
        {
            List<WebsiteInformation> websites = new WebsiteDatabase().GetWebsites();

            var found = websites.Where(e => e.WebsiteId == model.Id).FirstOrDefault();

            if (found == null)
                throw new Exception(HttpCodes.NO_CONTENT.ToString());

            return new WebsiteInformationResponseModel()
            {
               WebsiteInformation = found
            };
        }
    }
}
