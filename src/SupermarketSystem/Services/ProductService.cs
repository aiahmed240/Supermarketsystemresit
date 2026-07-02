using SupermarketSystem.Models;

namespace SupermarketSystem.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new();

        public void AddProduct(Product product)
        {
            if (_products.Any(p => p.Barcode == product.Barcode))
                throw new Exception("A product with this barcode already exists.");

            _products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }
    }
}

