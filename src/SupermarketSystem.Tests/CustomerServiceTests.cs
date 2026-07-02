using SupermarketSystem.Models;
using SupermarketSystem.Services;
using Xunit;

namespace SupermarketSystem.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void AddCustomer_ShouldStoreCustomer()
        {
            var service = new CustomerService();

            var customer = new Customer
            {
                Id = 1,
                Name = "Sarah Thompson",
                Email = "sarah.thompson@example.com"
            };

            service.AddCustomer(customer);

            var allCustomers = service.GetAllCustomers();

            Assert.Single(allCustomers);
            Assert.Equal("Sarah Thompson", allCustomers[0].Name);
        }
    }
}
