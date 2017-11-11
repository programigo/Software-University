using System;

[AttributeUsage(AttributeTargets.Enum, AllowMultiple = true)]
public class TypeAttribute : Attribute
{
    public TypeAttribute(string type, string category, string descriptnion)
    {
        this.Type = type;
        this.Category = category;
        this.Descriptnion = descriptnion;
    }

    public string Type { get; set; }

    public string Category { get; set; }

    public string Descriptnion { get; set; }

    public override string ToString()
    {
        return $"Type = {this.Type}, Description = {this.Descriptnion}";
    }
}
