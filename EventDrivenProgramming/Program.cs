namespace EventDrivenProgramming;
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");


        // Interface Example:
        InterfaceExample("Inteface");

        // Delegate Example:
        DelegateExample("Delegate");

        Console.ReadKey();
    }


    public static void InterfaceExample(string logPrefix)
    {
        InterfaceEventCreator iec = new();
        iec.handler = new InterfaceEventHandlerExample { LogPrefix = logPrefix };
        iec.run();
    }


    public static void DelegateExample(string logPrefix)
    {
        DelegateEventCreator dec = new();
        dec.OnMyEvent += (caller, payload) => Console.WriteLine($"{logPrefix}: {payload} from {caller}");
        dec.run();
    }
}

