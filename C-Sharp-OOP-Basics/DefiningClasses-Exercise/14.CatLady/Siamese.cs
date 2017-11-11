public class Siamese : Cat
{
    private int earSize;

    public Siamese(string name, int earSize) : base(name)
    {
        this.earSize = earSize;
    }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.earSize}";
    }
}
