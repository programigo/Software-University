public class Company
{
    private string name;
    private string department;
    private double salary;

    public Company(string name, string department, double salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public string Name { get { return this.name; } }
    public string Department { get { return this.department; } }
    public double Salary { get { return this.salary; } }
}
