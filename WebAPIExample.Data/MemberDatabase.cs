using WebAPIExample.Business.DataModels;

namespace WebAPIExample.Data
{
    public class MemberDatabase
    {
        public List<Member> GetMembers() => new List<Member>()
        {
            new Member("Rando Lemmen", "RandoLemmen", "password1"),
            new Member("Sara Palad", "SaraPalad", "password2"),
            new Member("Jean Packman", "JeanPackman", "password3"),
        };
    }
}