namespace LB4;

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