public abstract class Soldier : ISoldier
{
    private int id;
    private string firstName;
    private string lastName;

    protected Soldier(int id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
}