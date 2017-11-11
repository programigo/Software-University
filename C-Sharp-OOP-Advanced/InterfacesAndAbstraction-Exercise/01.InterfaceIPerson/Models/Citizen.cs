﻿public class Citizen : IPerson
{
    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; protected set; }

    public int Age { get; protected set; }
}