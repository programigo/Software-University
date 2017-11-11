using System.Text;

public class Frog : Animal
{
    public Frog(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Frogggg";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Frog").Append($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine()
            .Append(this.ProduceSound());

        return sb.ToString();
    }
}