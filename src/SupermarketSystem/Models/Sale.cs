namespace SupermarketSystem.Models
{
    public class Sale
    {
        public int Id { get; set; }          // Unique sale number
        public string ProductBarcode { get; set; }  // Which product was sold
        public int Quantity { get; set; }    // How many items
        public double TotalPrice { get; set; } // Total price of the sale
    }
}
