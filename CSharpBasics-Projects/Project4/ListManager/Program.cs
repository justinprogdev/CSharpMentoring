using System;
using System.Collections.Generic;

// Project 4: Simple Shopping List Manager (Starter Template)
// ---------------------------------------------------------
// What you'll practice:
// - Creating and modifying a List<string>
// - Using loops to build a menu-driven console app
// - Validating user input
// - Using methods to keep code organized
//
// How to use this template:
// 1) Search for TODO tags and complete the code.
// 2) Build & run. Try adding/removing items and viewing your list.
// 3) (Stretch) Implement extra commands listed at the bottom.

class Program
{
    static void Main()
    {
        List<string> items = new List<string>();
        bool keepRunning = true;

        while (keepRunning)
        {
            ShowMenu();
            int choice = ReadMenuChoice();
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    AddItem(items);
                    break;
                case 2:
                    RemoveItem(items);
                    break;
                case 3:
                    ViewList(items);
                    break;
                case 4:
                    keepRunning = false;
                    Console.WriteLine("Goodbye! 👋");
                    break;
                default:
                    // This should not occur because ReadMenuChoice validates input
                    Console.WriteLine("Unknown option. Please try again.");
                    break;
            }

            if (keepRunning)
            {
                Console.WriteLine();
                Console.Write("Press Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("--- Shopping List Manager ---");
        Console.WriteLine("1. Add Item");
        Console.WriteLine("2. Remove Item");
        Console.WriteLine("3. View List");
        Console.WriteLine("4. Exit");
        Console.Write("Choose an option (1-4): ");
    }

    static int ReadMenuChoice()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
            {
                return choice;
            }
            Console.Write("Invalid choice. Please enter a number 1-4: ");
        }
    }

    static void AddItem(List<string> items)
    {
        Console.Write("Enter the item to add: ");
        string item = ReadNonEmptyLine();

        // Optional: prevent adding duplicates (case-insensitive)
        bool exists = items.Exists(x => x.Equals(item, StringComparison.OrdinalIgnoreCase));
        if (exists)
        {
            Console.WriteLine($"'{item}' is already on your list.");
            return;
        }

        items.Add(item);
        Console.WriteLine($"'{item}' added to your list!");
    }

    static void RemoveItem(List<string> items)
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Your list is empty. Nothing to remove.");
            return;
        }

        ViewList(items);
        Console.Write("Enter the number of the item to remove: ");

        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int index))
            {
                // Convert 1-based display to 0-based index
                index -= 1;
                if (index >= 0 && index < items.Count)
                {
                    string removed = items[index];
                    items.RemoveAt(index);
                    Console.WriteLine($"Removed '{removed}'.");
                    return;
                }
            }
            Console.Write("Invalid number. Please enter a valid item number: ");
        }
    }

    static void ViewList(List<string> items)
    {
        Console.WriteLine("Your Shopping List:");
        if (items.Count == 0)
        {
            Console.WriteLine("(empty)");
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }
    }

    static string ReadNonEmptyLine()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            Console.Write("Please enter a non-empty value: ");
        }
    }
}

/*
STRETCH GOALS (optional):
-------------------------
1) Save/Load: Allow saving the list to a file (e.g., items.txt) and loading on start.
2) Edit: Add an option to edit/rename an item by its number.
3) Sort: Add an option to sort the list alphabetically.
4) Search/Filter: Show only items containing a keyword.
5) Prevent Accidental Exit: Ask for confirmation before exiting.
6) Categories: Use List<(string item, string category)> or a class to group items.
7) Clear All: Add a command to clear the list after a confirmation.
*/
