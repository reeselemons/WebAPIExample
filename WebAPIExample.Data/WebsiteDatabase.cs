using WebAPIExample.Business.DataModels;
using WebAPIEXample.Business;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Data
{
    public class WebsiteDatabase
    {
        public List<WebsiteInformation> GetWebsites()
        {
            List<Member> memberDatabase = new MemberDatabase().GetMembers();

   
            return new List<WebsiteInformation>()
            {
                new WebsiteInformation(WebsiteType.WebAPISite)
            };
        }
    }
}