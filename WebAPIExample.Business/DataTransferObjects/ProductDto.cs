using System.ComponentModel.DataAnnotations;
namespace WebAPIExample.Business.DataModels
{
    public class ProductDto : Shared
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; } = 0.00;
    }
}
