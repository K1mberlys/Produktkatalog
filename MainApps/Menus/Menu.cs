namespace MainApps.Menus;

internal class Menu 
{
    private readonly ProductMenu _productMenu = new ProductMenu(); 
    public bool MainMenu() 
    {
        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.ForegroundColor = ConsoleColor.Black;  

        Console.Clear();
        Console.WriteLine("MAIN MENU");
        Console.WriteLine("\n1.".PadRight(5) + "Create A New Perfume");
        Console.WriteLine("2.".PadRight(5) + "View All Perfumes");
        Console.WriteLine("3.".PadRight(5) + "View Single Perfume");
        Console.WriteLine("4.".PadRight(5) + "Delete A Perfume");
        Console.WriteLine("5.".PadRight(5) + "Exit program");
        Console.Write("\nEnter your choice: "); 

        var option = Console.ReadLine();

        switch (option) 
        {
            case "1":
                _productMenu.CreateMenu();
                break;

            case "2":
                _productMenu.ViewAllMenu();
                break;

            case "3":
                _productMenu.ViewSingleMenu();
                break;

            case "4":
                _productMenu.DeleteMenu();
                break;

            case "5":
                return false;

            default: 
                Console.WriteLine("\nIncorrect choice, please try again by pressing any key.");
                Console.ReadKey();
                break;

                

        }
        return true;
    }
}

