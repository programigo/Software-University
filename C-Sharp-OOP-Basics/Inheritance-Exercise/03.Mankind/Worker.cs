using System;
using System.Text;

public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        this.LastName = lastName;
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    public double WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public override string LastName
    {
        get { return base.LastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length more than 3 symbols! Argument: lastName");
            }

            base.LastName = value;
        }
    }

    public double GetMoneyPerHour()
    {
        return (this.WeekSalary / 5) / this.WorkHoursPerDay;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("First Name: ").AppendLine(this.FirstName)
            .Append("Last Name: ").AppendLine(this.LastName)
            .Append("Week Salary: ").Append($"{this.WeekSalary:f2}")
            .AppendLine()
            .Append("Hours per day: ").Append($"{this.WorkHoursPerDay:f2}")
            .AppendLine()
            .Append("Salary per hour: ").Append($"{this.GetMoneyPerHour():f2}")
            .AppendLine();

        return sb.ToString();
    }
}