namespace LB4_2;

public class Ship
{
    public string Name { get;}
    public string Type { get;}
    public double Capacity { get;}
    
    public double CargoCapacity { get; }
    public int YearOfProduction { get;}
    public double FuelPerHour { get;}

    public Ship(string name, string type, double capacity, int cargoCapacity, int yearOfProduction, double fuelPerHour)
    {
        Name = name;
        Type = type;
        Capacity = capacity;
        CargoCapacity = cargoCapacity;
        YearOfProduction = yearOfProduction;
        FuelPerHour = fuelPerHour;
    }
}