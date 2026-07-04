namespace SupermarketSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string ExpiryDate { get; set; }
        public int QuantityInStock { get; set; }
    }
}
