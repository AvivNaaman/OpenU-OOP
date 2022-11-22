// provides us with List<T>
using System.Collections.Generic;
// that will enable LINQ for us
using System.Linq;
// Person
using ExmapleCommons;

static string CollectionToString<T>(IEnumerable<T> values)
{
    return string.Join(", ", values);
}

// Everything will work on a list as well, but let's make the point.
IQueryable<Person> peopleList = new List<Person>()
{
    new Person{FirstName = "Eli", LastName = "Dar"},
    new Person{FirstName = "Or", LastName = "Shalom"},
    new Person{FirstName = "Or", LastName = "Cohen"},
    new Person{ FirstName = "Benjamin", LastName = "Rosh"}
}.AsQueryable();



// Get all first names
var firstNames = from person in peopleList select person.FirstName;
Console.WriteLine($"First Names: {CollectionToString(firstNames)}");




// Generate full names
var fullNames = from person in peopleList select $"{person.FirstName} {person.LastName}";

Console.WriteLine($"Everyone's full names: {CollectionToString(fullNames)}");




// Get last names people having first names or last name with the letter 'o'
var lastNamesOfPeopleWithO = from person in peopleList
                             where person.FirstName.Contains('o') || person.LastName.Contains('o')
                             select person.LastName;

Console.WriteLine($"Last Names of People with o: {CollectionToString(lastNamesOfPeopleWithO)}");





// Query inside another query is also possible
var lastNamesWithS = from lastName in (
                        // select last names
                        from person in peopleList select person.LastName
                     )
                     where lastName.ToLower().Contains("s")
                     select lastName;

Console.WriteLine($"Last Names with S: {CollectionToString(lastNamesWithS)}");






var myString = "This Is My Test Example!";
// Many things are Queryable!
var lowerCaseLetters = from ch in myString
                       where Char.IsLower(ch)
                       select ch;

Console.WriteLine($"Lower case chars: {new String(lowerCaseLetters.ToArray())}");





// Let's sort some things out:
var upperCaseSorted = from ch in myString
                      where Char.IsUpper(ch)
                      orderby ch
                      select ch;
Console.WriteLine($"Sorted Lower case chars: {new String(upperCaseSorted.ToArray())}");





var sortedFirstNames = from f in firstNames
                       orderby f.ToLower()
                       select f;
Console.WriteLine($"Sorted first names {CollectionToString(sortedFirstNames)}");



// I don't want duplicates...
var singlePeopleOfFirstName = from f in peopleList
                             orderby f.FirstName
                             group f by f.FirstName into g
                             select g.Key;
Console.WriteLine($"Distinct first names: {CollectionToString(singlePeopleOfFirstName)}");

var countsOfPeopleByFirstName = from f in peopleList
                              orderby f.FirstName
                              group f by f.FirstName into g
                              select new { FirstName = g.Key, NameCount = g.Count() };
Console.WriteLine($"People's first names and counts: {CollectionToString(countsOfPeopleByFirstName)}");


IQueryable<PersonItem> peopleItemsList = new List<PersonItem> {
    new PersonItem {PersonLastName = "Shalom", Item = "MacBook Pro 15''"},
    new PersonItem {PersonLastName = "Mor", Item = "2006 Toyota Corolla"},
    new PersonItem {PersonLastName = "Cohen", Item= "RTX4090"},
    new PersonItem {PersonLastName = "Cohen", Item= "RTX A4000"}
}.AsQueryable();

// Now we want to get each person't items quickly.
var peopleItemsJoined = from person in peopleList
                  join personItem in peopleItemsList on person.LastName equals personItem.PersonLastName
                  select new { PersonInfo = person, Item = personItem.Item };

Console.WriteLine($"People and their items: {CollectionToString(peopleItemsJoined)}");

// But.. What about people with multiple items? That's not compfortable...
var peopleItemsGrouped = from personJoinedItem in peopleItemsJoined
                         group personJoinedItem.Item by personJoinedItem.PersonInfo into g
                         select new {
                             PersonInfo = g.Key,
                             AllItems = g
                         };
Console.WriteLine("People and all of their items: ");
int rowNumber = 1;
foreach (var personAndItem in peopleItemsGrouped)
{
    Console.WriteLine($"{rowNumber}) {personAndItem.PersonInfo.FirstName} {personAndItem.PersonInfo.LastName} has {CollectionToString(personAndItem.AllItems)}; ");
    rowNumber++;
}
Console.WriteLine();

Console.ReadKey();