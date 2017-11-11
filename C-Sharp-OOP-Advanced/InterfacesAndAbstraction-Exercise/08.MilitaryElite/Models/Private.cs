using System.Text;

public class Private : Soldier, IPrivate
{
    private double salary;

    public Private(int id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public double Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");

        return sb.ToString().Trim();
    }
}