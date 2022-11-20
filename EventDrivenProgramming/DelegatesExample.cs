using System;
namespace EventDrivenProgramming;

class DelegateEventCreator
{
    // They replace the interface.
    public delegate void MyEventHandler(string callerName, string payload);

    public event MyEventHandler OnMyEvent;

    public void run()
    {
        for (int i = 10; i > 0; i--)
        {
            // invoke callback
            OnMyEvent?.Invoke("MyTimeEventCreator", i.ToString());
            // sleep 1/2 second
            Thread.Sleep(500);
        }
    }
}

