namespace LB4;
public class Day
{
    private int _day { get; }

    public Day(int day)
    {
        if (day < 1 || day > 31)
            Console.WriteLine("Днів повинно бути більше 0 або менше 32.");
        else
            _day = day;
    }

    public int FindDayOfWeek(int year, int month)
    {
        DateTime date = new DateTime(year, month, _day);
        if (date.DayOfWeek == 0)
            return 7;
        else
            return (int)date.DayOfWeek;
    }

    public int GetDayOfWeek(int year, int month)
    {
        if (month < 3)
        {
            year--;
            month += 12;
        }

        int century = year / 100;
        int yearInCentury = year % 100;

        int dayOfWeek =
            (_day + 13 * (month + 1) / 5 + yearInCentury + yearInCentury / 4 + century / 4 - 2 * century) % 7 - 1;

        if (dayOfWeek <= 0)
        {
            dayOfWeek += 7;
        }

        return dayOfWeek;
    }

    public int ReturnValue()
    {
        return _day;
    }
}
