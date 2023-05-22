using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Interfaces;

namespace WebAPIExample.Business.Models
{
    public class ResumeSkillsCategoriesResponseModel : ResponseModelHelper, IResponse
    {
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
