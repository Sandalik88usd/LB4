using System.ComponentModel.Design;
using System.Threading.Channels;

namespace LB4;

class Program
{
    static void Main(string[] args)
    {
        Day days = new Day(12);
        Console.WriteLine(days.FindDayOfWeek(2022, 5));
        Console.WriteLine(days.GetDayOfWeek(2022, 5));
        Console.ReadKey();
    }
}

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

public class Month
{
    private int _month { get; }
    public readonly int[] MonthesWhith31Days = new[] { 1, 3, 5, 7, 8, 10, 12 };
    public readonly int[] MonthesWhith30Days = new[] { 4, 6, 9, 11 };

    public Month(int month)
    {
        if (month < 1 || month > 12)
            Console.WriteLine("Місяців повинно бути більше 0 або менше 13.");
        else
            _month = month;
    }

    public int ReturnValue()
    {
        return _month;
    }
}

public class Year
{
    private int _year;
    private Month _month;
    private Day _day;

    public Year(int year, int month, int day)
    {
        if (year < 1)
        {
            Console.WriteLine("Кількість років повинна бути більше 0.");
        }
        else
        {
            _year = year;
            _month = new Month(month);
            for (int i = 0; i < _month.MonthesWhith31Days.Length; i++)
            {
                if (month == _month.MonthesWhith31Days[i] && day == 31)
                    _day = new Day(day);
                break;
            }

            for (int i = 0; i < _month.MonthesWhith30Days.Length; i++)
            {
                if (month == _month.MonthesWhith30Days[i] && day == 30)
                    _day = new Day(day);
                break;
            }

            if (day == 29 && year % 4 == 0 || year % 100 == 0 && year % 400 == 0)
                _day = new Day(day);
            else if (day == 28)
                _day = new Day(day);
            else
                Console.WriteLine("Задана кількість днів неправильна");
        }
    }

    public Year(int year, Month month, Day day)
    {
        if (year < 1)
        {
            Console.WriteLine("Кількість років повинна бути більше 0.");
        }
        else
        {
            _year = year;
            _month = new Month(month.ReturnValue());
            _day = new Day(day.ReturnValue());
        }
    }

    public
}