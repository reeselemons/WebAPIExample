using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPIExample.Business.Interfaces;

namespace WebsiteExample.Pages
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(ILogger<IndexModel> logger, IWebsiteInformation websiteInformation) : base(logger, websiteInformation) { }

        public void OnGet()
        {

        }
    }
}