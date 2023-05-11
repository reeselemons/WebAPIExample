using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Interfaces;
using WebAPIExample.Business.Models;
using WebAPIExample.Data;
using static WebAPIExample.Business.Constants.Auth;
using static WebAPIExample.Business.Helpers.Authentication;

namespace WebAPIExample.Logic
{
    public class ProductLogic
    {
        public ProductResponse GetProduct(ProductRequestModel model)
        {
            List<Product> productDatabase = new ProductDatabase().GetProducts();

            return new ProductResponse()
            {
                Product = productDatabase.FirstOrDefault(e => e.ProductId == model.Id)
            };
        }
        public ProductsResponse GetProducts(ProductsRequestModel model)
        {
            List<Product> productDatabase = new ProductDatabase().GetProducts();
            List<Product> products = new List<Product>();

            foreach (var id in model.Ids)
            {
                var found = productDatabase.FirstOrDefault(e => e.ProductId == id);

                if (found != null)
                    products.Add(found);
            }

            return new ProductsResponse() { Products = products };

        }
        public ProductsResponse GetAllProducts()
        {
            List<Product> productDatabase = new ProductDatabase().GetProducts();

            return new ProductsResponse() { Products = productDatabase };

        }
    }
}
