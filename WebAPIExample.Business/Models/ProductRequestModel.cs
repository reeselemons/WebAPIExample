using System.ComponentModel.DataAnnotations;
using WebAPIExample.Business.Helpers;

namespace WebAPIExample.Business.Models
{
    [Serializable]
    public class ProductRequestModel : RequestModelHelper
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }
    }
}