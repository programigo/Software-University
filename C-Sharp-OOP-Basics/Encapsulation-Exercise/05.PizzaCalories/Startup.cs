namespace _05.PizzaCalories
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            try
            {
                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] elements = input.Split(' ');
                    string kind = elements[0];

                    if (kind.ToLower() == "pizza")
                    {
                        string pizzaName = elements[1];
                        int numberOfToppings = int.Parse(elements[2]);

                        Pizza pizza = new Pizza(pizzaName, numberOfToppings);

                        string[] doughInfo = Console.ReadLine().Split(' ');

                        Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
                        pizza.Dough = dough;

                        for (int i = 0; i < numberOfToppings; i++)
                        {
                            string[] toppingInfo = Console.ReadLine().Split(' ');

                            Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));

                            pizza.AddTopping(topping);
                        }

                        Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
                    }
                    else if (kind.ToLower() == "dough")
                    {
                        string flourType = elements[1];
                        string bakingTechnique = elements[2];
                        double weight = double.Parse(elements[3]);

                        Dough dough = new Dough(flourType, bakingTechnique, weight);

                        Console.WriteLine($"{dough.GetCalories():f2}");
                    }
                    else if (kind.ToLower() == "topping")
                    {
                        string type = elements[1];
                        double weight = double.Parse(elements[2]);

                        Topping topping = new Topping(type, weight);

                        Console.WriteLine($"{topping.GetCalories():f2}");
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}