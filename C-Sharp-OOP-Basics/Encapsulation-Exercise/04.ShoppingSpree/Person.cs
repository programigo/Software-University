using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public string Name
    {
        get { return this.name; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get { return this.money; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> Products
    {
        get { return this.products.AsReadOnly(); }
    }

    public void BuyProduct(Product product)
    {
        if (this.Money < product.Cost)
        {
            throw new ArgumentException($"{this.Name} can't afford {product.Name}");
        }

        this.products.Add(product);
        this.Money -= product.Cost;
    }
}