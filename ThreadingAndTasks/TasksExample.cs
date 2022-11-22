using System;
using System.Threading;
using System.Threading.Tasks;

class TasksExample
{
    // This is the entry point of a C# program  
    static void Main(string[] args)
    {
        // Main execution starts here  
        Console.WriteLine("Main thread starts here.");

        // This method takes 4 seconds to finish.

        //DoSomethingElse();
        var t1 = Task.Run((Action)DoSomethingElse);

        // This method takes 2 seconds to finis.  
        DoSomething();
        t1.Wait();

        // Execution ends here  
        Console.WriteLine("Main thread ends here.");
        Console.ReadKey();
    }

    public static void DoSomethingElse()
    {
        Thread.Sleep(4000);
        Console.WriteLine("Finished DoSomethingElse");
    }
    public static void DoSomething()
    {
        Thread.Sleep(2000);
        Console.WriteLine("Finished DoSomething");
    }
}