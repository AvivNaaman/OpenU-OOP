using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


public class LinqToXmlExample
{
    public static void Main(string[] args)
    {
        XDocument carsModified = XDocument.Load("CarsModified.xml");

        var colorsToRemove =
        from color in carsModified.Descendants("AvaliableColors")
        where (string)color.Element("Color") == "Red"
        select color.Element("Color");

        colorsToRemove.ToList().ForEach(element => element.Remove());
        // colorsToRemove.ToList().Remove(); //another option

        // removing Renualt

        var carToRemove =
        (from car in carsModified.Descendants("Car")
         where (string)car.Attribute("Manufacture").Value == "Renualt"
         select car).ToList();

        carToRemove.Remove();
        carsModified.Save("CarsModifiedDeleted.xml");
    }
}


