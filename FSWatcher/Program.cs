using System.IO;

void fileWritten(object sender, FileSystemEventArgs eventArgs)
{
    Console.WriteLine("Source File Changed!! " + eventArgs.FullPath);
}

using FileSystemWatcher projectWatcher = new(@"/Users/avivnaaman/Projects/oop/FSWatcher");

projectWatcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

projectWatcher.Changed += fileWritten;
projectWatcher.Filter = "*.cs";
projectWatcher.IncludeSubdirectories = true;

Console.WriteLine("Press enter to exit.");
Console.ReadLine();
