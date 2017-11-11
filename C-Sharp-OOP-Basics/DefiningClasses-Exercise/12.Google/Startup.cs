namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            while (input != "End")
            {
                string[] elements = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(elements[0]);

                if (!people.ContainsKey(person.Name))
                {
                    people.Add(person.Name, person);
                }

                if (elements.Length == 5)
                {

                    Company company = new Company(elements[2], elements[3], double.Parse(elements[4]));
                    people[person.Name].Company = company;

                }
                else
                {
                    if (elements[1] == "pokemon")
                    {
                        
                            Pokemon pokemon = new Pokemon(elements[2], elements[3]);
                            people[person.Name].AddPokemon(pokemon);
                        
                       
                    }
                    else if (elements[1] == "parents")
                    {
                        
                            Parent parent = new Parent(elements[2], elements[3]);
                            people[person.Name].AddParent(parent);
                        
                     
                    }
                    else if (elements[1] == "children")
                    {
                        
                            Children children = new Children(elements[2], elements[3]);                          
                            people[person.Name].AddChildren(children);
                        
                        
                    }
                    else if (elements[1] == "car")
                    {

                        Car car = new Car(elements[2], int.Parse(elements[3]));
                        people[person.Name].Car = car;

                    }
                }

                input = Console.ReadLine();
            }

            string lookingPerson = Console.ReadLine();

            var takenPerson = people.First(person => person.Key == lookingPerson);

            Console.WriteLine(takenPerson.Key);

            Console.WriteLine("Company:");
            if (takenPerson.Value.Company != null)
            {
                Console.WriteLine($"{takenPerson.Value.Company.Name} {takenPerson.Value.Company.Department} {takenPerson.Value.Company.Salary:f2}");
            }

            Console.WriteLine("Car:");
            if (takenPerson.Value.Car != null)
            {
                Console.WriteLine($"{takenPerson.Value.Car.Model} {takenPerson.Value.Car.Speed}");
            }


            Console.WriteLine("Pokemon:");
            if (takenPerson.Value.Pokemons != null)
            {
                foreach (var pokemon in takenPerson.Value.Pokemons)
                {
                    Console.WriteLine($"{pokemon.Name} {pokemon.Type}");
                }
            }

            Console.WriteLine("Parents:");
            if (takenPerson.Value.Parents != null)
            {
                foreach (var parent in takenPerson.Value.Parents)
                {
                    Console.WriteLine($"{parent.Name} {parent.Birthday}");
                }
            }

            Console.WriteLine("Children:");
            if (takenPerson.Value.Childrens != null)
            {
                foreach (var child in takenPerson.Value.Childrens)
                {
                    Console.WriteLine($"{child.Name} {child.Birthday}");
                }
            }
        }
    }
}
