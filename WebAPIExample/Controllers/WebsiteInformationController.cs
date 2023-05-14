﻿using Microsoft.AspNetCore.Mvc;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Models;
using WebAPIExample.Logic;

namespace WebAPIExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebsiteInformationController : BaseController
    {
        public WebsiteInformationController(ILogger<LoginController> logger)
            : base(logger) { }


        [HttpGet]
        [Route("GetWebsiteById")]
        public IActionResult ById([FromQuery] WebsiteInformationRequestModel websiteInformationRequestModel)
        {
            try
            {
                Authentication.IsTokenValid(Request.Headers, HttpContext);
                RequestValidator.Validate(websiteInformationRequestModel);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                WebsiteInformationResponseModel response = new WebsiteInformationLogic().GetWebsite(websiteInformationRequestModel);

                return Content(response.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }
    }
}
