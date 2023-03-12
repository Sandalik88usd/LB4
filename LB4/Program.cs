﻿using System.ComponentModel.Design;
using System.Diagnostics;
using System.Threading.Channels;

namespace LB4;

class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
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

    public void ShowDayOfWeek()
    {
        int numberOfday = _day.FindDayOfWeek(_year, _month.ReturnValue());
        Console.WriteLine("Поточний день неділі: " + _day.DaysOfWeek[numberOfday]);
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

    public void CountOfMonths(Year year)
    {
        int years = _year - year._year;
        int months = _month.ReturnValue() - year._month.ReturnValue();
        int days = _day.ReturnValue() - year._day.ReturnValue();
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

        for (int i = 0; i < _month.MonthesWhith31Days.Length; i++)
        {
            if (i == _month.MonthesWhith31Days[i] && days == 31)
                countMonthsByDays += 1;
        }

        for (int i = 0; i < _month.MonthesWhith30Days.Length; i++)
        {
            if (i == _month.MonthesWhith30Days[i] && days == 30)
                countMonthsByDays += 1;
        }

        Console.WriteLine(
            "Кількість місяців у заданому часовому проміжку: " + (countMonthsinYear + countMonthsByDays + months));
    }
}