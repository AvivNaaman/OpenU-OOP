using System;
using System.Text.Json;


public class JsonExample
{
    public static void Main(string[] args)
    {
        string data = @" [ {""name"": ""John Doe"",    ""occupation"": ""gardener""}, 
                           {""name"": ""Peter Novak"", ""occupation"": ""driver""} ]";

        JsonDocument doc = JsonDocument.Parse(data);
        JsonElement root = doc.RootElement;

        Console.WriteLine(root);

        var u1 = root[0];
        var u2 = root[1];



        Console.WriteLine(u1);
        Console.WriteLine(u2);

        Console.WriteLine(u1.GetProperty("name"));
        Console.WriteLine(u1.GetProperty("occupation"));

        Console.WriteLine(u2.GetProperty("name"));
        Console.WriteLine(u2.GetProperty("occupation"));

        doc.Dispose();
    }
}
