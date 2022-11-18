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
    /// <param name="callerName">The name of my event caller.</param>
    /// <param name="payload">The payload of the event.</param>
    void OnMyEvent(string callerName, string payload);
}

public class InterfaceEventHandlerExample : IMyEventHandler
{
    public string LogPrefix { get; set; } = "InterfaceHandler";

    public InterfaceEventHandlerExample(string? logPrefix)
    {
        if (logPrefix is not null)
        {
            LogPrefix = logPrefix;
        }
    }

    public void OnMyEvent(string callerName, string payload)
    {
        Console.WriteLine($"{LogPrefix}: Event called from {callerName}, Payload is {payload}.");
    }
}