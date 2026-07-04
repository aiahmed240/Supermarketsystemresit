using System;
using System.Collections.Generic;
using System.Linq;
using SupermarketSystem.Data;
using SupermarketSystem.Models;

namespace SupermarketSystem.Services
{
    public class SearchService
    {
        private readonly SupermarketDbContext _context;

        public SearchService(SupermarketDbContext context)
        {
            _context = context;
        }

        public Product? SearchByName(string name)
        {
            return _context.Products
                .FirstOrDefault(p => p.Title.ToLower().Contains(name.ToLower()));
        }

        public List<Product> SearchByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }
    }
}
