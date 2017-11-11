using System.Text;

public class Kitten : Cat
{
    public Kitten(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string Gender
    {
        get { return base.Gender; }
        set { base.Gender = "female"; }
    }

    public override string ProduceSound()
    {
        return "Miau";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Kitten").Append($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine()
            .Append(this.ProduceSound());

        return sb.ToString();
    }
}