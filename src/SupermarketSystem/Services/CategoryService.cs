using SupermarketSystem.Data;
using SupermarketSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketSystem.Services
{
    public class CategoryService
    {
        private readonly SupermarketDbContext _context;

        public CategoryService(SupermarketDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
