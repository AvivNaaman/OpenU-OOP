using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Generic;
using System;

public class ObservableExamle
{
    public static void MainO(string[] args)
    {
        CollectionChangedExample();
        Console.ReadLine();
        ViewExample();
        Console.ReadLine();
    }

    public static void CollectionChangedExample()
    {
        // TODO: I think we should implement it by ourselves.
        var list = new ObservableList<int>();
        list.CollectionChanged += (in NotifyCollectionChangedEventArgs<int> e) =>
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.IsSingleItem)
                        Console.WriteLine(e.NewItem);
                    else
                    {
                        foreach (var item in e.NewItems)
                            Console.WriteLine(item);
                    }

                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine(e.OldItem + " => " + e.NewItem);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("Cleared List");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Removed at: " + e.OldStartingIndex + " value: " + e.OldItem);
                    break;
                case NotifyCollectionChangedAction.Move:
                    Console.WriteLine("Moved: " + e.OldStartingIndex + " to: " + e.NewStartingIndex);
                    break;
                default:
                    break;
            }
        };

        list.Add(66);       // Add
        list.AddRange(new List<int> { 1, 2, 3 });
        list[0] = 55;       // Replace
        list.RemoveAt(0);   // Remove
        list.Move(0, 2);    // Move
        list.Clear();       // Reset
    }

    public static void ViewExample()
    {
        var list = new ObservableList<int>();
        var view = list.CreateSortedView<int, int, long>(x => x, x => x, new Z7Comparer());

        list.Add(10);
        list.Add(20);
        list.AddRange(new[] { 30, 40, 50 });
        list[1] = 60;
        list.RemoveAt(3);

        foreach (var a in view)
        {
            Console.WriteLine(a.ToTuple().Item2);
        }
    }
}

class Z7Comparer : IComparer<int>
{
    public int Compare(int first, int second)
    {
        first = first % 7;
        second = second % 7;

        if (first > second)
            return 1;
        if (first < second)
            return -1;
        return 0;
    }
}
