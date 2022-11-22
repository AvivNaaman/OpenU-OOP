namespace ExtensionMethods;
using ExmapleCommons;

// must be static!
public static class PersonExtensions
{
    public static string GetFullName(this Person person)
    {
        return $"{person.FirstName}, {person.LastName}";
    }
}

class Program
{
    public static void Main(string[] args)
    {

        var p = new Person() { FirstName = "Dor", LastName = "Cohen" };

        var full_name = p.GetFullName();
        Console.WriteLine(full_name);
        Console.ReadLine()
;    }
}