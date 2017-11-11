using System.Collections.Generic;

public class Family
{
    public List<Person> people = new List<Person>();

    public void AddMember(Person member)
    {
        this.people.Add(member);
    }

    public Person GetOldestMember()
    {
        Person oldestPerson = new Person();
        int maxAge = int.MinValue;

        foreach (var person in people)
        {
            if (person.age > maxAge)
            {
                oldestPerson.name = person.name;
                oldestPerson.age = person.age;
                maxAge = person.age;
            }
        }

        return oldestPerson;
    }
}