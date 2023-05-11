using System.ComponentModel.DataAnnotations;
using WebAPIExample.Business.Helpers;

namespace WebAPIExample.Business.Models
{
    [Serializable]
    public class ProductsRequestModel : RequestModelHelper
    {
        [Required(ErrorMessage = "Ids are required")]
        public Guid[] Ids { get; set; }
    }
}