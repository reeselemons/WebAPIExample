using System.ComponentModel.DataAnnotations;
namespace WebAPIExample.Business.DataModels
{
    public class WebsiteInformation : Shared
    {
        [Key]
        public Guid WebsiteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public Member? Owner { get; set; }

        public WebsiteInformation()
        {

        }

        public WebsiteInformation(Guid websiteId, string name, string url, Member owner)
        {
            WebsiteId = websiteId;
            Name = name;
            Url = url;
            Owner = owner;
        }
    }
}
