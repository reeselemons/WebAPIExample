using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using WebAPIExample.Business.Enums;
using static WebAPIExample.Business.Constants.Auth;
namespace WebAPIExample.Business.Helpers
{
    public class Authentication
    {
        public static AuthenticationProperties AuthProperties => new AuthenticationProperties
        {
            //AllowRefresh = <bool>,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
            IsPersistent = true,
        };

        public static void IsTokenValid(IHeaderDictionary headerDict, HttpContext httpContext)
        {
            if (headerDict == null)
                throw new Exception(HttpCodes.BAD_REQUEST.ToString());

            if (!headerDict.ContainsKey(AUTH_HTTP_TOKEN))
                throw new Exception(HttpCodes.UNATHORIZED.ToString());

            if (!httpContext.User.Identities.Any(x => x.AuthenticationType == AUTH_TOKEN))
                throw new Exception(HttpCodes.UNATHORIZED.ToString());

            if (!httpContext.User.HasClaim(AUTH_TOKEN, headerDict[AUTH_HTTP_TOKEN]))
                throw new Exception(HttpCodes.UNATHORIZED.ToString());
        }

        public static string CalculateMD5(string input)
        {

            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
