public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, double price)
        : base(author, title, price)
    {
    }

    public override double Price
    {
        get
        {
            return base.Price * 1.3;
        }
    }
}