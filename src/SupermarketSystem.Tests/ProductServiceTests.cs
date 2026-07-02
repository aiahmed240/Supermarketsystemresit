using SupermarketSystem.Models;
using SupermarketSystem.Services;
using Xunit;

namespace SupermarketSystem.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void AddProduct_ShouldStoreProduct()
        {
            var service = new ProductService();

            var product = new Product
            {
                Barcode = "111",
                Name = "Bread",
                Price = 1.20,
                Stock = 5
            };

            service.AddProduct(product);

            var allProducts = service.GetAllProducts();

            Assert.Single(allProducts);
            Assert.Equal("Bread", allProducts[0].Name);
        }
    }
}
