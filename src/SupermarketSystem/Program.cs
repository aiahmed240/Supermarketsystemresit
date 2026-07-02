using SupermarketSystem.Models;
using SupermarketSystem.Services;

// ---------------------------
// PRODUCT TEST
// ---------------------------

var productService = new ProductService();

var milk = new Product
{
    Barcode = "123",
    Name = "Milk",
    Price = 1.50,
    Stock = 10
};

productService.AddProduct(milk);

foreach (var p in productService.GetAllProducts())
{
    Console.WriteLine($"{p.Name} - £{p.Price} - Stock: {p.Stock}");
}

// ---------------------------
// SALE TEST
// ---------------------------

var saleService = new SaleService();

var sale = new Sale
{
    Id = 1,
    ProductBarcode = "123",
    Quantity = 2,
    TotalPrice = 3.00
};

saleService.AddSale(sale);

foreach (var s in saleService.GetAllSales())
{
    Console.WriteLine($"Sale #{s.Id} - {s.ProductBarcode} - Qty: {s.Quantity} - £{s.TotalPrice}");
}

// ---------------------------
// CUSTOMER TEST
// ---------------------------

var customerService = new CustomerService();

var customer = new Customer
{
    Id = 1,
    Name = "Dev Patel",
    Email = "dev.patel@yahoo.com"
};

customerService.AddCustomer(customer);

foreach (var c in customerService.GetAllCustomers())
{
    Console.WriteLine($"Customer #{c.Id} - {c.Name} - {c.Email}");
}

// ---------------------------
// STOCK TEST
// ---------------------------

var stockService = new StockService();

var stockItem = new Stock
{
    ProductBarcode = "123",
    Quantity = 50
};

stockService.AddStock(stockItem);

foreach (var st in stockService.GetAllStock())
{
    Console.WriteLine($"Stock for {st.ProductBarcode} - Qty: {st.Quantity}");
}
