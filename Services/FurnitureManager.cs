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
        Console.WriteLine("\n===== Furniture List =====");

        foreach (var item in furnitureList)
        {
            Console.WriteLine($"ID       : {item.Id}");
            Console.WriteLine($"Name     : {item.Name}");
            Console.WriteLine($"Category : {item.Category}");
            Console.WriteLine($"Price    : Rp {item.Price:N0}");
            Console.WriteLine($"Stock    : {item.Stock}");
            Console.WriteLine("----------------------------");
        }
    }
}