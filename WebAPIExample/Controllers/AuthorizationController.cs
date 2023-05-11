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


        [HttpGet]
        [Route("IsAuthorized")]
        public IActionResult IsAuthorized()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }
                if (!HttpContext.User.Identities.Any(x => x.AuthenticationType == AUTH_TOKEN))
                {

                }
                AuthenticationLogic logic = new AuthenticationLogic();
                
                return Content(new IsAuthorizedResponseModel()
                {
                    Status = HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated 
                    ? AuthorizedStatus.authorized : AuthorizedStatus.unAuthorized
                }.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }

        [HttpPost]
        [Route("AuthorizeUser")]
        public async Task<IActionResult> AuthorizeUser([FromBody] AuthRequestModel authRequestModel)
        {
            try
            {
                 RequestValidator.Validate(authRequestModel);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }
                AuthorizeUserResponseModel response = await new AuthenticationLogic().Login(HttpContext, authRequestModel);

                return Content(response.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            try
            {
                Authentication.IsTokenValid(Request.Headers, HttpContext);
                new AuthenticationLogic().Logout(HttpContext);

                return Ok();
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }
    }
}