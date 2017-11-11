using System;

public class Startup
{
    public static void Main()
    {
        BankAccount acc = new BankAccount
        {
            ID = 1,
            Balance = 15
        };

        Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
    }
}