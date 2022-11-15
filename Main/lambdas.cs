using System.Collections.Generic;
using System.Linq;
using System;

public class LambdaExample
{
    public static void Maina(string[] args)
    {
        Example1();
        Console.WriteLine();
        Console.ReadLine();
        Example2();
        Console.WriteLine();
        Console.ReadLine();
        Console.WriteLine(First(new List<int> { 4, 5, 6, 13, 13, 15, 16, 20 }, x => ((x + 6) / 3 % 7 == 0)));
        Console.ReadLine();
    }


    public static void Example1()
    {
        List<int> listOfNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        List<int> evenNumbers = listOfNumbers.FindAll(x => x % 2 == 0);
        evenNumbers.ForEach(x => Console.Write(x + " "));
    }

    public static void Example2()
    {
        int first = 1, second = 2;
        var numberRange = Enumerable.Range(1, 100);
        var evenNumbers = numberRange.Where(x =>
        {
            if (x == first)
            {
                int temp = second;
                second += first;
                first = temp;
                return true;
            }
            return false;
        });

        evenNumbers.ToList().ForEach(x => Console.Write(x + " "));
    }

    public static int? First(List<int> data, Func<int, bool> FilterFunc)
    {
        foreach (int d in data)
        {
            if (FilterFunc(d))
                return d;

        }

        return null;
    }
}
