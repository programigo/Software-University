using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Soldier, ILeutenantGeneral
{
    private IList<ISoldier> privates;

    public LeutenantGeneral(int id, string firstName, string lastName, double salary, IList<ISoldier> privates) : base(id, firstName, lastName)
    {
        this.Privates = privates;
        this.Salary = salary;
    }

    public IList<ISoldier> Privates { get; private set; }

    public double Salary { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");

        sb.AppendLine("Privates:");

        foreach (var soldier in this.Privates)
        {
            sb.AppendLine(soldier.ToString());
        }

        return sb.ToString().Trim();
    }
}