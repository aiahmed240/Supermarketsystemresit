using SupermarketSystem.Models;

namespace SupermarketSystem.Services
{
    public class StockService
    {
        private readonly List<Stock> _stockItems = new();

        public void AddStock(Stock stock)
        {
            _stockItems.Add(stock);
        }

        public List<Stock> GetAllStock()
        {
            return _stockItems;
        }
    }
}
