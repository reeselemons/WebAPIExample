using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebAPIExample.Business.Interfaces;

namespace WebAPIExample.Business.DependencyInjection
{
    public static class Injectors
    {
        public static void AddInjectors(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IWebsiteInformation, WebsiteInformationInjector>();
        }
    }
}
