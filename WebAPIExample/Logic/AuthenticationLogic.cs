using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public async Task<AuthorizeUserResponseModel> Login(HttpContext httpContext, AuthRequestModel model)
        {
            List<Member> memberDatabase = new MemberDatabase().GetMembers();

            var found = memberDatabase.Where(e => e.Username == model.Username && e.SaltedPassword == CalculateMD5(model.Password)).FirstOrDefault();

            if (found == null)
                throw new Exception(HttpCodes.UNATHORIZED.ToString());

            var claims = new List<Claim>();
            var authUser = Guid.NewGuid().ToString();
            var authToken = Guid.NewGuid().ToString();

            claims.Add(new Claim(ClaimTypes.Name, found.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, AUTHENTICATED));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, authToken));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var user = new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, AuthProperties);

            return new AuthorizeUserResponseModel()
            {
                Status = AuthorizedStatus.authorized,
                UserId = authUser,
                Token = authToken,
            };
        }
        public void Logout(HttpContext httpContext)
        {
            httpContext.SignOutAsync();
        }

    }
}
