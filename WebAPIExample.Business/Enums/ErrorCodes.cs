using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIExample.Business.Enums
{
    public static class HttpCodes
    {
        public const int SUCCESS = 200;
        public const int NO_CONTENT = 204;
        public const int PERMANENT_REDIRECT = 308;
        public const int BAD_REQUEST = 400;
        public const int UNATHORIZED = 401;
        public const int FORBIDDEN = 403;
        public const int METHOD_NOT_ALLOWED = 495;
        public const int NOT_FOUND = 404;
        public const int INTERNAL_SERVER_ERROR = 500;
    }
}
