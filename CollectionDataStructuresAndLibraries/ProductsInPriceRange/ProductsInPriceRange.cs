using System;
using Wintellect.PowerCollections;

class ProductsInPriceRange
{
    static void Main()
    {
        Console.WriteLine("Generating product's list...");
        var produkts = new OrderedBag<Product>();
        Random rnd = new Random();
        for (int i = 0; i < 500000; i++)
        {
            int price = rnd.Next(1, 100001);
            string name = "product-" + i;
            Product product = new Product(name, price);
            produkts.Add(product);
        }

        Console.WriteLine("Searching 20 products in range 10257 - 11336 lv");
        Predicate<Product> isProduktInRange = p => p.Price >= 10257 && p.Price <= 11336;
        var range = produkts.FindAll(isProduktInRange);
        int count = 0;
        foreach (var item in range)
        {
            Console.WriteLine(item);
            ++count;
            if (count == 20)
            {
                return;
            }
        }
    }
}