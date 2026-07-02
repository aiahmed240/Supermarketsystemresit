using SupermarketSystem.Models;
using SupermarketSystem.Services;
using Xunit;

namespace SupermarketSystem.Tests
{
    public class StockServiceTests
    {
        [Fact]
        public void AddStock_ShouldStoreStockItem()
        {
            var service = new StockService();

            var stockItem = new Stock
            {
                ProductBarcode = "123",
                Quantity = 50
            };

            service.AddStock(stockItem);

            var allStock = service.GetAllStock();

            Assert.Single(allStock);
            Assert.Equal(50, allStock[0].Quantity);
        }
    }
}
