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
        int result = this.GetCardPower().CompareTo(other.GetCardPower());

        return result;
    }

    public override string ToString()
    {
        return $"Card name: {this.rank} of {this.suit}; Card power: {this.GetCardPower()}";
    }  
}
