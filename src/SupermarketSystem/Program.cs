using System;
using System.Collections.Generic;
using System.Linq;
using SupermarketSystem.Data;
using SupermarketSystem.Models;
using SupermarketSystem.Services;

class Program
{
    static void Main(string[] args)
    {
        using var context = new SupermarketDbContext();

        var productService = new ProductService(context);
        var stockService = new StockService(context);
        var saleService = new SaleService(context);
        var searchService = new SearchService(context);

        while (true)
        {
            Console.WriteLine("\n=== SUPERMARKET MANAGEMENT SYSTEM ===");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search Product");
            Console.WriteLine("6. View Low Stock");
            Console.WriteLine("7. Record Sale");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                
                case "1":
                    var products = productService.GetAllProducts();
                    Console.WriteLine("\n=== ALL PRODUCTS ===");
                    foreach (var p in products)
                    {
                        Console.WriteLine($"ID: {p.ProductId}, {p.Title}, £{p.Price}, Qty: {p.QuantityInStock}");
                    }
                    break;

               
                case "2":
                    Console.WriteLine("\nEnter product name:");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter brand:");
                    string brand = Console.ReadLine();

                    Console.WriteLine("Enter price:");
                    decimal price = decimal.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Enter category ID:");
                    int categoryId = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Enter supplier ID:");
                    int supplierId = int.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine("Enter expiry date (YYYY-MM-DD):");
                    string expiryDate = Console.ReadLine();

                    Console.WriteLine("Enter quantity in stock:");
                    int quantity = int.Parse(Console.ReadLine() ?? "0");

                    var newProduct = new Product
                    {
                        Title = name,
                        Brand = brand,
                        Price = price,
                        CategoryId = categoryId,
                        SupplierId = supplierId,
                        ExpiryDate = expiryDate,
                        QuantityInStock = quantity
                    };

                    productService.AddProduct(newProduct);

                    
                    stockService.UpdateStock(newProduct.ProductId, quantity);

                    Console.WriteLine("Product added successfully.");
                    break;

                
                case "3":
                    Console.WriteLine("Enter Product ID to edit:");
                    int editId = int.Parse(Console.ReadLine() ?? "0");

                    var productToEdit = productService.GetProduct(editId);

                    if (productToEdit == null)
                    {
                        Console.WriteLine("Product not found.");
                        break;
                    }

                    Console.WriteLine($"Editing Product: {productToEdit.Title}");

                    Console.WriteLine("Enter new name (leave blank to keep current):");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                        productToEdit.Title = newName;

                    Console.WriteLine("Enter new brand (leave blank to keep current):");
                    string newBrand = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newBrand))
                        productToEdit.Brand = newBrand;

                    Console.WriteLine("Enter new price (leave blank to keep current):");
                    string newPrice = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPrice))
                        productToEdit.Price = decimal.Parse(newPrice);

                    Console.WriteLine("Enter new quantity (leave blank to keep current):");
                    string newQty = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newQty))
                        productToEdit.QuantityInStock = int.Parse(newQty);

                    context.SaveChanges();
                    Console.WriteLine("Product updated successfully.");
                    break;

                
                case "4":
                    Console.WriteLine("Enter Product ID to delete:");
                    int deleteId = int.Parse(Console.ReadLine() ?? "0");

                    var productToDelete = productService.GetProduct(deleteId);

                    if (productToDelete == null)
                    {
                        Console.WriteLine("Product not found.");
                        break;
                    }

                    productService.DeleteProduct(deleteId);
                    Console.WriteLine("Product deleted successfully.");
                    break;

               
                case "5":
                    Console.WriteLine("Enter product name to search:");
                    string searchName = Console.ReadLine();

                    var found = searchService.SearchByName(searchName);

                    if (found == null)
                    {
                        Console.WriteLine("No product found.");
                    }
                    else
                    {
                        Console.WriteLine($"Found: ID {found.ProductId}, {found.Title}, £{found.Price}, Qty: {found.QuantityInStock}");
                    }
                    break;

               
                case "6":
                    Console.WriteLine("Enter low-stock threshold:");
                    int threshold = int.Parse(Console.ReadLine() ?? "0");

                    var lowStock = stockService.GetLowStock(threshold);

                    Console.WriteLine("\n=== LOW STOCK ITEMS ===");
                    foreach (var s in lowStock)
                    {
                        var p = context.Products.FirstOrDefault(p => p.ProductId == s.ProductId);
                        Console.WriteLine($"Product: {p?.Title}, Qty: {s.Quantity}");
                    }
                    break;

                case "7":
                    var saleItems = new List<(int productId, int quantity)>();

                    while (true)
                    {
                        Console.WriteLine("Enter product ID (blank to finish):");
                        var pidText = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(pidText)) break;

                        int pid = int.Parse(pidText);

                        Console.WriteLine("Enter quantity:");
                        int qty = int.Parse(Console.ReadLine() ?? "0");

                        saleItems.Add((pid, qty));

                    
                        stockService.UpdateStock(pid, -qty);
                    }

                    if (saleItems.Count > 0)
                    {
                        saleService.RecordSale(saleItems);
                        Console.WriteLine("Sale recorded successfully.");
                    }
                    break;

             
                case "8":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
