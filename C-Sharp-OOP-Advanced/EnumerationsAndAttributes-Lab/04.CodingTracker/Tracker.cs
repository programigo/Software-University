﻿using System;
using System.Linq;
using System.Reflection;
using _04.CodingTracker;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(Startup);
        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(n => n.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = methodInfo.GetCustomAttributes(false);

                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
