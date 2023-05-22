namespace WebAPIExample.Business.DataModels
{
    public class Category
    {
        public string Name { get; set; } = string.Empty;
        public List<Skill> Skills { get; set; } = new List<Skill>();
    }
    public class Skill
    {
        public string Name { get; set; } = string.Empty;

        public Skill(string name)
        {
            Name = name;
        }
    }
}
