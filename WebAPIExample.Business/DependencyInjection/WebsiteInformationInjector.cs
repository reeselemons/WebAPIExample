using Newtonsoft.Json;
using System.Net;
using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.HttpModels;
using WebAPIExample.Business.Interfaces;
using WebAPIExample.Business.Models;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Business.DependencyInjection
{
    public class WebsiteInformationInjector : WebsiteInformation, IWebsiteInformation
    {
        public WebsiteInformationInjector(WebsiteType websiteId) : base(websiteId)
        {
            WebsiteId = websiteId;
            if (WebsiteType.StandardCoreSite == websiteId)
                Task.Run(() => GetWebsite()).Wait();

        }

        public void GetWebsite()
        {
            HttpRequestBuilder httpRequestBuilder = new HttpRequestBuilder();
            WebClient httpClient = new WebClient();
            HttpResponseModel response = httpRequestBuilder.CreateGetData(httpClient, $"{Constants.General.BASE_API}/websiteinformation/GetWebsiteById", $"websiteId={WebsiteId}");
            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Data))
            {
                WebsiteInformationResponseModel websiteInformation = JsonConvert.DeserializeObject<WebsiteInformationResponseModel>(response.Data);
                if (websiteInformation.WebsiteInformation != null)
                {
                    this.Name = websiteInformation.WebsiteInformation.Name;
                    this.Skills = websiteInformation.WebsiteInformation.Skills;
                    this.ResumeObjects = websiteInformation.WebsiteInformation.ResumeObjects;
                    this.Url = websiteInformation.WebsiteInformation.Url;
                    this.Created = DateTime.Now;
                }
                else
                    throw new Exception("WebsiteInformation Injector failed to deserialize");
            }
            else
                throw new Exception("Failed to load website from API");

        }

        public WebsiteInformation CreateModel()
        {
            return this;
        }
    }
}
