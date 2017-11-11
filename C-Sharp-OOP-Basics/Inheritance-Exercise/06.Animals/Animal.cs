using System;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public virtual string Gender
    {
        get { return this.gender; }
        set
        {
            if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.gender = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()) || value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            this.name = value;
        }
    }

    public virtual string ProduceSound()
    {
        return "Not implemented!";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Animal").Append($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine()
            .Append(this.ProduceSound());

        return sb.ToString();
    }
}