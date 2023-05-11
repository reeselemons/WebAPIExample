using System.ComponentModel.DataAnnotations;
using WebAPIExample.Business.Helpers;

namespace WebAPIExample.Business.Models
{
    [Serializable]
    public class AuthRequestModel : RequestModelHelper
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [StringLength(60, ErrorMessage = "Password can't be longer than 60 characters")]
        public string Password { get; set; } = string.Empty;
    }
}