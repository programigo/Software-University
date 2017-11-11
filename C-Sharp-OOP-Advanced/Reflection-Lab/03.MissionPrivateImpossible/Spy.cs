using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        Type type = Type.GetType(className);

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

        var hackerInstance = Activator.CreateInstance(type);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var fieldInfo in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(hackerInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type hackerType = Type.GetType(className);

        var fields = hackerType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        var publicMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        var nonPublicMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var methodInfo in nonPublicMethods.Where(m => m.Name.Contains("get")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be public!");
        }

        foreach (var methodInfo in publicMethods.Where(m => m.Name.Contains("set")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type hackerType = Type.GetType(className);

        var privateMethods = hackerType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");

        sb.AppendLine($"Base Class: {hackerType.BaseType.Name}");

        foreach (var privateMethod in privateMethods)
        {
            sb.AppendLine(privateMethod.Name);
        }

        return sb.ToString().Trim();
    }
}
