namespace _14.CatLady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input;
            List<Cat> cats = new List<Cat>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] catInfo = input.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                string breed = catInfo[0];
                string name = catInfo[1];

                if (breed == "Siamese")
                {
                    int earSize = int.Parse(catInfo[2]);
                    Cat siameseCat = new Siamese(name, earSize);

                    cats.Add(siameseCat);
                }
                else if (breed == "Cymric")
                {
                    double furLength = double.Parse(catInfo[2]);

                    Cat cymricCat = new Cymric(name, furLength);

                    cats.Add(cymricCat);
                }
                else if (breed == "StreetExtraordinaire")
                {
                    int meowingDecibels = int.Parse(catInfo[2]);

                    Cat streetCat = new StreetExtraordinaire(name, meowingDecibels);

                    cats.Add(streetCat);
                }
            }

            string catName = Console.ReadLine();

            Cat cat = cats.FirstOrDefault(c => c.Name == catName);

            Console.WriteLine(cat);
        }
    }
}
