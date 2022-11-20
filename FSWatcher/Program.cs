using System;
using System.IO;

using FileSystemWatcher projectWatcher = new(@"/Users/avivnaaman/Projects/oop/FSWatcher");

projectWatcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

projectWatcher.Changed += ProjectWatcher_Changed;

void ProjectWatcher_Changed(object sender, FileSystemEventArgs e)
{
    Console.WriteLine("Text File Changed!! " + e.FullPath);
}

projectWatcher.Filter = "*.txt";
projectWatcher.IncludeSubdirectories = true;
projectWatcher.EnableRaisingEvents = true;

Console.WriteLine("Press enter to exit.");
Console.ReadLine();
