using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    IList<CoffeeType> coffesSold = new List<CoffeeType>();
    private int coins;

    public IEnumerable<CoffeeType> CoffeesSold => this.coffesSold;

    public void InsertCoin(string coin)
    {
        Coin rem = (Coin) Enum.Parse(typeof(Coin), coin);
        
        this.coins += (int) rem;
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffeeType = (CoffeeType) Enum.Parse(typeof(CoffeeType), type);

        CoffeePrice coffeePrice = (CoffeePrice) Enum.Parse(typeof(CoffeePrice), size);

        if (this.coins >= (int) coffeePrice)
        {
            this.coffesSold.Add(coffeeType);

            this.coins = 0;
        }
        
    }
}
