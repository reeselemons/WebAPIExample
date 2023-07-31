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
            //Could use the typical IF/ELSE but a switch statement looks cleaner
            switch (websiteId)
            {
                case WebsiteType.WebAPISite:
                    Task.Run(() => GetWebsite()).Wait();
                    Task.Run(() => GetSkills()).Wait();
                    break;
                case WebsiteType.ReactSite:
                case WebsiteType.StandardCoreSite:
                case WebsiteType.AngualarSite:
                default: break;
            }
        }

        public void GetWebsite()
        {
            HttpRequestBuilder httpRequestBuilder = new HttpRequestBuilder();

            //Typically would use a HttpClient because Webclient is deprecated. The code is provided in HttpRequestBuilder
            WebClient httpClient = new WebClient();
            HttpResponseModel response = httpRequestBuilder.CreateGetData(httpClient, $"{Constants.General.BASE_API}/websiteinformation/GetWebsiteById", $"websiteId={WebsiteId}");
            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Data))
            {
                WebsiteInformationResponseModel websiteInformation = JsonConvert.DeserializeObject<WebsiteInformationResponseModel>(response.Data);
                if (websiteInformation.WebsiteInformation != null)
                {
                    this.Name = websiteInformation.WebsiteInformation.Name;
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
        public async Task GetSkills()
        {
            HttpRequestBuilder httpRequestBuilder = new HttpRequestBuilder();

            //Typically would use a HttpClient because Webclient is deprecated. The code is provided in HttpRequestBuilder
            HttpClient httpClient = new HttpClient();
            HttpResponseModel response = await httpRequestBuilder.CreateGetData(httpClient, $"{Constants.General.BASE_API}/websiteinformation/GetSkillCategories");
            if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Data))
            {
                ResumeSkillsCategoriesResponseModel websiteInformation = JsonConvert.DeserializeObject<ResumeSkillsCategoriesResponseModel>(response.Data);
                if (websiteInformation.Categories.Count > 0)
                    this.SkillsCategories = websiteInformation.Categories;
                else
                    throw new Exception("Skill categories did not populate from API");
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
