namespace LB4;

public class Year
{
    private int _year;
    private Month _month;
    private Day _day;


    public void SetDate(int year, int month, int day)
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
                Console.WriteLine("Задана кількість днів не правильна");
        }
    }
    public void CountOfDays(Year year)
    {
        int years = _year - year._year;
        int months = _month.ReturnValue() - year._month.ReturnValue();
        int days = _day.ReturnValue() - year._day.ReturnValue();
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

        for (int i = 0; i < _month.MonthesWhith31Days.Length; i++)
        {
            if (i == _month.MonthesWhith31Days[i])
                countDaysinMonth += 31;
        }

        for (int i = 0; i < _month.MonthesWhith30Days.Length; i++)
        {
            if (i == _month.MonthesWhith30Days[i])
                countDaysinMonth += 30;
        }

        Console.WriteLine(
            "Кількість днів у заданому часовому проміжку: " + (countDaysinMonth + countDaysinMonth + days));
    }

    public void ShowDayOfWeek()
    {
        int numberOfday = _day.FindDayOfWeek(_year, _month.ReturnValue());
        Console.WriteLine("Поточний день неділі: " + _day.DaysOfWeek[numberOfday]);
    }

}