// See https://aka.ms/new-console-template for more 

using System.Reflection;
using Calculator;
using System.Text.RegularExpressions;

bool isRunning = true;

Console.WriteLine("WELOME TO MY C# CONSOLE CALCULATOR");
Console.WriteLine("----------------------------------");

while (isRunning)
{
    string? input1 = "";
    string? input2 = "";
    double result = 0;

    Console.WriteLine("Type 1st number:");
    input1 = Console.ReadLine();

    double cleanNum1 = 0;
    while(!double.TryParse(input1, out cleanNum1))
    {
        Console.WriteLine("Enter only numeric value: ");
        input1 = Console.ReadLine();
    }
    Console.WriteLine("Type 2nd number:");
    input2 = Console.ReadLine();

    double cleanNum2 = 0;
    while (!double.TryParse(input2, out cleanNum2))
    {
        Console.WriteLine("Enter only numeric value: ");
        input2 = Console.ReadLine();
    }
    Console.WriteLine("Choose an operator from the following list:");
    Console.WriteLine("\ta - Add");
    Console.WriteLine("\ts - Subtract");
    Console.WriteLine("\tm - Multiply");
    Console.WriteLine("\td - Divide");
    Console.Write("Your option? ");

    string? option = Console.ReadLine();
    if(option == null || !Regex.IsMatch(option, "[a|s|m|d]"))
    {
        Console.WriteLine("Unrecognized input");
    }
    else
    {
        try
        {
            result = Calculators.DoOperation(cleanNum1, cleanNum2, option);
            if (double.IsNaN(result))
            {
                Console.WriteLine("This operation will result in a mathematical error.\n");
            }
            else Console.WriteLine("Your result : {0:0.##}\n", result);
        }
        catch (Exception e) 
        {
            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
        }
    }
    Console.WriteLine("------------------------\n");

    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
    if(Console.ReadLine() == "n") isRunning = false;

    Console.WriteLine("\n"); 
} return;