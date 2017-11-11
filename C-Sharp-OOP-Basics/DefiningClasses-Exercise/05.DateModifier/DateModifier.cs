using System;

public class DateModifier
{
    // public string year;
    // public string month;
    // public string day;
    //
    // public DateModifier(string year, string month, string day)
    // {
    //     this.year = year;
    //     this.month = month;
    //     this.day = day;
    // }

    public int CalculateDifference(string firstDate, string secondDate)
    {
        DateTime firstAsDate = Convert.ToDateTime(firstDate);
        DateTime secondAsDate = Convert.ToDateTime(secondDate);

        int difference = (int)Math.Abs((firstAsDate - secondAsDate).TotalDays);

        return difference;
    }
}