using FurniturePOS.Services;
using FurniturePOS.Utils;

FurnitureManager manager = new FurnitureManager();

bool running = true;

while (running)
{
    Menu.Display();

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            manager.AddFurniture();
            break;

        case "2":
            manager.ShowAll();
            break;

        case "3":
            manager.DeleteFurniture();
            break;

        case "4":
            manager.OpenFurniture();
            break;

        case "5":
            manager.CopyFurniture();
            break;

        case "6":
            manager.PasteFurniture();
            break;

        case "7":
            Console.WriteLine("Sort A-Z (Coming Soon)");
            break;

        case "8":
            Console.WriteLine("Sort Z-A (Coming Soon)");
            break;

        case "9":
            Console.WriteLine("Modify Last (Coming Soon)");
            break;

        case "0":
            running = false;
            Console.WriteLine("Thank you for using Furniture POS!");
            break;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
