using System;

public class Card
{
    private int cardPower;
    private string rank;
    private string suit;

    public Card(string rank, string suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    public string GetCardPower()
    {
        Ranks cardRank = (Ranks) Enum.Parse(typeof(Ranks), this.rank);
        Suits cardSuit = (Suits) Enum.Parse(typeof(Suits), this.suit);

        this.cardPower = (int)cardRank + (int)cardSuit;

        return $"Card name: {this.rank} of {this.suit}; Card power: {this.cardPower}";
    }
}
