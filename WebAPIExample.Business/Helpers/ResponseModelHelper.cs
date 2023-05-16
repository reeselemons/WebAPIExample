using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAPIExample.Business.Interfaces;

namespace WebAPIExample.Business.Helpers
{
    public class ResponseModelHelper : IResponse
    {
        public virtual string ToJson() => JsonConvert.SerializeObject(this);
        public ResponseModelHelper()
        {

        }
    }
}
