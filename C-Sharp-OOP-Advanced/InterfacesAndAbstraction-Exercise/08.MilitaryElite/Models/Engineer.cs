using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer

{
    private IList<IRepair> repairs;

    public Engineer(int id, string firstName, string lastName, double salary, string corps, IList<IRepair> repairs) : base(id, firstName, lastName, corps)
    {
        this.Repairs = repairs;
        this.Salary = salary;
    }

    public double Salary { get; private set; }

    public IList<IRepair> Repairs { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
        sb.AppendLine($"Corps: {this.Corps}");

        sb.AppendLine("Repairs:");

        foreach (var repair in this.Repairs)
        {
            sb.AppendLine(repair.ToString());
        }

        return sb.ToString().Trim();
    }
}