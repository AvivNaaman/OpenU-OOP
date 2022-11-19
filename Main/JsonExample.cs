using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

[Serializable]
class Tutorial
{
    [JsonPropertyName("TutorialID")]
    public int ID { get; set; }
    [JsonPropertyName("TutorialName")]
    public String Name { get; set; }

    static void Main(string[] args)
    {
        BinaryExample();
        JsonExample();
    }


    static void BinaryExample()
    {
        Tutorial obj = new Tutorial();
        obj.ID = 1;
        obj.Name = ".Net";

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(@"ExampleNew.txt", FileMode.Create, FileAccess.Write);

        formatter.Serialize(stream, obj);
        stream.Close();

        Console.ReadKey();

        stream = new FileStream(@"ExampleNew.txt", FileMode.Open, FileAccess.Read);
        Tutorial objnew = (Tutorial)formatter.Deserialize(stream);

        Console.WriteLine(objnew.ID);
        Console.WriteLine(objnew.Name);

        Console.ReadKey();
    }

    static void JsonExample()
    {
        Tutorial obj = new Tutorial();
        obj.ID = 1;
        obj.Name = ".Net";

        string jsonFormat = JsonSerializer.Serialize(obj);
        Console.WriteLine(jsonFormat);


        Console.ReadLine();

        Tutorial obj2 = JsonSerializer.Deserialize<Tutorial>(jsonFormat);
        Console.WriteLine(obj2.ID);
        Console.WriteLine(obj2.Name);

        Console.ReadLine();
    }
}