namespace _06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                string[] employeeInfo = Console.ReadLine()
                    .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                Employee employee = new Employee(employeeInfo[0], double.Parse(employeeInfo[1]), employeeInfo[2], employeeInfo[3]);

                if (employeeInfo.Length > 4)
                {
                    if (int.TryParse(employeeInfo[4], out int age))
                    {
                        employee.Age = age;
                    }
                    else
                    {
                        employee.Email = employeeInfo[4];
                    }
                }
                if (employeeInfo.Length > 5)
                {
                    employee.Age = int.Parse(employeeInfo[5]);
                }

                employees.Add(employee);
            }

            var depart = employees
                 .GroupBy(em => em.Department)
                 .Select(gr => new
                 {
                     Name = gr.Key,
                     AverageSalary = gr.Average(em => em.Salary),
                     Employees = gr
                 })
                 .OrderByDescending(gr => gr.AverageSalary)
                 .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {depart.Name}");

            foreach (var employee in depart.Employees.OrderByDescending(em => em.Salary))
            {
                Console.WriteLine(employee.PrintEmployeeInfo());
            }
        }
    }
}