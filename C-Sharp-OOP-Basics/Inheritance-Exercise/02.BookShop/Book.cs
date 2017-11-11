using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private double price;

    public Book(string author, string title, double price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public virtual double Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public virtual string Author
    {
        get { return this.author; }
        set
        {
            string[] nameSeparated = value.Split();
            if (nameSeparated.Length > 1)
            {
                string secondName = nameSeparated[1];
                char firstChar = secondName[0];
                string firstCharAsString = secondName.Substring(0, 1);
                if (!String.IsNullOrWhiteSpace(firstCharAsString) && Char.IsDigit(firstChar))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }

    public virtual string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < 3 || String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Type: ").AppendLine(this.GetType().Name)
            .Append("Title: ").AppendLine(this.Title)
            .Append("Author: ").AppendLine(this.Author)
            .Append("Price: ").Append($"{this.Price:f1}")
            .AppendLine();

        return sb.ToString();
    }
}