using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIExample.Business.Enums;

namespace WebAPIExample.Business.Helpers
{
    public static class RequestValidator
    {
        public static RequestModelHelper Validate(this RequestModelHelper requestModelHelper) => requestModelHelper ?? throw new Exception(HttpCodes.INTERNAL_SERVER_ERROR.ToString());
    }
}
