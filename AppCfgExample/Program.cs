using System.Configuration;

namespace AppCfgExmaple;

public class BehaviorSettings : ConfigurationSection
{
    [ConfigurationProperty(name: "refreshTimeout", IsRequired = false, DefaultValue = 50)]
    public int RefreshTimeout { get { return (int)this["refreshTimeout"]; } }
}


public class Program {

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        // Using appSettings
        var secretPasswordValue = ConfigurationManager.AppSettings["SecretPwd"];
        Console.WriteLine($"Secret Password is: '{secretPasswordValue}'");

        // ConnectionStrings are similar and relevant to Databases
        var connectionString = ConfigurationManager.ConnectionStrings["Main"];
        Console.WriteLine($"Connection Strings are somewhat similar: '{connectionString}'");


        var myCustomCfg = (BehaviorSettings)System.Configuration.ConfigurationManager.GetSection("Behavior");
        Console.WriteLine($"Current Refresh Timeout is: {myCustomCfg.RefreshTimeout}");
    }
}