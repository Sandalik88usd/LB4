using System.Text;
using System.Text.Json;

namespace LB4_2;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        List<Ship> shipsInPort = new List<Ship>()
        {
            new Ship("Admiral NAhimov", "Passenger", 1500,4142, 1925, 2.4),
            new Ship("Carpathia", "Passenger", 1720,2790, 1903, 4.5),
            new Ship("Express", "Passenger", 	900,5902, 1998, 3.9),
            new Ship("Julia", "Passenger", 2048,8921, 1981, 6),
            new Ship("Star", "Passenger", 1900,1981, 2007, 3.1),
            new Ship("Panamax", "Container", 30, 13000,1914 ,8.2),
            new Ship("Mærsk Mc-Kinney Møller", "Container", 35, 18270,2010, 9.1),
            new Ship("MSC Gülsün", "Container", 38, 23756,2019 ,8.9),
            new Ship("CSCL Globe", "Container", 41, 19100,2014 ,9.3),
        };
        
        Port port = new Port(shipsInPort);
        //Port carrier1 = new Carrier("Jon", shipsInPort);
        //Port carrier2 = new Carrier("Ben", shipsInCarrier);
        Console.ReadKey();
    }
}
class JsonFiles
{
    public async void SavePolynomialInFile(string name, List<Polynomial> polynomial)
    {
        using (FileStream file = new FileStream(name, FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync(file, polynomial);

            Console.WriteLine("Data has been saved to file\n");
        }
    }

    public List<Polynomial> ReadPolynomialsFromFile(string name, List<Polynomial> polynomials)
    {
        if (File.Exists(@"C:\Users\sanda\RiderProjects\Lab3\Lab3\LB4\LB4_2\bin\Debug\net6.0\" + name))
        {
            using (StreamReader reader = File.OpenText(name))
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return polynomials = JsonSerializer.Deserialize<List<Polynomial>>(reader.ReadToEnd(), options);
            }
        }
        else
        {
            Console.WriteLine("Такого файла не існує!");
            return polynomials = null;
        }
    }
}