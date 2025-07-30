// See https://aka.ms/new-console-template for more information


// Console.WriteLine("Hello, World!");

    // string firstFriend = "    Maria   ";
    // firstFriend = firstFriend.Trim();
    // string secondFriend = "Sage";
    // Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");  //string interpolation or concatentation

    // string friends = $"My friends are {firstFriend} and {secondFriend}";

    // Console.WriteLine(friends.Replace("Maria", "Damian"));

    // friends = friends.Replace("Maria", "Damian");
    // Console.WriteLine(friends);

    // ---

    // numebrs in C#
    // int a = 2100000000;
    // int b = 2100000000;
    // long c = (long)a + (long)b;
    // long c = checked(a + b);
    // Console.WriteLine(c);

    // ---

double a = 42.1;
float b = 38.2F;
double c = a + b;
Console.WriteLine($"the answer is {c}");
decimal d = 42.1M;
Console.Write(d);
// ---
int x = 5;
int y = 6;
int z = x + y;
if (z > 10)
{
    Console.WriteLine("The answer is greater than 10.");
}
else
{
    Console.WriteLine("The answer is less than 10.");
}

// ---

// int counter = 0;
// counter = counter + 1;
// counter++;
// Console.WriteLine(counter);
// counter++;
// Console.WriteLine(counter);
// counter++;
// Console.WriteLine(counter);
// counter++;
// Console.WriteLine(counter);

/*
while (counter < 5)
{

    Console.WriteLine(counter);
    counter++;
}*/

// do
// {
//     Console.WriteLine(counter);
//     counter++;
// }
// while (counter < 5);

// ---


for (
    int i = 0;  //initialize = start
    i < 5; //conditional = stop
    i++) //iteration = increment = update
{
    if (i == 3)
    {
        Console.WriteLine(i);
    }

}

// ---
// only use var when the type is obvious
/*
var names = new List<string> {
    "Adamzek0",
    "Ana",
    "Felipe"
};
for (int i = 0; i < names.Count; i++)
{
    Console.WriteLine($"Hello {names[i].ToUpper()}!");
}
*/

List<string> names = ["Adamzek", "Ana", "Felipe"];

names.Add("Damian");
names.Add("Abu");
names.Add("Ali");

names.Remove("Ana");

foreach (var name in names[2..4])  // Slicing the list from index 2 to index 4 (exclusive)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}

Console.WriteLine(names[0]);
Console.WriteLine(names[names.Count - 1]); // Accessing the last element using Count property
Console.WriteLine(names[^1]); // ^1 means the last element in the list

/*
var names = new string[] {
    "Adamzek",
    "Ana",
    "Felipe"
};*/
names = [.. names, "Damian", "Abu", "Ali"]; // add the new elements to the original array n append to new array

// ---part14
var newnames = new List<String> {
    "Scott",
    "Ana",
    "Felipe"
};
newnames.Sort(); // Sort the list in ascending order

foreach (var name in newnames)
{
    Console.WriteLine($"Hello {name}!");
}
newnames.IndexOf("Ana"); // Find the index of "Ana" in the list

// ---part15 n 16
List<int> numbers = [97, 98, 81, 90];

for (int i = 0; i < numbers.Count; i++)
{
    if (numbers[i] > 80)
    {
        Console.WriteLine($"The number more than 80 is {numbers[i]}");
    }
}

// declarative programming is more readable
IEnumerable<string> numberQuery =
    from number in numbers
    where number > 80
    orderby number descending
    select $"The number is {number}"; // LINQ query syntax

// executing the query
foreach (string s in numberQuery)
{
    Console.WriteLine(s);
}

// ---part17
List<string> myScores = numberQuery.ToList(); // Convert the query result to a list
foreach (var score in myScores)
{
    Console.WriteLine(score);
}

var numberQuery2 = numbers.Where(s => s > 80).
                    OrderByDescending(s => s).
                    Select(s => $"The number is {s}"); // LINQ but less readable version 

// part18

// public class Person
// {
//     public Person(string first, string last, DateOnly bd)
//     {
//         firstName = first;
//         lastName = last;
//         birthday = bd;
//     }
//     private string firstName;
//     private string lastName;
//     private DateOnly birthday;
// }

// using System;

// public class Person(string firstName, string lastName, DateOnly birthday)
// {
//     public string First { get; } = firstName;
//     public string Last { get; } = lastName;
//     public DateOnly Birthday { get; } = birthday;
// }

// // Now safe to use top-level code
// var p1 = new Person("Adamzek", "Hensem", new DateOnly(2004, 7, 6));
// var p2 = new Person("Abu", "Hensem", new DateOnly(2004, 7, 6));
// List<Person> people = [p1, p2];
// Console.WriteLine(people.Count());

// ---part19