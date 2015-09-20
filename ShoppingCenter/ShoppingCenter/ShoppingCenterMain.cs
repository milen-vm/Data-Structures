using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Text;

using Wintellect.PowerCollections;

class ShoppingCenterMain
{
    private const string PRODUCT_ADDED = "Product added";
    private const string X_PRODUCTS_DELETED = " products deleted";
    private const string NO_PRODUCTS_FOUND = "No products found";
    private const string INCORRECT_COMMAND = "Incorrect command";

    private static IShoppingCenter center = new ShoppingCenter();

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        int commandCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandCount; i++)
        {
            string command = Console.ReadLine();
            string commandResult = ProcessCommand(command);
            Console.WriteLine(commandResult);
        }
    }

    private static string ProcessCommand(string command)
    {
        int indexOfFirstSpace = command.IndexOf(' ');
        string method = command.Substring(0, indexOfFirstSpace);
        string parameterValues = command.Substring(indexOfFirstSpace + 1);
        var parameters = parameterValues.Split(new char [] {';'}, StringSplitOptions.RemoveEmptyEntries);

        switch (method)
        {
            case "AddProduct":
                return AddProduct(parameters[0], parameters[1], parameters[2]);
            case "DeleteProducts":
                return DeleteProducts(parameters);
            case "FindProductsByName":
                return FindProductsByName(parameters[0]);
            case "FindProductsByPriceRange":
                return FindProductsByPriceRange(parameters[0], parameters[1]);
            case "FindProductsByProducer":
                return FindProductsByProducer(parameters[0]);
            default:
                return INCORRECT_COMMAND;
        }
    }

    private static string FindProductsByProducer(string producer)
    {
        var productsCollection = center.FindProductByProducer(producer);
        string printedProducts = PrintProducts(productsCollection);

        return printedProducts;
    }

    private static string FindProductsByPriceRange(string startPrice, string endPrice)
    {
        var productsCollection = center.FindProductsByPriceRange(decimal.Parse(startPrice), decimal.Parse(endPrice));
        string printedProducts = PrintProducts(productsCollection);

        return printedProducts;
    }

    private static string FindProductsByName(string name)
    {
        var productsCollection = center.FindProductsByName(name);
        string printedProducts = PrintProducts(productsCollection);

        return printedProducts;
    }

    private static string PrintProducts(IEnumerable<Product> products)
    {
        if (products.Any())
        {
            var builder = new StringBuilder();
            foreach (var product in products)
            {
                builder.AppendLine(product.ToString());
            }

            string formatedProducts = builder.ToString().TrimEnd();

            return formatedProducts;
        }

        return NO_PRODUCTS_FOUND;
    }

    private static string DeleteProducts(string[] parameters)
    {
        int countDeleted;
        if (parameters.Length == 1)
        {
            countDeleted = center.DeleteProductsByProducer(parameters[0]);
        }
        else
        {
            countDeleted = center.DeleteProductsByNameAndProducer(parameters[0], parameters[1]);
        }

        if (countDeleted == 0)
        {
            return NO_PRODUCTS_FOUND;
        }
        else
        {
            return countDeleted + X_PRODUCTS_DELETED;
        }
    }

    private static string AddProduct(string name, string price, string producer)
    {
        center.AddProduct(name, price, producer);
        return PRODUCT_ADDED;
    }
}

public class ShoppingCenter : IShoppingCenter
{
    private readonly MultiDictionary<string, Product> productsByName =
        new MultiDictionary<string, Product>(true);
    private readonly MultiDictionary<string, Product> productsByNameAndProducer =
        new MultiDictionary<string, Product>(true);
    private readonly OrderedMultiDictionary<decimal, Product> productsByPrice =
        new OrderedMultiDictionary<decimal, Product>(true);
    private readonly MultiDictionary<string, Product> productsByProducer =
        new MultiDictionary<string, Product>(true);

    public void AddProduct(string name, string price, string producer)
    {
        var product = new Product()
        {
            Name = name,
            Price = decimal.Parse(price),
            Producer = producer
        };

        this.productsByName.Add(name, product);
        string nameProducer = CombineKeys(name, producer);
        this.productsByNameAndProducer.Add(nameProducer, product);
        this.productsByPrice.Add(product.Price, product);
        this.productsByProducer.Add(producer, product);
    }

