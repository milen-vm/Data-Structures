using System;

class Person : IComparable<Person>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override string ToString()
    {
        return this.FirstName + " " + this.LastName;
    }

    public int CompareTo(Person other)
    {
        if (this.LastName == other.LastName)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }

        return this.LastName.CompareTo(other.LastName);
    }
}
