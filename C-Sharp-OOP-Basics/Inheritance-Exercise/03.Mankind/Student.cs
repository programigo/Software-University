using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.FacultyNumber = facultyNumber;
    }

    public override string FirstName
    {
        get
        {
            return base.FirstName;
        }

        set
        {
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            base.FirstName = value;
        }
    }

    public override string LastName
    {
        get
        {
            return base.LastName;
        }

        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            base.LastName = value;
        }
    }

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (IsNumberInvalid(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    private static bool IsNumberInvalid(string value)
    {
        bool isNumberInvalid = false;

        string numberPattern = @"^([0-9a-zA-Z]{5,10})$";

        var regex = new Regex(numberPattern);

        var match = regex.Match(value);

        if (match.Success)
            return isNumberInvalid;

        return !isNumberInvalid;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("First Name: ").AppendLine(this.FirstName)
            .Append("Last Name: ").AppendLine(this.LastName)
            .Append("Faculty number: ").AppendLine(this.FacultyNumber);

        return sb.ToString();
    }
}