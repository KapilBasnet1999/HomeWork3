// Written By Kapil
// Feb 16 2025

using System;
using System.Threading;
using HomeWork3;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Choose a program to run:");
        Console.WriteLine("1. Hunting the Manticore");
        Console.WriteLine("2. Simula's Test (Chest State Management)");
        Console.WriteLine("3. Simula's Soup");
        Console.WriteLine("4. Vin Fletcher's Arrows");
        Console.WriteLine("5. Vin's Trouble (Private Fields with Getter Methods)");
        Console.WriteLine("6. The Properties of Arrows (Using Properties)");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                ManticoreGame.Play();
                break;
            case 2:
                ChestManager.ManageChest();
                break;
            case 3:
                SoupMaker.MakeSoup();
                break;
            case 4:
                ArrowMaker.MakeArrow();
                break;
            case 5:
                TestVinsTrouble();
                break;
            case 6:
                TestPropertiesOfArrows();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void TestVinsTrouble()
    {
        Console.WriteLine("Testing Vin's Trouble (Private Fields with Getter Methods)...");

        try
        {
            Console.WriteLine("Choose an arrowhead (Steel, Wood, Obsidian):");
            Arrowhead aHead = (Arrowhead)Enum.Parse(typeof(Arrowhead), Console.ReadLine(), true);

            Console.WriteLine("Choose fletching (Plastic, TurkeyFeathers, GooseFeathers):");
            Fletching aFeather = (Fletching)Enum.Parse(typeof(Fletching), Console.ReadLine(), true);

            Console.WriteLine("Enter the length of the arrow (60-100 cm):");
            int aLength = int.Parse(Console.ReadLine());

            ArrowVinsTrouble arrow = new ArrowVinsTrouble(aHead, aFeather, aLength);
            Console.WriteLine($"Arrowhead: {arrow.GetHead()}");
            Console.WriteLine($"Fletching: {arrow.GetFeather()}");
            Console.WriteLine($"Length: {arrow.GetLength()} cm");
            Console.WriteLine($"Arrow Cost: {arrow.GetCost()} gold");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    static void TestPropertiesOfArrows()
    {
        Console.WriteLine("Testing The Properties of Arrows (Using Properties)...");

        try
        {
            Console.WriteLine("Choose an arrowhead (Steel, Wood, Obsidian):");
            Arrowhead aHead = (Arrowhead)Enum.Parse(typeof(Arrowhead), Console.ReadLine(), true);

            Console.WriteLine("Choose fletching (Plastic, TurkeyFeathers, GooseFeathers):");
            Fletching aFeather = (Fletching)Enum.Parse(typeof(Fletching), Console.ReadLine(), true);

            Console.WriteLine("Enter the length of the arrow (60-100 cm):");
            int aLength = int.Parse(Console.ReadLine());

            ArrowProperties arrow = new ArrowProperties(aHead, aFeather, aLength);
            Console.WriteLine($"Arrowhead: {arrow.Head}");
            Console.WriteLine($"Fletching: {arrow.Feather}");
            Console.WriteLine($"Length: {arrow.Length} cm");
            Console.WriteLine($"Arrow Cost: {arrow.GetCost()} gold");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}