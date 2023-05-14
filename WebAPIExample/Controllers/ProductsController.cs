using Microsoft.AspNetCore.Mvc;
using WebAPIExample.Business.Helpers;
using WebAPIExample.Business.Models;
using WebAPIExample.Logic;

namespace WebAPIExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(ILogger<LoginController> logger)
            : base(logger) { }


        [HttpGet]
        [Route("GetProductById")]
        public IActionResult ById([FromQuery] ProductRequestModel productRequestModel)
        {
            try
            {
                Authentication.IsTokenValid(Request.Headers, HttpContext);
                RequestValidator.Validate(productRequestModel);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                ProductResponse response = new ProductLogic().GetProduct(productRequestModel);

                return Content(response.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetsProductById")]
        public IActionResult ByIds([FromQuery] ProductsRequestModel productRequestModel)
        {
            try
            {
                Authentication.IsTokenValid(Request.Headers, HttpContext);
                RequestValidator.Validate(productRequestModel);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                ProductsResponse response = new ProductLogic().GetProducts(productRequestModel);

                return Content(response.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAll()
        {
            try
            {
                Authentication.IsTokenValid(Request.Headers, HttpContext);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                ProductsResponse response = new ProductLogic().GetAllProducts();

                return Content(response.ToJson());
            }
            catch (Exception ex)
            {
                return HttpResponseHandler.DetermineResponse(ex.Message);
            }
        }
    }
}
