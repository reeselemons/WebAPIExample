using System.ComponentModel.DataAnnotations;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Interfaces;
using static WebAPIExample.Business.Helpers.Authentication;
namespace WebAPIExample.Business.DataModels
{
    public class Member : DTO<Member, MemberDTO>
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string SaltedPassword { get; set; } = string.Empty;

        public Member(string Name, string Username, string Password)
        {
            this.Name = Name;
            this.Username = Username;
            this.Password = Password;
            this.SaltedPassword = CalculateMD5(Password);
        }

        public override MemberDTO Map(Member item)
        {
            if (item == null)
                throw new Exception(HttpCodes.INTERNAL_SERVER_ERROR.ToString());

            MemberDTO dto = new MemberDTO();

            dto.UserId = item.UserId;
            dto.Name = item.Name;

            return dto;
        }

        public override List<MemberDTO> MapToList(List<Member> models)
        {
            List<MemberDTO> list = new List<MemberDTO>();

            foreach (var model in models)
                list.Add(Map(model));

            return list;
        }
    }
}
