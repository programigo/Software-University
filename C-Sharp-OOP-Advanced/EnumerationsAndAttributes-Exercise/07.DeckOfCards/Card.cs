using System;

public class Card : IComparable<Card>
{
    private int cardPower;
    private string rank;
    private string suit;

    public Card(string rank, string suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    public int GetCardPower()
    {
        Ranks cardRank = (Ranks) Enum.Parse(typeof(Ranks), this.rank);
        Suits cardSuit = (Suits) Enum.Parse(typeof(Suits), this.suit);

        this.cardPower = (int)cardRank + (int)cardSuit;

        return this.cardPower;
    }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var rankComparison = string.Compare(this.rank, other.rank, StringComparison.Ordinal);
        if (rankComparison != 0) return rankComparison;
        return string.Compare(this.suit, other.suit, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"Card name: {this.rank} of {this.suit}; Card power: {this.GetCardPower()}";
    }
}
