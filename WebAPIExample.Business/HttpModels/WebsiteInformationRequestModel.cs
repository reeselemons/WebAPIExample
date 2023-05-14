using System.ComponentModel.DataAnnotations;
using WebAPIExample.Business.Helpers;
using WebAPIEXample.Business;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Business.Models
{
    [Serializable]
    public class WebsiteInformationRequestModel : RequestModelHelper
    {
        [Required(ErrorMessage = "Id is required")]
        public WebsiteType Id { get; set; }
    }
}