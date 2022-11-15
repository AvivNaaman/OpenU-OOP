using System;
using System.Reflection;
using System.Collections.Generic;
using System.Configuration;

public class ReflectionExample
{
    public static void Main(string[] args)
    {
        var reflectionDllPath = ConfigurationManager.AppSettings["ReflectionDllPath"];
        var dll = Assembly.LoadFrom(reflectionDllPath);

        List<ICar> cars = new List<ICar>();

        foreach (Type t in dll.GetExportedTypes())
        {
            // t is an ICar
            if (typeof(ICar).IsAssignableFrom(t))
                cars.Add((ICar)Activator.CreateInstance(t, new object[] { 110, 5000, 10000 }));
        }

        foreach (ICar car in cars)
        {
            car.Drive(100);
            car.Park();
            car.Refuel();
        }

        Console.ReadLine();
    }
}



public interface ICar
{
    void Drive(long distanceMeters);
    void Park();
    void Refuel();
}