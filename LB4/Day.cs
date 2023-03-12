namespace LB4;
public class Day
{
    private readonly int _day;

    public Day(int day)
    {
        _day = day;
    }
    public readonly List<string> DaysOfWeek = new List<string>()
    {
        "Понеділок",
        "Вівторок",
        "Середа",
        "Четвер",
        "Пятниця",
        "Субота",
        "Неділя"
    };
    public void FindDayOfWeek(int year, int month)
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

        Console.WriteLine("Поточний день неділі: " + DaysOfWeek[dayOfWeek-1]);
        
    }
    public void CountOfDays(Year firstYear, Year secondYear)
    {
        int years = firstYear.ReturnValue("year") - secondYear.ReturnValue("year");
        int months = firstYear.ReturnValue("month") - secondYear.ReturnValue("month");
        int days = firstYear.ReturnValue("day") - secondYear.ReturnValue("day");
        int countDaysinMonth = 0;
        int countDaysinYear = 0;
        for (int i = 0; i < years; i++)
        {
            if (i % 4 == 0 || i % 100 == 0 && i % 400 == 0)
            {
                countDaysinYear += 366;
                if (months >= 2)
                    countDaysinMonth += 29;
            }
            else
            {
                countDaysinYear += 365;
                if (months >= 2)
                    countDaysinMonth += 28;
            }
        }

        for (int i = 0; i < Month.MonthesWhith31Days.Length; i++)
        {
            if (i == Month.MonthesWhith31Days[i])
                countDaysinMonth += 31;
        }

        for (int i = 0; i < Month.MonthesWhith30Days.Length; i++)
        {
            if (i == Month.MonthesWhith30Days[i])
                countDaysinMonth += 30;
        }

        Console.WriteLine(
            "Кількість днів у заданому часовому проміжку: " + (countDaysinMonth + countDaysinMonth + days));
    }

    public int ReturnValue()
    {
        return _day;
    }
}
