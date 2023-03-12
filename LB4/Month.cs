namespace LB4;

public class Month
{
    private readonly int _month;
    public static readonly int[] MonthesWhith31Days = new[] { 1, 3, 5, 7, 8, 10, 12 };
    public static readonly int[] MonthesWhith30Days = new[] { 4, 6, 9, 11 };

    public Month(int month)
    {
        _month = month;
    }

    public void CountOfMonths(Year firstYear, Year secondYear)
    {
        int years = firstYear.ReturnValue("year") - secondYear.ReturnValue("year");
        int months = firstYear.ReturnValue("month") - secondYear.ReturnValue("month");
        int days = firstYear.ReturnValue("day") - secondYear.ReturnValue("day");
        int countMonthsinYear = 0;
        int countMonthsByDays = 0;
        for (int i = 0; i < years; i++)
        {
            if (i % 4 == 0 || i % 100 == 0 && i % 400 == 0)
            {
                countMonthsinYear += 1;
                if (months >= 2 && days == 29)
                    countMonthsByDays += 1;
            }
            else
            {
                countMonthsinYear += 1;
                if (months >= 2 && days == 28)
                    countMonthsByDays += 1;
            }
        }

        for (int i = 0; i < MonthesWhith31Days.Length; i++)
        {
            if (i == MonthesWhith31Days[i] && days == 31)
                countMonthsByDays += 1;
        }

        for (int i = 0; i < MonthesWhith30Days.Length; i++)
        {
            if (i == MonthesWhith30Days[i] && days == 30)
                countMonthsByDays += 1;
        }

        Console.WriteLine(
            "Кількість місяців у заданому часовому проміжку: " + (countMonthsinYear + countMonthsByDays + months));
    }
    public int ReturnValue()
    {
        return _month;
    }
}