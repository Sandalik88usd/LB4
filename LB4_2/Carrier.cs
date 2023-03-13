namespace LB4_2;

public class Carrier : Port
{
    public string Name { get; }
    public Carrier(string name, List<Ship> ships) : base(ships)
    {
        Name = name;
    }
}