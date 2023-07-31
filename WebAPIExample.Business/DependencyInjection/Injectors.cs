using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebAPIExample.Business.Interfaces;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Business.DependencyInjection
{
    public static class Injectors
    {
        public static void AddInjectors(this WebApplicationBuilder builder, WebsiteType websiteType)
        {
            builder.Services.AddSingleton<IWebsiteInformation, WebsiteInformationInjector>(provider => new WebsiteInformationInjector(websiteType));
        }
    }
}