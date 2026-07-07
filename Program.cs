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
            manager.SortAscending();
            break;

        case "8":
            manager.SortDescending();
            break;

        case "9":
            manager.Modify();
            break;

        case "10":
            manager.ModifyLastFurniture();
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
