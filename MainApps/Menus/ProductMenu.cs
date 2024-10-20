using Resources.Enums;
using Resources.Models;
using Resources.Services;
namespace MainApps.Menus;

internal class ProductMenu 
{
    private readonly ProductService _productService = new ProductService(); 
    public void CreateMenu()
    {
        Product product = new Product(); 

        Console.Clear();
        Console.WriteLine("Create A New Perfume");

        Console.Write("Enter Product Name: ");
        product.ProductName = Console.ReadLine() ?? "";  

        Console.Write("Enter Bottle Size, 30ml, 50ml or 100ml: ");
        product.ProductSize = Console.ReadLine() ?? "";

        Console.Write("Enter Perfume Notes: ");
        product.ProductDescription = Console.ReadLine() ?? "";

        Console.Write("Enter Product Price (SEK): ");
        product.ProductPrice = Console.ReadLine() ?? "0"; 

        var result = _productService.AddToList(product); 
         
        switch (result) 
        {
            case ResultStatus.Success:
                Console.WriteLine("\nProduct was successfully created.");
                break;

            case ResultStatus.Exists:
                Console.WriteLine("\nProduct with the same name already exists.");
                break;

            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while creating the product.");
                break;

            case ResultStatus.FinishedWithErrors:
                Console.WriteLine("\nProduct was successfully created, but product list was not saved.");
                break;

        }


        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public void ViewAllMenu()
    {
        var productList = _productService.GetAllProducts(); 

        Console.Clear();
        Console.WriteLine("View All Perfumes\n"); 

        if(productList.Any()) 
        {

            foreach (var product in productList) 
            {
                Console.WriteLine($"{product.ProductName} <{product.ProductSize}>"); 
                Console.WriteLine($"Notes: {product.ProductDescription}");
                Console.WriteLine($"Id: {product.Id}\n");
                Console.WriteLine($"Price (SEK): {product.ProductPrice}\n"); 
            }
        }
        else 
        {
            Console.WriteLine("No products in List");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public void ViewSingleMenu()
    {
        Console.Clear();
        Console.WriteLine("View Single Perfume\n");

        Console.Write("Enter Product Name: ");
        var productName = Console.ReadLine() ?? "";

        var product = _productService.GetProduct(productName);

        if(product != null )
        {
            Console.Clear();
            Console.WriteLine($"Viewing details for fragrance {product.ProductName}\n");

            Console.WriteLine($"Name: ".PadRight(10) + $"{product.ProductName}");
            Console.WriteLine($"Size:".PadRight(10) + $"{product.ProductSize}");
            Console.WriteLine($"Notes:".PadRight(10) + $"{product.ProductDescription}");
            Console.WriteLine($"Id:".PadRight(10) + $"{product.Id}\n");
            Console.WriteLine($"Price (SEK):".PadRight(10) + $"{product.ProductPrice}\n"); 
        }
        else
        {
            Console.WriteLine("No product was found.\n");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    internal void DeleteMenu()
    {

        Console.Clear();
        Console.WriteLine("Delete Product\n");

        Console.Write("Enter Product Name: ");
        var productName = Console.ReadLine() ?? "";

        var result = _productService.DeleteProduct(productName);

        switch (result) 
        {
            case ResultStatus.Success:
                Console.WriteLine("Product was successfully deleted.");
                break;

            case ResultStatus.NotFound:
                Console.WriteLine("Product was not found.");
                break;

            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while deliting the product.");
                break;

            case ResultStatus.FinishedWithErrors:
                Console.WriteLine("\nProduct was successfully deleted. But product list was not saved.");
                break;

        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}
