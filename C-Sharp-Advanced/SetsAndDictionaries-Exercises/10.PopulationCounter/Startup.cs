namespace _10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> countries = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                string[] elements = input.Split('|');
                string city = elements[0];
                string country = elements[1];
                long population = long.Parse(elements[2]);

                if (!countries.ContainsKey(country))
                {
                    countries.Add(country, new Dictionary<string, long>());
                }

                countries[country].Add(city, population);

                input = Console.ReadLine();
            }

            var countriesAndCities = countries.OrderByDescending(pop => pop.Value.Values.Sum());

            foreach (var countryAndCity in countriesAndCities)
            {
                Console.WriteLine($"{countryAndCity.Key} (total population: {countryAndCity.Value.Values.Sum()})");

                var cities = countryAndCity.Value.OrderByDescending(population => population.Value);

                foreach (var city in cities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}