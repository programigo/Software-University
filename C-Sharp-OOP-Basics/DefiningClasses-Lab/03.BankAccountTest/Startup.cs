using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();

        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        while (input != "End")
        {
            var cmdArgs = input.Split();
            var cmdType = cmdArgs[0];

            switch (cmdType)
            {
                case "Create":
                    Create(cmdArgs, accounts);
                    break;

                case "Deposit":
                    Deposit(cmdArgs, accounts);
                    break;

                case "Withdraw":
                    Withdraw(cmdArgs, accounts);
                    break;

                case "Print":
                    Print(cmdArgs, accounts);
                    break;
            }

            input = Console.ReadLine();
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (accounts.ContainsKey(id))
        {
            var bankAccount = accounts.First(accId => accId.Key == id);

            Console.WriteLine($"Account ID{bankAccount.Key}, balance {bankAccount.Value.Balance:f2}");
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);

        if (accounts.ContainsKey(id))
        {
            var bankAccount = accounts.First(accId => accId.Key == id);

            if (bankAccount.Value.Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                bankAccount.Value.Balance -= amount;
            }

            //
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);

        if (accounts.ContainsKey(id))
        {
            var bankAccount = accounts.First(accId => accId.Key == id);
            bankAccount.Value.Balance += amount;

            //Console.WriteLine($"Account ID{bankAccount.Key}, balance {bankAccount.Value.Balance}");
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.ID = id;
            accounts.Add(id, acc);
        }
    }
}