using ObservableCollections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

public class ObservableExamle
{
    public static void Main(string[] args)
    {
        var list = new ObservableCollection<int>();
        list.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                        Console.WriteLine(item);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine(e.OldItems[0] + " => " + e.NewItems[0]);
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Console.WriteLine("Cleared List");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Removed at: " + e.OldStartingIndex + " value: " + e.OldItems[0]);
                    break;
                case NotifyCollectionChangedAction.Move:
                    Console.WriteLine("Moved: " + e.OldStartingIndex + " to: " + e.NewStartingIndex);
                    break;
                default:
                    break;

            };
        };

        list.Add(66);       // Add
        list.Add(4444);
        list.Add(55);
        list.Add(77);
        list[0] = 55;       // Replace
        list.RemoveAt(0);   // Remove
        list.Move(0, 2);    // Move
        list.Clear();       // Reset

        Console.ReadLine();
    }
}

