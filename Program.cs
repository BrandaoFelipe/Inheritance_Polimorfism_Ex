using Inheritance_Polimorfism_Ex.Entities;
using System.Globalization;
internal class Program
{
    private static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Product #{i} data:");
            Console.Write("Common, used or imported (c/u/i)? ");

            char c = char.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (c == 'i' || c == 'I')
            {
                Console.Write("Customs fee: ");
                double customs = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                products.Add(new ImportedProduct(name, price, customs));
            }
            else if (c == 'u' || c == 'U')
            {
                Console.Write("Manufacture date: ");
                DateTime manu = DateTime.Parse(Console.ReadLine());
                products.Add(new UsedProduct(name, price, manu));
            }
            else
            {
                products.Add(new Product(name, price));
            }
        }
        Console.WriteLine();
        Console.WriteLine("PRICE TAGS: ");
        
        foreach(Product product in products)
        {
            Console.WriteLine(product.PriceTag().ToString());
        }
    }
}