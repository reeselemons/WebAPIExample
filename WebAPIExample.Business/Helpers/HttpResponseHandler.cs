using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIExample.Business.Enums;

namespace WebAPIExample.Business.Helpers
{
    public static class HttpResponseHandler
    {
        public static StatusCodeResult DetermineResponse(string httpCodeString)
        {
            if (int.TryParse(httpCodeString, out int httpCode))
            {
                switch (httpCode)
                {
                    case HttpCodes.INTERNAL_SERVER_ERROR: return new StatusCodeResult(HttpCodes.INTERNAL_SERVER_ERROR);
                    case HttpCodes.BAD_REQUEST: return new StatusCodeResult(HttpCodes.BAD_REQUEST);
                    case HttpCodes.METHOD_NOT_ALLOWED: return new StatusCodeResult(HttpCodes.METHOD_NOT_ALLOWED);
                    case HttpCodes.NOT_FOUND: return new StatusCodeResult(HttpCodes.NOT_FOUND);
                    case HttpCodes.FORBIDDEN: return new StatusCodeResult(HttpCodes.FORBIDDEN);
                    case HttpCodes.UNATHORIZED: return new StatusCodeResult(HttpCodes.UNATHORIZED);
                    default: return new StatusCodeResult(HttpCodes.NO_CONTENT);
                }
            }

            return new StatusCodeResult(HttpCodes.BAD_REQUEST);
        }
    }
}
