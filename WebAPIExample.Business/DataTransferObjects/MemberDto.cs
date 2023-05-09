using System.ComponentModel.DataAnnotations;
using static WebAPIExample.Business.Helpers.Authentication;
namespace WebAPIExample.Business.DataModels
{
    public class MemberDTO : Shared
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
