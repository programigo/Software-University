namespace _01.ClassPerson
{
    using System;
    using System.Reflection;

    public class Startup
    {
        public static void Main()
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

            //Person pesho = new Person();
            //pesho.name = "Pesho";
            //pesho.age = 20;
            //
            //Person goshoPerson = new Person("Gosho", 18);
            //
            //Person stamatPerson = new Person("Stamat", 43);
            //
            //Console.WriteLine(pesho);
            //Console.WriteLine(goshoPerson);
            //Console.WriteLine(stamatPerson);
        }
    }
}