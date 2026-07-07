namespace FurniturePOS.Utils;



public static class Menu
{
    public static void Display()
    {
        Console.Clear();

        Console.WriteLine("==============================");
        Console.WriteLine("     Furniture POS System");
        Console.WriteLine("==============================");
        Console.WriteLine("1. Add Furniture");
        Console.WriteLine("2. Show All Furniture");
        Console.WriteLine("3. Delete Furniture");
        Console.WriteLine("4. Open Furniture");
        Console.WriteLine("5. Copy Furniture");
        Console.WriteLine("6. Paste Furniture");
        Console.WriteLine("7. Sort A-Z");
        Console.WriteLine("8. Sort Z-A");
        Console.WriteLine("9. Modify");
        Console.WriteLine("10. Modify Last");
        Console.WriteLine("0. Exit");
        Console.WriteLine("==============================");
        Console.Write("Choose: ");
    }
}

