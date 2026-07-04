using System;
using System.Collections.Generic;
using System.Linq;
using SupermarketSystem.Data;
using SupermarketSystem.Models;

namespace SupermarketSystem.Services
{
    public class SaleService
    {
        private readonly SupermarketDbContext _context;

        public SaleService(SupermarketDbContext context)
        {
            _context = context;
        }

        public void RecordSale(List<(int productId, int quantity)> items)
        {
            decimal total = 0m;

            foreach (var item in items)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == item.productId);
                if (product != null)
                {
                    total += product.Price * item.quantity;
                }
            }

            var sale = new Sale
            {
                Date = DateTime.Now,
                TotalAmount = total
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();

            foreach (var item in items)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == item.productId);
                if (product == null) continue;

                var saleItem = new SaleItem
                {
                    SaleId = sale.SaleId,
                    ProductId = item.productId,
                    Quantity = item.quantity,
                    Price = product.Price
                };

                _context.SaleItems.Add(saleItem);
            }

            _context.SaveChanges();
        }
    }
}
