using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPIExample.Business.Interfaces;

namespace WebsiteExample.Pages
{
    public class BasePageModel : PageModel
    {
        public readonly IWebsiteInformation _websiteInformation;
        public readonly ILogger _logger;
        public BasePageModel(ILogger<IndexModel> logger, IWebsiteInformation websiteInformation)
        {
            _websiteInformation = websiteInformation;
            _logger = logger;
        }
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {

        }
    }
}
