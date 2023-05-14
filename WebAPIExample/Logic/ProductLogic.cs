using WebAPIExample.Business.DataModels;
using WebAPIExample.Business.Enums;
using WebAPIExample.Business.Models;
using WebAPIExample.Data;

namespace WebAPIExample.Logic
{
    public class ProductLogic
    {
        public ProductResponse GetProduct(ProductRequestModel model)
        {
            List<Product> productDatabase = new ProductDatabase().GetProducts();

            var found = productDatabase.FirstOrDefault(e => e.ProductId == model.Id);
            
            if (found == null)
                throw new Exception(HttpCodes.NO_CONTENT.ToString());

            return new ProductResponse()
            {
                Product = found.Map(found)
            };
        }
        public ProductsResponse GetProducts(ProductsRequestModel model)
        {
            List<Product> productDatabase = new ProductDatabase().GetProducts();
            List<ProductDto> productDTOs = new List<ProductDto>();

            foreach (var id in model.Ids)
            {
                var found = productDatabase.FirstOrDefault(e => e.ProductId == id);

                if (found != null)
                    productDTOs.Add(found.Map(found));
            }

            return new ProductsResponse() { Products = productDTOs };

        }
        public ProductsResponse GetAllProducts()
        {
            List<Product> productDatabase = new ProductDatabase().GetProducts();
            List<ProductDto> productDTOs = new List<ProductDto>();

            foreach (var model in productDatabase)
                productDTOs.Add(model.Map(model));

            return new ProductsResponse() { Products = productDTOs };

        }
    }
}
