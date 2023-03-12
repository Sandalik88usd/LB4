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
            for (int i = 0; i < Month.MonthesWhith31Days.Length; i++)
            {
                if (month == Month.MonthesWhith31Days[i] && day == 31)
                    _day = new Day(day);
                break;
            }

            for (int i = 0; i < Month.MonthesWhith30Days.Length; i++)
            {
                if (month == Month.MonthesWhith30Days[i] && day == 30)
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

    public void ShowDayOfWeek()
    {
        _day.FindDayOfWeek(_year, _month.ReturnValue());
    }

    public void CountOfDays(Year firstYear, Year secondYear)
    {
        _day.CountOfDays(firstYear, secondYear);
    }

    public void CountOfMonths(Year firstYear, Year secondYear)
    {
        _month.CountOfMonths(firstYear,secondYear);
    }

    public int ReturnValue(string varible)
    {
        if (varible == "year")
        {
            return _year;
        }
        else if (varible == "month")
        {
            return _month.ReturnValue();
        }
        else if (varible == "day")
        {
            return _day.ReturnValue();
        }
        else
        {
            return 0;
        }
    }
}