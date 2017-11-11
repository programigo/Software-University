public interface IBuyer : IName, IAge
{
    int Food { get; }

    void BuyFood();
}
