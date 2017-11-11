using System;

public class Card : IComparable<Card>
{
    private int cardPower;
    private Ranks rank;
    private Suits suit;

    public Card(string rank, string suit)
    {
        this.rank = (Ranks)Enum.Parse(typeof(Ranks), rank);
        this.suit = (Suits)Enum.Parse(typeof(Suits), suit);
    }

    public int GetCardPower()
    {
        this.cardPower = (int)this.rank + (int)this.suit;

        return this.cardPower;
    }

    public int CompareTo(Card other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var cardPowerComparison = this.cardPower.CompareTo(other.cardPower);
        if (cardPowerComparison != 0) return cardPowerComparison;
        var rankComparison = this.rank.CompareTo(other.rank);
        if (rankComparison != 0) return rankComparison;
        return this.suit.CompareTo(other.suit);
    }

    public override string ToString()
    {
        return $"{this.rank} of {this.suit}";
    }

    public override bool Equals(object obj)
    {
        Card card = obj as Card;

        return this.GetCardPower().Equals(card.GetCardPower());
    }
}
