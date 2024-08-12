using System.Linq;
using System.Security.Cryptography.X509Certificates;
class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        new FoodProduct("Яблоки", 40, ProductCategory.Fruits);
        new FoodProduct("Молоко", 75.50, ProductCategory.Dairy);
        new ElectronicProduct("Смартфон", 14999.99, ProductCategory.Electronics);
        new ElectronicProduct("Наушники", 5999.99, ProductCategory.Electronics);
        new ClothingProduct("Футболка", 1200, ProductCategory.Clothing);
        new ClothingProduct("Штаны", 750, ProductCategory.Clothing);

        Console.WriteLine("Список товаров:");
        foreach (Product product in products)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
        Console.WriteLine("\nТовары категории \"Электрика\":");
        var electronicProducts =products.Where(p => p.Category == ProductCategory.Electronics).ToList();
        foreach (Product product in electronicProducts) {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }
        // используем linq для поиска товаров по категории
        Console.WriteLine("\nТовары категории \"Электроника\":");
        var electronicProducts = products.Where(p => p.Category == ProductCategory.Electronics);
        foreach (Product product in electronicProducts)
        {
            Console.WriteLine($"{product.Name} - {product.Price}");
        }

        // используем цикл for для вывода названий товаров
        Console.WriteLine("\nНазвания товаров:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine(products[i].Name);
        }

        // проверяем, есть ли в наличии товар "Яблоки"
        bool hasApples = products.Any(p => p.Name == "Яблоки");
        Console.WriteLine($"\nЕсть ли в наличии \"Яблоки\": {hasApples}");
    }
}
    
public class Product
{
    public Product(string name, double price, ProductCategory category)
    {
        Name = name;
        Price = price;
        Category = category;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public ProductCategory Category { get; set; }


}
public class FoodProduct
{
    public FoodProduct(string name, double price, ProductCategory category);
}
public class ElectronicProduct
{
    public ElectronicProduct(string name, double price, ProductCategory category);
}
public class ClothingProduct : Product
{
    public ClothingProduct(string name, double price, ProductCategory category)
    : base(name, price);

}
public enum ProductCategory
{
    Fruits,
    Dairy,
    Electronics,
    Clothing

}