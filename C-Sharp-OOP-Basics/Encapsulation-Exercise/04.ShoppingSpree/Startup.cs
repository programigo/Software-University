namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string[] people = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<Person> persons = new List<Person>();

            string[] allProducts = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();

            try
            {
                foreach (var pair in people)
                {
                    string[] personInfo = pair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));

                    persons.Add(person);
                }

                foreach (var pair in allProducts)
                {
                    string[] productInfo = pair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    Product product = new Product(productInfo[0], decimal.Parse(productInfo[1]));

                    products.Add(product);
                }

                string command;

                while ((command = Console.ReadLine()) != "END")
                {
                    string[] buyInfo = command.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    string personName = buyInfo[0];
                    string productName = buyInfo[1];

                    Person buyer = persons.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(pr => pr.Name == productName);

                    try
                    {
                        buyer.BuyProduct(product);
                        Console.WriteLine($"{buyer.Name} bought {product.Name}");
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                }

                foreach (var person in persons)
                {
                    if (person.Products.Count > 0)
                    {
                        var prod = person.Products;
                        Console.WriteLine($"{person.Name} - {string.Join(", ", prod.Select(n => n.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}