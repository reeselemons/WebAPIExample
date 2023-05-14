using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Cryptography;
using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Interfaces;
using WebAPIExample.Business.Models;
using WebAPIExample.Data;
using static WebAPIExample.Business.Constants.Auth;
using static WebAPIExample.Business.Helpers.Authentication;

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
