using SupermarketSystem.Models;

namespace SupermarketSystem.Services
{
    public class SaleService
    {
        private readonly List<Sale> _sales = new();

        public void AddSale(Sale sale)
        {
            _sales.Add(sale);
        }

        public List<Sale> GetAllSales()
        {
            return _sales;
        }
    }
}
