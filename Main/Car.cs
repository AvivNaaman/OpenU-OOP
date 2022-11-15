using System;
using System.Threading;

public class Car : ICar
{
    private double speedMPS;
    private int parkTimeMS; // 10s
    int refualTimeMs;// 5s

    public Car(long speedKMPH = 110, int parkTimeMS = 5000, int refualTimeMs = 10000)
    {
        this.parkTimeMS = parkTimeMS;
        this.refualTimeMs = refualTimeMs;
        this.speedMPS = speedKMPH * 1000 / 60.0 / 60.0;
    }

    public void Drive(long distanceMeter)
    {
        Console.WriteLine("Started Driving");
        Thread.Sleep((int)(1000 * distanceMeter / speedMPS));
        Console.WriteLine("Car Drove: " + distanceMeter + " Meters");
    }

    public void Park()
    {
        Console.WriteLine("Started Parking");
        Thread.Sleep(parkTimeMS);
        Console.WriteLine("Car Parked");
    }

    public void Refuel()
    {
        Console.WriteLine("Started Refueling");
        Thread.Sleep(refualTimeMs);
        Console.WriteLine("Car Refueled");
    }
}