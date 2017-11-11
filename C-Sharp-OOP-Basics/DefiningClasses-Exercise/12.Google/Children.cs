public class Children
{
    private string name;
    private string birthday;

    public Children(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public string Name { get { return this.name; } }
    public string Birthday { get { return this.birthday; } }
}
