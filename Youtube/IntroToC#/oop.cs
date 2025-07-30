using System;
using System.Collections.Generic;



partial class Program
{
    static void Main()
    {
        var p1 = new Person("Adamzek", "Hensem", new DateOnly(2004, 7, 6));
        var p2 = new Person("Adamzek", "Hensem", new DateOnly(2004, 7, 6));
        List<Person> people = [p1, p2];
        Console.WriteLine(people.Count());
        p1.Pets.Add(new Dog("Fred"));
        p1.Pets.Add(new Dog("Barney"));
        p1.Pets.Add(new Dog("Bryce"));

        foreach (var p in people)
        {
            Console.WriteLine($"{p}");

            foreach (var pet in p.Pets)
            {
                Console.WriteLine($"    {pet}");
            }
        }
    }
}

public class Person(string firstName, string lastName, DateOnly birthday)
{
    public string First { get; } = firstName;
    public string Last { get; } = lastName;
    public DateOnly Birthday { get; } = birthday;

    public List<Pet> Pets { get; } = new();

    public override string ToString()
    {
        return $"{firstName} {lastName}";
    }
}


public abstract class Pet(string firstName)
{
    public string First { get; } = firstName;
    public abstract string MakeNoise();

    public override string ToString()
    {
        return $"{First} and I am a {GetType().Name} and I {MakeNoise()}";
    }
    
}
public class Cat(string firstName) : Pet(firstName)
{
    public override string MakeNoise() => "meow";
}

public class Dog(string firstName) : Pet(firstName)
{
    public override string MakeNoise() { return "bark"; }
}