namespace LB4_2;

public class Port
{
    public List<Ship> Ships { get; private set; }

    public Port(List<Ship> ships)
    {
        Ships = new List<Ship>();
        Ships.AddRange(ships);
    }

    public void ShowListOfShips()
    {
        foreach (var ship in Ships)
        {
            Console.WriteLine($"Назва човна {ship.Name}\nТип човна {ship.Type}\nВантажність {ship.Capacity}\n" +
                              $"Витра палива за годину {ship.FuelPerHour}\nРік випуску {ship.YearOfProduction}\n");
        }
    }

    private void ShowListOfShips(List<Ship> ships)
    {
        foreach (var ship in ships)
        {
            Console.WriteLine($"Назва човна {ship.Name}\nТип човна {ship.Type}\nВантажність {ship.Capacity}\n" +
                              $"Витра палива за годину {ship.FuelPerHour}\nРік випуску {ship.YearOfProduction}\n");
        }
    }

    public void Spaciousness()
    {
        double numberOfPassengers = 0;
        double amountOfCargo = 0;
        for (int i = 0; i < Ships.Count; i++)
        {
            if (Ships[i].Type == "Passenger")
            {
                numberOfPassengers += Ships[i].Capacity;
            }
            else
            {
                amountOfCargo += Ships[i].Capacity;
            }
        }

        Console.WriteLine("Загальна місткість пасажирів: " + numberOfPassengers);
        Console.WriteLine("Загальна вантажність: " + amountOfCargo);
    }

    public void SortByFuelCost()
    {
        var sortedShips = from ships in Ships orderby ships.FuelPerHour select ships;
        Ships = new List<Ship>();
        Ships.AddRange(sortedShips);
    }

    public void HierarchyOfShips()
    {
        var sortedShips = Ships.OrderBy(ships => ships.Capacity).ThenBy(ships => ships.FuelPerHour);
        Ships = new List<Ship>();
        Ships.AddRange(sortedShips);
    }

    public void FindByYear(int firstYear, int secondYear)
    {
        if (firstYear > secondYear || firstYear < 0 || secondYear < 0)
        {
            Console.WriteLine("Неправильний діапазон.");
        }
        else
        {
            List<Ship> shipsWithCorectYear = new List<Ship>();
            for (int i = firstYear; i < secondYear; i++)
            {
                for (int j = 0; j < Ships.Count; j++)
                {
                    if (Ships[j].YearOfProduction == i)
                    {
                        shipsWithCorectYear.Add(Ships[j]);
                    }
                }
            }

            ShowListOfShips(shipsWithCorectYear);
        }
    }
}