using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeeklyEntry(string weekday, string notes)
    {
        this.Weekday = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.Notes = notes;
    }

    public WeekDay Weekday { get; set; }

    public string Notes { get; private set; }

   

    public override string ToString()
    {
        return $"{this.Weekday} - {this.Notes}";
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var weekDayComparison = this.Weekday.CompareTo(other.Weekday);

        if (weekDayComparison != 0)
        {
            return weekDayComparison;
        }

        return string.Compare(this.Notes, other.Notes, StringComparison.Ordinal);
    }
}