using System;
class Product : IComparable<Product>
{
    public string Name { get; set; }

    public int Price { get; set; }

    public Product(string name, int price)
    {
        this.Name = name;
        this.Price = price;
    }

    public int CompareTo(Product other)
    {
        return this.Price.CompareTo(other.Price);
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() == typeof(Product))
        {
            var other = (Product)obj;
            return this.Name.Equals(other.Name);
        }

        throw new ArgumentException("Invalid object type: " + obj.GetType());
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode();
    }

    public override string ToString()
    {
        return this.Name + " -> " + this.Price + " lv";
    }
}
