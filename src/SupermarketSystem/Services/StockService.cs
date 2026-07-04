using System;
using System.Collections.Generic;
using System.Linq;
using SupermarketSystem.Data;
using SupermarketSystem.Models;

namespace SupermarketSystem.Services
{
    public class StockService
    {
        private readonly SupermarketDbContext _context;

        public StockService(SupermarketDbContext context)
        {
            _context = context;
        }

        public void UpdateStock(int productId, int quantityChange)
        {
            var stock = _context.Stock.FirstOrDefault(s => s.ProductId == productId);

            if (stock == null)
            {
                stock = new Stock
                {
                    ProductId = productId,
                    Quantity = quantityChange
                };
                _context.Stock.Add(stock);
            }
            else
            {
                stock.Quantity += quantityChange;
            }

            _context.SaveChanges();
        }

        public List<Stock> GetLowStock(int threshold)
        {
            return _context.Stock
                .Where(s => s.Quantity <= threshold)
                .ToList();
        }
    }
}