    private string CombineKeys(string name, string producer)
    {
        string key = name + ";" + producer;
        return key;
    }

    public IEnumerable<Product> FindProductsByName(string name)
    {
        var products = this.productsByName[name];
        var sortedProducts = new List<Product>(products);
        sortedProducts.Sort();

        return sortedProducts;
    }

    public IEnumerable<Product> FindProductByProducer(string producer)
    {
        var products = this.productsByProducer[producer];
        var sortedProducts = new List<Product>(products);
        sortedProducts.Sort();

        return sortedProducts;
    }

    public IEnumerable<Product> FindProductsByPriceRange(decimal startPrice, decimal endPrice)
    {
        var products = this.productsByPrice.Range(startPrice, true, endPrice, true).Values;
        var sortedProducts = new List<Product>(products);
        sortedProducts.Sort();

        return sortedProducts;
    }

    public int DeleteProductsByNameAndProducer(string name, string producer)
    {
        string nameProducer = this.CombineKeys(name, producer);
        var productsToRemove = this.productsByNameAndProducer[nameProducer];
        int countRemoved = productsToRemove.Count;

        foreach (var product in productsToRemove)
        {
            this.productsByName.Remove(product.Name, product);
            this.productsByProducer.Remove(product.Producer, product);
            this.productsByPrice.Remove(product.Price, product);
        }

        this.productsByNameAndProducer.Remove(nameProducer);

        return countRemoved;
    }

    public int DeleteProductsByProducer(string producer)
    {
        var productsToRemove = this.productsByProducer[producer];
        int countRemoved = productsToRemove.Count;

        foreach (var product in productsToRemove)
        {
            this.productsByName.Remove(product.Name, product);
            string nameProducer = this.CombineKeys(product.Name, producer);
            this.productsByNameAndProducer.Remove(nameProducer, product);
            this.productsByPrice.Remove(product.Price, product);
        }

        this.productsByProducer.Remove(producer);

        return countRemoved;
    }
}

public class ShoppingCenterSlow : IShoppingCenter
{
    private readonly List<Product> products = new List<Product>();

    public void AddProduct(string name, string price, string producer)
    {
        var product = new Product()
        {
            Name = name,
            Price = Decimal.Parse(price),
            Producer = producer
        };

        this.products.Add(product);
    }

    public IEnumerable<Product> FindProductsByName(string name)
    {
        var products = this.products
            .Where(p => p.Name == name)
            .OrderBy(p => p);
        return products;
    }

    public IEnumerable<Product> FindProductByProducer(string producer)
    {
        var products = this.products
            .Where(p => p.Producer == producer)
            .OrderBy(p => p);
        return products;
    }

    public IEnumerable<Product> FindProductsByPriceRange(decimal startPrice, decimal endPrice)
    {
        var products = this.products
            .Where(p => p.Price >= startPrice && p.Price <= endPrice)
            .OrderBy(p => p);
        return products;
    }

    public int DeleteProductsByNameAndProducer(string name, string producer)
    {
        int countDeleted = this.products
            .RemoveAll(p => p.Name == name && p.Producer == producer);
        return countDeleted;
    }

    public int DeleteProductsByProducer(string producer)
    {
        int countDeleted = this.products
            .RemoveAll(p => p.Producer == producer);
        return countDeleted;
    }
}

public interface IShoppingCenter
{
    void AddProduct(string name, string price, string producer);
    IEnumerable<Product> FindProductsByName(string name);
    IEnumerable<Product> FindProductByProducer(string producer);
    IEnumerable<Product> FindProductsByPriceRange(decimal startPrice, decimal endPrice);
    int DeleteProductsByNameAndProducer(string name, string producer);
    int DeleteProductsByProducer(string producer);
}

public class Product : IComparable<Product>
{
    public string Name { get; set; }
    public Decimal Price { get; set; }
    public string Producer { get; set; }

    public int CompareTo(Product other)
    {
        int result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Producer.CompareTo(other.Producer);
        }

        if (result == 0)
        {
            result = this.Price.CompareTo(other.Price);
        }

        return result;
    }

    public override string ToString()
    {
        string str = "{" + 
            this.Name + ";" +
            this.Producer + ";" +
            this.Price.ToString("0.00") +
            "}";

        return str;
    }
}