using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SupermarketSystem.Data
{
    public class SupermarketDbContextFactory : IDesignTimeDbContextFactory<SupermarketDbContext>
    {
        public SupermarketDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SupermarketDbContext>();
            optionsBuilder.UseSqlite("Data Source=supermarket.db");

            return new SupermarketDbContext();
        }
    }
}
