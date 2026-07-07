using FurniturePOS.Models;

namespace FurniturePOS.Services;

public class FurnitureManager
{
    private List<Furniture> furnitureList = new();
    private Furniture? clipboard;
    private Furniture? FindFurnitureById(int id)
    {
        return furnitureList.Find(f => f.Id == id);
    }
    private void ReorderIds()
    {
        for (int i = 0; i < furnitureList.Count; i++)
        {
            furnitureList[i].Id = i + 1;
        }
    }
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
    public void DeleteFurniture()
    {
        
        Console.Clear();

        Console.WriteLine("===== Delete Furniture =====\n");

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
        

        Console.Write("Enter Furniture ID: ");


        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Furniture? furniture = FindFurnitureById(id);

        if (furniture == null)
        {
            Console.WriteLine("Furniture not found!");
            return;
        }

        furnitureList.Remove(furniture);

        ReorderIds();

        Console.WriteLine("\nFurniture deleted successfully!");
    }
    public void OpenFurniture()
    {
        Console.Clear();

        Console.WriteLine("===== Open Furniture =====\n");

        Console.Write("Enter Furniture ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Furniture? furniture = FindFurnitureById(id);

        if (furniture == null)
        {
            Console.WriteLine("Furniture not found!");
            return;
        }

        Console.WriteLine("\n===== Furniture Details =====");
        Console.WriteLine($"ID       : {furniture.Id}");
        Console.WriteLine($"Name     : {furniture.Name}");
        Console.WriteLine($"Category : {furniture.Category}");
        Console.WriteLine($"Price    : Rp {furniture.Price:N0}");
        Console.WriteLine($"Stock    : {furniture.Stock}");
    }
    public void CopyFurniture()
    {
        Console.Clear();

        Console.WriteLine("===== Copy Furniture =====\n");

        Console.Write("Enter Furniture ID: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Furniture? furniture = FindFurnitureById(id);

        if (furniture == null)
        {
            Console.WriteLine("Furniture not found!");
            return;
        }

        clipboard = new Furniture
        {
            Name = furniture.Name,
            Category = furniture.Category,
            Price = furniture.Price,
            Stock = furniture.Stock
        };

        Console.WriteLine($"\n'{clipboard.Name}' copied successfully!");
    }
    public void PasteFurniture()
    {
        Console.Clear();

        Console.WriteLine("===== Paste Furniture =====\n");

        if (clipboard == null)
        {
            Console.WriteLine("Clipboard is empty!");
            return;
        }

        Furniture newFurniture = new Furniture
        {
            Id = furnitureList.Count + 1,
            Name = $"{clipboard.Name} Copy {furnitureList.Count}",
            Category = clipboard.Category,
            Price = clipboard.Price,
            Stock = clipboard.Stock
        };

        furnitureList.Add(newFurniture);

        Console.WriteLine("Furniture pasted successfully!");
    }

}
