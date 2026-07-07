using FurniturePOS.Models;

namespace FurniturePOS.Services;

public class FurnitureManager
{
    private List<Furniture> furnitureList = new();

    public FurnitureManager()
    {
        furnitureList.Add(new Furniture
        {
            Id = 1,
            Name = "Office Chair",
            Category = "Chair",
            Price = 700000,
            Stock = 5
        });

        furnitureList.Add(new Furniture
        {
            Id = 2,
            Name = "Wood Table",
            Category = "Table",
            Price = 1500000,
            Stock = 3
        });
    }

    public void ShowAll()
    {
        Console.Clear();

        Console.WriteLine("===== Furniture List =====\n");

        if (furnitureList.Count == 0)
        {
            Console.WriteLine("No furniture available.");
            return;
        }

        foreach (var item in furnitureList)
        {
            Console.WriteLine($"ID       : {item.Id}");
            Console.WriteLine($"Name     : {item.Name}");
            Console.WriteLine($"Category : {item.Category}");
            Console.WriteLine($"Price    : Rp {item.Price:N0}");
            Console.WriteLine($"Stock    : {item.Stock}");
            Console.WriteLine("------------------------------");
        }
    }
    public void AddFurniture ()
    {
        Console.Clear();

        Console.WriteLine("===== Add Furniture =====\n");

        Console.Write("Furniture Name : ");
        string name = Console.ReadLine()!;

        Console.Write("Category       : ");
        string category = Console.ReadLine()!;

        double price;
        while (true)
        {
            Console.Write("Price          : ");
            if (double.TryParse(Console.ReadLine(), out price))
                break;

            Console.WriteLine("Invalid price. Please enter a number.");
        }

        int stock;
        while (true)
        {
            Console.Write("Stock          : ");
            if (int.TryParse(Console.ReadLine(), out stock))
                break;

            Console.WriteLine("Invalid stock. Please enter a number.");
        }
        Furniture furniture = new Furniture
        {
            Id = furnitureList.Count + 1,
            Name = name,
            Category = category,
            Price = price,
            Stock = stock
        };
        furnitureList.Add(furniture);

        Console.WriteLine("\nFurniture added successfully!");
    }
}
