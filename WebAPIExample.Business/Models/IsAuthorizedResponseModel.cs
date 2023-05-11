using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Interfaces;

namespace WebAPIExample.Business.Models
{
    public class IsAuthorizedResponseModel : ResponseModelHelper
    {
        public AuthorizedStatus? Status;
    }
}