using System.ComponentModel.DataAnnotations;
using WebAPIExample.Business.Enums;
namespace WebAPIExample.Business.DataModels
{
    public class Product : DTO<Product, ProductDto>
    {
        [Key]
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0.00;

        public Product(Guid productId, string name, string description, double price)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
        }

        public override ProductDto Map(Product item)
        {
            if (item == null)
                throw new Exception(HttpCodes.INTERNAL_SERVER_ERROR.ToString());

            ProductDto dto = new ProductDto();

            dto.ProductId = item.ProductId;
            dto.Name = item.Name;
            dto.Description = item.Description;
            dto.Price = item.Price;

            return dto;
        }

        public override List<ProductDto> MapToList(List<Product> models)
        {
            List<ProductDto> list = new List<ProductDto>();

            foreach (var model in models)
                list.Add(Map(model));

            return list;
        }
    }
}
