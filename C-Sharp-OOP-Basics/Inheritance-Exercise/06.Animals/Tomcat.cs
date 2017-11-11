using System.Text;

public class Tomcat : Cat
{
    public Tomcat(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string Gender
    {
        get { return base.Gender; }
        set { base.Gender = "male"; }
    }

    public override string ProduceSound()
    {
        return "Give me one million b***h";
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Tomcat").Append($"{this.Name} {this.Age} {this.Gender}")
            .AppendLine()
            .Append(this.ProduceSound());

        return sb.ToString();
    }
}