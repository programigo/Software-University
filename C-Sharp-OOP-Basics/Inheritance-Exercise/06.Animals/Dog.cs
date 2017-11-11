using System.Text;

public class Dog : Animal
{
    public Dog(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "BauBau";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Dog").Append($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine()
            .Append(this.ProduceSound());

        return sb.ToString();
    }
}