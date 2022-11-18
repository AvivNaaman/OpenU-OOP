namespace EventDrivenProgramming;
class Program
{
    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");


        // Interface Example:
        //InterfaceEventHandlerExample handlerInstance = new("handlerInstance");
        //TimeInterfaceExample(handlerInstance);

        DelegateExample();

        Console.ReadKey();
    }

    public static void TimeInterfaceExample(IMyEventHandler timeHandler)
    {
        for (int i = 50; i > 0; i--)
        {
            // sleep 1/2 second
            Thread.Sleep(500);
            // handle the event
            timeHandler.OnMyEvent("TimeInterfaceExmaple", i.ToString());
        }
    }

    public static void DelegateExample()
    {
        MyTimeEventCreator tec = new();
        //tec.OnMyEvent += Tec_OnMyEvent;
        tec.OnMyEvent += (caller, payload) => Console.WriteLine($"{payload} from {caller}");
        tec.run();
    }

    private static void Tec_OnMyEvent(string callerName, string payload)
    {
        Console.WriteLine($"{payload} from {callerName}");
    }
}

