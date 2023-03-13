using System.Text;
namespace LB4;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        // Year firstYear = new Year();
        // firstYear.SetDate(2012, 12, 4);
        // Year secondYear = new Year();
        // secondYear.SetDate(2001, 6, 2);
        // firstYear.ShowDayOfWeek();
        // secondYear.ShowDayOfWeek();
        // firstYear.CountOfDays(firstYear, secondYear);
        // firstYear.CountOfMonths(secondYear, firstYear);
        Day day = new Day(23);
        Console.WriteLine(day.ToString());
        Console.WriteLine(day.GetHashCode());
        Console.WriteLine(day.Equals(day));
        Console.ReadKey();
    }
}