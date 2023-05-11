using WebAPIExample.Business.DataModels;

namespace WebAPIExample.Data
{
    public class WebsiteDatabase
    {
        public List<WebsiteInformation> GetProducts()
        {
            List<Member> memberDatabase = new MemberDatabase().GetMembers();
            return new List<WebsiteInformation>()
            {
                new WebsiteInformation(Guid.NewGuid(), "People R Us", "peoplerus.com", memberDatabase[1]),
                new WebsiteInformation(Guid.NewGuid(), "Googlet", "googlet.com", memberDatabase[2]),
                new WebsiteInformation(Guid.NewGuid(), "Power Bills Sync", "powerbillssync.com", memberDatabase[3])
            };
        }
    }
}