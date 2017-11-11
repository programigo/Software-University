﻿public class Person
{
    public string name;
    public int age;

    public Person()
    {
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.name} {this.age}";
    }
}