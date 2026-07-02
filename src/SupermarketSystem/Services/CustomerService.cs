using SupermarketSystem.Models;

namespace SupermarketSystem.Services
{
    public class CustomerService
    {
        private readonly List<Customer> _customers = new();

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }
}
