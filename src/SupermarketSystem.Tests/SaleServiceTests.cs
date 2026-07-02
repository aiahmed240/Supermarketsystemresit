using SupermarketSystem.Models;
using SupermarketSystem.Services;
using Xunit;

namespace SupermarketSystem.Tests
{
    public class SaleServiceTests
    {
        [Fact]
        public void AddSale_ShouldStoreSale()
        {
            var service = new SaleService();

            var sale = new Sale
            {
                Id = 1,
                ProductBarcode = "123",
                Quantity = 2,
                TotalPrice = 3.00
            };

            service.AddSale(sale);

            var allSales = service.GetAllSales();

            Assert.Single(allSales);
            Assert.Equal(1, allSales[0].Id);
        }
    }
}
