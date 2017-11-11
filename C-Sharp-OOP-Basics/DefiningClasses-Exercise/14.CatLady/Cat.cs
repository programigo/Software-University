public abstract class Cat
{
    private string name;

    protected Cat(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return this.name; }
    }
}
