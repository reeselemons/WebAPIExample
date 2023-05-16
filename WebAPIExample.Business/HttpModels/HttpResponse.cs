using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebAPIExample.Business.Helpers;

namespace WebAPIExample.Business.HttpModels
{
    public class HttpResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Data { get; set; }
    }
}
