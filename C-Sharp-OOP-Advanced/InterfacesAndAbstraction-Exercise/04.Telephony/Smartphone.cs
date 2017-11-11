using System;

public class Smartphone : IBrowsable
{
    public Smartphone()
    {
    }

    public string Call(string number)
    {
        foreach (var element in number)
        {
            if (!Char.IsDigit(element))
            {
                throw new ArgumentException("Invalid number!");
            }
        }
        return $"Calling... {number}";
    }

    public string Browse(string url)
    {
        foreach (var element in url)
        {
            if (Char.IsDigit(element))
            {
                throw new ArgumentException("Invalid URL!");
            }
        }
        return $"Browsing: {url}!";
    }
}