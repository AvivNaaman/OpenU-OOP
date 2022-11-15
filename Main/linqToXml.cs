using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;


public class LinqToXmlExample
{
    public static void Main2(string[] args)
    {
        XDocument document = XDocument.Load("CarsModified.xml");

        var colorsToRemove =
        from color in document.Descendants("AvaliableColors")
        where (string)color.Element("Color") == "Red"
        select color.Element("Color");

        colorsToRemove.ToList().ForEach(element => element.Remove());
        // colorsToRemove.ToList().Remove(); //another option

        // removing Renualt

        var carToRemove =
        (from car in document.Descendants("Car")
         where (string)car.Attribute("Manufacture").Value == "Renualt"
         select car).ToList();

        carToRemove.Remove();
        document.Save("CarsModifiedDeleted.xml");
    }

    static void Main1(string[] args)
    {
        XDocument document = XDocument.Load("Cars.xml");
        XElement elementToAdd =
        new XElement("Car", new XAttribute("Manufacture", "BMW"),
        new XElement("Model", "X"),
        new XElement("AvaliableColors",
        new XElement("Color", "White"),
        new XElement("Color", "Grey"),
        new XElement("Color", "Blue")
        )
        );

        document.Descendants("Cars").First().Add(elementToAdd);
        XElement elementToAdd2 =
        new XElement("Car", new XAttribute("Manufacture", "Renualt"),
        new XElement("Model", "Clio"),
        new XElement("AvaliableColors",
        new XElement("Color", "Red"),
        new XElement("Color", "Black"),
        new XElement("Color", "Green")
        )
        );
        //document.Descendants("Cars").First().Add(elementToAdd2);
        document.Descendants("Cars").First().AddFirst(elementToAdd2);
        document.Save("CarsModified.xml");
    }

    static void Main0(string[] args)
    {
        XElement document = new XElement("Cars",
        new XElement("Car", new XAttribute("Manufacture", "Ford"),
        new XElement("Model", "Mustang"),
        new XElement("AvaliableColors",
        new XElement("Color", "Red"),
        new XElement("Color", "Black"))));
        document.Save("Cars.xml");
    }
}


