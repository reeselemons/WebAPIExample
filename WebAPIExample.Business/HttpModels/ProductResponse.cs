using Newtonsoft.Json;
using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Interfaces;

namespace WebAPIExample.Business.Models
{
    public class ProductResponse : ResponseModelHelper, IResponse
    {
        public ProductDto? Product { get; set; }
    }
}
