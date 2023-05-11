using WebAPIExample.Business.DataModels;

namespace WebAPIExample.Data
{
    public class ProductDatabase
    {
        public List<Product> GetProducts() => new List<Product>()
        {
            new Product(Guid.NewGuid(), "Bowling Ball", "description 1", 30.34),
            new Product(Guid.NewGuid(), "Blender", "description 2", 15.50),
            new Product(Guid.NewGuid(), "Toilet", "description 3", 60.34),
        };
    }
}