// Written By Kapil
// Feb 16 2025

using System;

namespace HomeWork3
{
    // Define Arrowhead and Fletching enums 
    public enum Arrowhead { Steel, Wood, Obsidian }
    public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }

    // Hunting the Manticore Game
    public static class ManticoreGame
    {
        private static int manticoreDistance;
        private static int cityHealth = 15;
        private static int manticoreHealth = 10;
        private static int round = 1;

        public static void Play()
        {
            Console.WriteLine("Player 1, how far away from the city do you want to station the Manticore? (0-100)");
            manticoreDistance = GetValidDistance();
            Console.Clear();

            while (cityHealth > 0 && manticoreHealth > 0)
            {
                Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
                int damage = CalculateDamage(round);
                Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");

                Console.Write("Enter desired cannon range: ");
                int cannonRange = int.Parse(Console.ReadLine());

                if (cannonRange == manticoreDistance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("That round was a DIRECT HIT!");
                    Console.ResetColor();
                    manticoreHealth -= damage;
                }
                else if (cannonRange < manticoreDistance)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round FELL SHORT of the target.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That round OVERSHOT the target.");
                    Console.ResetColor();
                }

                if (manticoreHealth > 0)
                {
                    cityHealth--;
                }

                round++;
            }

            if (manticoreHealth <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The city of Consolas has been annihilated. The Manticore reigns supreme.");
                Console.ResetColor();
            }
        }

        private static int GetValidDistance()
        {
            int distance;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out distance) && distance >= 0 && distance <= 100)
                {
                    return distance;
                }
                Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
            }
        }

        private static int CalculateDamage(int round)
        {
            if (round % 3 == 0 && round % 5 == 0)
            {
                return 10;
            }
            else if (round % 3 == 0 || round % 5 == 0)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }
    }

    // Simula's Test (Chest State Management)
    public static class ChestManager
    {
        private enum ChestState { Open, Closed, Locked }

        private static ChestState chest = ChestState.Locked;

        public static void ManageChest()
        {
            while (true)
            {
                Console.Write($"The chest is {chest.ToString().ToLower()}. What do you want to do? ");
                string command = Console.ReadLine().ToLower();

                switch (chest)
                {
                    case ChestState.Locked:
                        if (command == "unlock")
                        {
                            chest = ChestState.Closed;
                        }
                        break;
                    case ChestState.Closed:
                        if (command == "open")
                        {
                            chest = ChestState.Open;
                        }
                        else if (command == "lock")
                        {
                            chest = ChestState.Locked;
                        }
                        break;
                    case ChestState.Open:
                        if (command == "close")
                        {
                            chest = ChestState.Closed;
                        }
                        break;
                }
            }
        }
    }

    // Simula's Soup (Food Enumeration and Tuple)
    public static class SoupMaker
    {
        private enum FoodType { Soup, Stew, Gumbo }
        private enum MainIngredient { Mushrooms, Chicken, Carrots, Potatoes }
        private enum Seasoning { Spicy, Salty, Sweet }

        public static void MakeSoup()
        {
            Console.WriteLine("Choose a type (Soup, Stew, Gumbo):");
            FoodType type = (FoodType)Enum.Parse(typeof(FoodType), Console.ReadLine(), true);

            Console.WriteLine("Choose a main ingredient (Mushrooms, Chicken, Carrots, Potatoes):");
            MainIngredient ingredient = (MainIngredient)Enum.Parse(typeof(MainIngredient), Console.ReadLine(), true);

            Console.WriteLine("Choose a seasoning (Spicy, Salty, Sweet):");
            Seasoning seasoning = (Seasoning)Enum.Parse(typeof(Seasoning), Console.ReadLine(), true);

            Console.WriteLine($"{seasoning} {ingredient} {type}");
        }
    }

    // Vin's Trouble (Private Fields with Getter Methods)
    public class ArrowVinsTrouble
    {
        private Arrowhead head;
        private Fletching feather;
        private int length;

        public ArrowVinsTrouble(Arrowhead aHead, Fletching aFeather, int aLength)
        {
            this.head = aHead;
            this.feather = aFeather;
            this.length = aLength;
        }

        public Arrowhead GetHead() => head;
        public Fletching GetFeather() => feather;
        public int GetLength() => length;

        public float GetCost()
        {
            float cost = 0;

            switch (head)
            {
                case Arrowhead.Steel: cost += 10; break;
                case Arrowhead.Wood: cost += 3; break;
                case Arrowhead.Obsidian: cost += 5; break;
            }

            switch (feather)
            {
                case Fletching.Plastic: cost += 10; break;
                case Fletching.TurkeyFeathers: cost += 5; break;
                case Fletching.GooseFeathers: cost += 3; break;
            }

            cost += length * 0.05f;

            return cost;
        }
    }

    // The Properties of Arrows (Using Properties)
    public class ArrowProperties
    {
        private Arrowhead head;
        private Fletching feather;
        private int length;

        public Arrowhead Head
        {
            get { return this.head; }
            private set { this.head = value; }
        }

        public Fletching Feather
        {
            get { return this.feather; }
            private set { this.feather = value; }
        }

        public int Length
        {
            get { return this.length; }
            private set
            {
                if (value >= 60 && value <= 100)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length must be between 60 and 100 cm.");
                }
            }
        }

        public ArrowProperties(Arrowhead aHead, Fletching aFeather, int aLength)
        {
            this.Head = aHead;
            this.Feather = aFeather;
            this.Length = aLength;
        }

        public float GetCost()
        {
            float cost = 0;

            switch (Head)
            {
                case Arrowhead.Steel: cost += 10; break;
                case Arrowhead.Wood: cost += 3; break;
                case Arrowhead.Obsidian: cost += 5; break;
            }

            switch (Feather)
            {
                case Fletching.Plastic: cost += 10; break;
                case Fletching.TurkeyFeathers: cost += 5; break;
                case Fletching.GooseFeathers: cost += 3; break;
            }

            cost += Length * 0.05f;

            return cost;
        }
    }

    // Arrow Maker Class
    public static class ArrowMaker
    {
        public static void MakeArrow()
        {
            Console.WriteLine("Choose a version of the Arrow class to test:");
            Console.WriteLine("1. Vin's Trouble (Private Fields with Getter Methods)");
            Console.WriteLine("2. The Properties of Arrows (Using Properties)");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine("Choose an arrowhead (Steel, Wood, Obsidian):");
                Arrowhead aHead = (Arrowhead)Enum.Parse(typeof(Arrowhead), Console.ReadLine(), true);

                Console.WriteLine("Choose fletching (Plastic, TurkeyFeathers, GooseFeathers):");
                Fletching aFeather = (Fletching)Enum.Parse(typeof(Fletching), Console.ReadLine(), true);

                Console.WriteLine("Enter the length of the arrow (60-100 cm):");
                int aLength = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    ArrowVinsTrouble arrow = new ArrowVinsTrouble(aHead, aFeather, aLength);
                    Console.WriteLine($"Arrowhead: {arrow.GetHead()}");
                    Console.WriteLine($"Fletching: {arrow.GetFeather()}");
                    Console.WriteLine($"Length: {arrow.GetLength()} cm");
                    Console.WriteLine($"Arrow Cost: {arrow.GetCost()} gold");
                }
                else if (choice == 2)
                {
                    ArrowProperties arrow = new ArrowProperties(aHead, aFeather, aLength);
                    Console.WriteLine($"Arrowhead: {arrow.Head}");
                    Console.WriteLine($"Fletching: {arrow.Feather}");
                    Console.WriteLine($"Length: {arrow.Length} cm");
                    Console.WriteLine($"Arrow Cost: {arrow.GetCost()} gold");
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
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
}