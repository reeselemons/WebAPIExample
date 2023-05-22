using WebAPIExample.Business.DataModels;
using WebAPIEXample.Business;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Data
{
    public class SkillsDatabase
    {
        public List<Category> GetSkillCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Name = "General",
                    Skills = new List<Skill>()
                    {
                        new Skill("C#.NET 4.5-7 Framework"),
                        new Skill("Javascript/CSS/SASS"),
                        new Skill("React Web/Native"),
                        new Skill("React Testing Library"),
                        new Skill("N-Unit Testing"),
                        new Skill("Docker"),
                        new Skill("SQL Queries")
                    },
                },
                new Category()
                {
                    Name = "Azure",
                    Skills = new List<Skill>()
                    {
                        new Skill("Linux"),
                        new Skill("Docker"),
                        new Skill("Load Balancing With Nginx"),
                        new Skill("Data Sync"),
                        new Skill("Front-Door/CDN Profiles"),
                        new Skill("Storage Accounts"),
                        new Skill("Service Bus"),
                        new Skill("Event Hubs"),
                    },
                },
                new Category()
                {
                    Name = "AWS",
                    Skills = new List<Skill>()
                    {
                        new Skill("ECS - including automated tasks/alarms"),
                        new Skill("EC2"),
                        new Skill("CloudWatch"),
                        new Skill("CloudTrail"),
                        new Skill("Cognito"),
                        new Skill("Cognito User Pools"),
                        new Skill("Jenkins"),
                        new Skill("Octopus"),
                        new Skill("GitLab"),
                        new Skill("Database"),
                    },
                },
                new Category()
                {
                    Name = "Database",
                    Skills = new List<Skill>()
                    {
                        new Skill("SQL Server"),
                        new Skill("PostgreSQL"),
                        new Skill("Code First EF"),
                    },
                },
            };

            categories = categories.OrderBy(e => e.Name).ToList();
            return categories;
        }
    }
}