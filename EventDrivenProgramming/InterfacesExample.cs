using System;
namespace EventDrivenProgramming;

/// <summary>
/// This interface describes a custom event handler.
/// </summary>
public interface IMyEventHandler
{
    /// <summary>
    /// This method is called when My Event is triggered.
    /// </summary>
    void OnMyEvent(string callerName, string payload);
}


public class InterfaceEventHandlerExample : IMyEventHandler
{
    public string LogPrefix { get; set; } = "InterfaceHandler";

    public void OnMyEvent(string callerName, string payload)
    {
        Console.WriteLine($"{LogPrefix}: Event called from {callerName}, Payload is {payload}.");
    }
}


public class InterfaceEventCreator
{
    public IMyEventHandler handler { get; set; }

    public void run()
    {
        for (int i = 10; i > 0; i--)
        {
            // sleep 1/2 second
            Thread.Sleep(500);
            // handle the event
            handler.OnMyEvent("TimeInterfaceExmaple", i.ToString());
        }
    }
}