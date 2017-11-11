using System.Text;

public class Cat : Animal
{
    public Cat(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "MiauMiau";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Cat").Append($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine()
            .Append(this.ProduceSound());

        return sb.ToString();
    }
}