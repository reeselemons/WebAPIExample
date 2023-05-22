using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebAPIExample.Business.Models;
using WebAPIEXample.Configuration;

namespace WebAPIExample.Business.DataModels
{
    public class WebsiteInformation : Shared
    {
        [Key]
        public WebsiteType WebsiteId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public List<WebsiteInformationResumeObject> ResumeObjects = new List<WebsiteInformationResumeObject>();
        public List<Category> SkillsCategories = new List<Category>();
        public WebsiteInformation()
        {

        }
        public WebsiteInformation(WebsiteType websiteId)
        {
            if (WebsiteType.WebAPISite == websiteId)
            {
                ResumeObjects.Add(new WebsiteInformationResumeObject("Houlem LLC", "Atlanta, Georgia, United States · On-site", "Nov 2022", "Present", "Software Engineering Consultant",
            "\r\nHoulem LLC designs, creates, and maintains NET 6-7 websites and\r\nreact native mobile applications\r\n\r\nApplications primarily consist of landing, booking, live streaming,\r\nvideo game hosting via docker containers, and e-commerce websites.\r\n\r\nAll applications are deployed into a repository which is pulled upon\r\nrequest via a custom SignalR polling tool on the Azure VPS\r\n\r\nThese applications utilize microservices to maintain independent\r\ndatabases such as members, orders, streaming ports, newsletters\r\n(including Twilio text messaging), coupons, etc.\r\n\r\nMost web pages are built using HTML5, CSS, SASS, and javascript\r\nwith C# Razor.\r\n\r\nDeployed services on AWS by utilizing Octopus and Jenkins\r\n"));

                ResumeObjects.Add(new WebsiteInformationResumeObject("TrueBlue Inc.", "Tacoma, WA", "Jul 2020", "Nov 2022", "Software Engineer",
                    "\r\nTrueblue is a leader in staffing solutions for both web and mobile.\r\n\r\nBuilt microservice APIs .NET 6 hosted AWS with ECS\r\n\r\nBuilt web pages with React/Redux with typescript and SASS. Tested\r\nthrough React Testing Library\r\n\r\nDeployed services on AWS by utilizing Octopus and Jenkins"));

                ResumeObjects.Add(new WebsiteInformationResumeObject("Pangea", "Los Angeles, CA", "Jan 2016", "May 2020", "Applications Engineer",
                    "\r\nPangea is an outsource provider that develops fully customized,\r\nweb-enabled software solutions to manage in store marketing for\r\nwholesaler and retailer industries.\r\n\r\nUpdated and maintained legacy ASP.NET web forms web pages\r\n\r\nCreated and maintained Client-side testing with Selenium\r\n\r\nUpgraded Web Forms to .NET 5"));
            }
        }

        public WebsiteInformation(WebsiteType websiteId, string name, string url)
        {
            WebsiteId = websiteId;
            Name = name;
            Url = url;
        }
    }

    public class WebsiteInformationResumeObject
    {
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string EmploymentTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public WebsiteInformationResumeObject(string companyName, string location, string startDate, string endDate, string employmentTitle, string description)
        {
            CompanyName = companyName;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            EmploymentTitle = employmentTitle;
            Description = description;
        }
    }
}
