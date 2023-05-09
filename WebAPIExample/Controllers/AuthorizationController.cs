using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Models;
using WebAPIExample.Business.Helpers;
using static WebAPIExample.Business.Constants.Auth;

namespace WebAPIExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private AuthenticationProperties authProperties => new AuthenticationProperties
        {
            //AllowRefresh = <bool>,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
            IsPersistent = true,
        };

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Authorize")]
        public async Task<IActionResult> Post([FromBody] AuthRequestModel authRequestModel)
        {
            try
            {
                RequestValidator.Validate(authRequestModel);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var claims = new List<Claim>();
                var authUser = Guid.NewGuid().ToString();
                var authToken = Guid.NewGuid().ToString();

                claims.Add(new Claim(AUTH_USER_ID, authUser));
                claims.Add(new Claim(AUTH_TOKEN, authToken));

                var identity = new ClaimsIdentity(claims, AUTH_SCHEME);
                var user = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(AUTH_SCHEME, user, authProperties);

                var response = new AuthResponseModel()
                {
                    Status = AuthorizedStatus.success,
                    UserId = authUser,
                    Token = authToken,
                };

                return Content(response.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }
    }
}