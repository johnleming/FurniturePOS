namespace FurniturePOS.Models;

public class Furniture
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Category { get; set; } = "";

    public double Price { get; set; }

    public int Stock { get; set; }
}