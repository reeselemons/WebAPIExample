using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Models;
using WebAPIExample.Business.Helpers;
using static WebAPIExample.Business.Constants.Auth;
using WebAPIExample.Logic;
using System.Net.Http;

namespace WebAPIExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        public LoginController(ILogger<LoginController> logger)
            : base(logger) { }

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
                if (!HttpContext.User.Identities.Any(x => x.AuthenticationType == AUTH_TOKEN))
                {

                }
                AuthenticationLogic logic = new AuthenticationLogic();
                AuthResponseModel response = await logic.Login(HttpContext, authRequestModel);
                if (!HttpContext.User.Identities.Any(x => x.AuthenticationType == AUTH_TOKEN))
                {

                }
                return Content(response.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }
    }
}