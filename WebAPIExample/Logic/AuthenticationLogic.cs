using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Interfaces;
using WebAPIExample.Business.Models;
using WebAPIExample.Data;
using static WebAPIExample.Business.Constants.Auth;
using static WebAPIExample.Business.Helpers.Authentication;

namespace WebAPIExample.Logic
{
    public class AuthenticationLogic
    {
        public async Task<AuthResponseModel> Login(HttpContext httpContext, AuthRequestModel model)
        {
            List<Member> memberDatabase = new MemberDatabase().GetMembers();

            var found = memberDatabase.Where(e => e.Username == model.Username && e.SaltedPassword == CalculateMD5(model.Password)).FirstOrDefault();

            if (found == null)
                throw new Exception(HttpCodes.UNATHORIZED.ToString());

            var claims = new List<Claim>();
            var authUser = Guid.NewGuid().ToString();
            var authToken = Guid.NewGuid().ToString();

            claims.Add(new Claim(AUTH_USER_ID, authUser));
            claims.Add(new Claim(AUTH_TOKEN, authToken));

            var identity = new ClaimsIdentity(claims, AUTH_SCHEME);
            var user = new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(AUTH_SCHEME, user, Authentication.AuthProperties);

            return new AuthResponseModel()
            {
                Status = AuthorizedStatus.success,
                UserId = authUser,
                Token = authToken,
            };
        }
    }
}
