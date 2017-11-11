using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private IList<IMission> missions;

    public Commando(int id, string firstName, string lastName, double salary, string corps, IList<IMission> missions) : base(id, firstName, lastName, corps)
    {
        this.Missions = missions;
        this.Salary = salary;
    }

    public double Salary { get; set; }

    public IList<IMission> Missions { get; private set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
        sb.AppendLine($"Corps: {this.Corps}");

        sb.AppendLine("Missions:");

        foreach (var mission in this.Missions)
        {
            sb.AppendLine(mission.ToString());
        }

        return sb.ToString().Trim();
    }
}