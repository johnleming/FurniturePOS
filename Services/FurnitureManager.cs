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
    private string ReadRequired(string label)
    {
        while (true)
        {
            Console.Write($"{label}: ");

            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input cannot be empty!");
            Console.ResetColor();
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

        furnitureList.Add(new Furniture
        {
            Id = 3,
            Name = "Metal Rack",
            Category = "Rack",
            Price = 800000,
            Stock = 6769
        });

        furnitureList.Add(new Furniture
        {
            Id = 4,
            Name = "Cupboard",
            Category = "Cupboard",
            Price = 1000000,
            Stock = 420
        });
    }
    public void ShowAll()
    {
        Console.Clear();

        Console.WriteLine("===== Furniture List =====\n");

        if (furnitureList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No furniture available.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(
            $"{"ID",-5} {"Name",-20} {"Category",-15} {"Price",-15} {"Stock",-5}");

        Console.WriteLine(new string('-', 65));

        foreach (var item in furnitureList)
        {
            Console.WriteLine(
                $"{item.Id,-5} {item.Name,-20} {item.Category,-15} Rp {item.Price,-10:N0} {item.Stock,-5}");
        }
    }
    public void AddFurniture ()
    {
        Console.Clear();

        Console.WriteLine("===== Add Furniture =====\n");

        string name = ReadRequired("Furniture Name");

        string category = ReadRequired("Category");

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No furniture available.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(
            $"{"ID",-5} {"Name",-20} {"Category",-15} {"Price",-15} {"Stock",-5}");

        Console.WriteLine(new string('-', 65));

        foreach (var item in furnitureList)
        {
            Console.WriteLine(
                $"{item.Id,-5} {item.Name,-20} {item.Category,-15} Rp {item.Price,-10:N0} {item.Stock,-5}");
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
    public void SortAscending()
    {
        Console.Clear();

        furnitureList = furnitureList
            .OrderBy(f => f.Name)
            .ToList();

        ReorderIds();

        Console.WriteLine("Furniture sorted A-Z successfully!");
    }
    public void SortDescending()
    {
        Console.Clear();

        furnitureList = [.. furnitureList.OrderByDescending(f => f.Name)];

        ReorderIds();

        Console.WriteLine("Furniture sorted Z-A successfully!");
    }

    public void Modify()
    {
        Console.Clear();

        Console.WriteLine("===== Modify Furniture =====");
        Console.WriteLine("===== Furniture List =====\n");

        if (furnitureList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No furniture available.");
            Console.ResetColor();
            return;
        }

        Console.WriteLine(
            $"{"ID",-5} {"Name",-20} {"Category",-15} {"Price",-15} {"Stock",-5}");

        Console.WriteLine(new string('-', 65));

        foreach (var item in furnitureList)
        {
            Console.WriteLine(
                $"{item.Id,-5} {item.Name,-20} {item.Category,-15} Rp {item.Price,-10:N0} {item.Stock,-5}");
        }
        Console.WriteLine("Choose which one do you wanna modify? Choose the ID");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        Furniture? ModFurniture = FindFurnitureById(id);

        if (ModFurniture == null)
        {
            Console.WriteLine("Furniture not found!");
            return;
        }

        ReorderIds();

        Console.WriteLine("\nFurniture modified successfully!");
    }
    public void ModifyLastFurniture()
    {
        Console.Clear();

        if (furnitureList.Count == 0)
        {
            Console.WriteLine("No furniture available!");
            return;
        }

        Furniture lastFurniture = furnitureList.Last();

        Console.WriteLine("===== Modify Last Furniture =====");
        Console.WriteLine($"Current Name     : {lastFurniture.Name}");
        Console.WriteLine($"Current Category : {lastFurniture.Category}");
        Console.WriteLine($"Current Price    : {lastFurniture.Price}");
        Console.WriteLine($"Current Stock    : {lastFurniture.Stock}");
        Console.WriteLine();

        Console.Write("New Name : ");
        lastFurniture.Name = Console.ReadLine()!;

        Console.Write("New Category : ");
        lastFurniture.Category = Console.ReadLine()!;

        double price;
        while (true)
        {
            Console.Write("New Price : ");
            if (double.TryParse(Console.ReadLine(), out price))
                break;

            Console.WriteLine("Invalid price!");
        }

        lastFurniture.Price = price;

        int stock;
        while (true)
        {
            Console.Write("New Stock : ");
            if (int.TryParse(Console.ReadLine(), out stock))
                break;

            Console.WriteLine("Invalid stock!");
        }

        lastFurniture.Stock = stock;

        Console.WriteLine("\nLast furniture updated successfully!");
    }
}
