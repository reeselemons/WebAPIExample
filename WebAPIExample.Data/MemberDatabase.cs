using WebAPIExample.Business.DataModels;

namespace WebAPIExample.Data
{
    public class MemberDatabase
    {
        public List<Member> GetMembers() => new List<Member>()
        {
            new Member(Name: "Rando Lemmen", "RandoLemmen", "password1"),
            new Member(Name: "Sara Palad", "SaraPalad", "password2"),
            new Member(Name: "Jean Packman", "JeanPackman", "password3"),
        };
    }
}