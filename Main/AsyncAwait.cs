using System;
using System.Threading;
using System.Threading.Tasks;

public class AsyncAwaitExample
{
    // This is the entry point of a C# program  
    static void Maina(string[] args)
    {
        // Main execution starts here  
        Console.WriteLine("Main thread starts here.");

        // This method takes 4 seconds to finish.

        var t1 = SomeOtherIOThing();
        var t2 = SomeIOThing();

        t1.Wait();
        t2.Wait();


        // Execution ends here  
        Console.WriteLine("Main thread ends here.");
        Console.ReadKey();
    }

    public static async Task SomeOtherIOThing()
    {
        int calculation = await DataBaseGetData();
        await Task.Delay(1500);
        Console.WriteLine("Finished DoSomethingElse With: " + calculation);
    }
    public static async Task SomeIOThing()
    {
        await Task.Delay(2000);
        Console.WriteLine("Finished DoSomething");
    }
    public static async Task<int> DataBaseGetData()
    {
        await Task.Delay(2500);
        return 6;
    }
}


