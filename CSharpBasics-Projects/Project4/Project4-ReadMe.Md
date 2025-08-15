# Project 4 – Shopping List Manager (Step‑by‑Step Guide)

**Goal:** Build a menu‑driven console app that manages a shopping list using `List<string>`.
**What you’ll practice:** lists, loops, input, validation, and method extraction.  
**New devs will be challenged:** Try to complete this without gpt, ping me with any feedback <a href='https://github.com/justinprogdev/CSharpMentoring/discussions/1'>in the discussion</a>

## 0) Setup

1. In Visual Studio: **File → New → Project → Console App** (.NET).
2. Name it `ListManager`.
3. Open `Program.cs`.

> ✅ **Checkpoint:** You can `Console.WriteLine("Hello");` and run it.

---

## 1) Create the list and main loop

We need a list to hold items and a loop to keep showing the menu until the user exits.

**Inside `Main()`**:

```csharp
// Create the list that will hold shopping items
List<string> items = new List<string>();

bool keepRunning = true;
while (keepRunning)
{
    // 1) Show the menu
    // 2) Read the user's choice
    // 3) Run the selected action
    // 4) Repeat until exit
}
```

> ✅ **Checkpoint:** No errors yet. Nothing happens because there’s no menu logic… that’s next.

---

## 2) Print the menu

Make a method to display options. Put this **inside your `Program` class**, but **outside** `Main()`:

```csharp
static void ShowMenu()
{
    Console.WriteLine("--- Shopping List Manager ---");
    Console.WriteLine("1. Add Item");
    Console.WriteLine("2. Remove Item");
    Console.WriteLine("3. View List");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option (1-4): ");
}
```

Call it from inside the loop:

```csharp
ShowMenu();
```

---

## 3) Read and validate the menu choice

Users can type anything. We’ll keep asking until they type a number 1–4.

```csharp
static int ReadMenuChoice()
{
    while (true)
    {
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 4)
            return choice;

        Console.Write("Invalid choice. Please enter a number 1-4: ");
    }
}
```

Use it after `ShowMenu();`:

```csharp
int choice = ReadMenuChoice();
Console.WriteLine(); // spacing
```

---

## 4) Route the choice with a `switch`

This connects each option to a method we’ll write next.

```csharp
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
}
```

(Optional polish after each action, except Exit):

```csharp
if (keepRunning)
{
    Console.WriteLine();
    Console.Write("Press Enter to continue...");
    Console.ReadLine();
    Console.Clear();
}
```

---

## 5) Read a non‑empty line (helper)

We’ll reuse this any time we need text input.

```csharp
static string ReadNonEmptyLine()
{
    while (true)
    {
        string? input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            return input.Trim();

        Console.Write("Please enter a non-empty value: ");
    }
}
```

---

## 6) Implement **Add Item**

Steps:

1. Ask for an item name.
2. Reject empty input (use `ReadNonEmptyLine()`).
3. (Optional) Prevent duplicates (case‑insensitive).
4. Add to list.

```csharp
static void AddItem(List<string> items)
{
    Console.Write("Enter the item to add: ");
    string item = ReadNonEmptyLine();

    // Optional duplicate check
    bool exists = items.Exists(x => x.Equals(item, StringComparison.OrdinalIgnoreCase));
    if (exists)
    {
        Console.WriteLine($"'{item}' is already on your list.");
        return;
    }

    items.Add(item);
    Console.WriteLine($"'{item}' added to your list!");
}
```

> ✅ **Test now:** Choose option 1 a few times and then option 3 (once you implement View) to see items.

---

## 7) Implement **View List**

Show `(empty)` when there are no items; otherwise show numbered rows.

```csharp
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
```

> ✅ **Test now:** Add 2–3 items, then view the list.

---

## 8) Implement **Remove Item**

Steps:

1. If list is empty, tell the user and return.
2. Show the list with numbers.
3. Ask for the number to remove.
4. Validate the input; convert to **0‑based** index; remove.

```csharp
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
            index -= 1; // convert 1-based to 0-based
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
```

> ✅ **Test now:** Add `Milk`, `Eggs`, `Bread`. Remove `2`. Confirm list.

---

## 9) Final polish (optional but nice)

* After each action, pause and clear the screen (you already added this).
* Add a friendly goodbye message on exit.

---

## Stretch Goals (with hints)

> Try these after your core app works. Each hint shows the *main* idea, not a full solution.

### A) Save/Load to a file

* **Save:** `File.WriteAllLines("items.txt", items);`
* **Load at start:**

  ```csharp
  if (File.Exists("items.txt"))
      items = File.ReadAllLines("items.txt").ToList();
  ```
* Add a new menu option for Save (and maybe Auto‑Save on every change).

### B) Edit/Rename an item

* Show list → ask for number → ask for new name → replace value: `items[index] = newName;`

### C) Sort the list

* `items.Sort(StringComparer.OrdinalIgnoreCase);`
* Consider showing “(sorted)” after sorting.

### D) Search/Filter by keyword

* Ask for a keyword → show matching items:

  ```csharp
  var matches = items
      .Select((text, i) => new { text, i })
      .Where(x => x.text.Contains(keyword, StringComparison.OrdinalIgnoreCase));
  ```
* Print the `i + 1` and `text` for matches.

### E) Confirm before exiting

* When user chooses 4: ask “Are you sure? (y/n)” and only exit on `y`.

### F) Categories (intro to simple types)

* Create a small type:

  ```csharp
  class Item { public string Name { get; set; } = ""; public string Category { get; set; } = "General"; }
  ```
* Change your list to `List<Item>` and update add/view/remove accordingly.

---

## Troubleshooting

* **Program “freezes”:** It’s likely waiting on `Console.ReadLine()`. Check where you paused.
* **Index out of range when removing:** Make sure you converted from 1‑based to 0‑based and checked bounds.
* **Nothing prints after running:** Did you call your methods from `Main()`? Is your loop executing?
* **Weird blank items:** Use `ReadNonEmptyLine()` instead of `Console.ReadLine()` directly.

---

## Completion Checklist

* [ ] I can add items (and empty entries are rejected).
* [ ] I can view a numbered list or see `(empty)`.
* [ ] I can remove by number safely.
* [ ] The app keeps running until I choose Exit.
* [ ] (Optional) I added at least one Stretch Goal.

---

## Suggested Exercises (for practice)

1. **Prevent duplicates** (case‑insensitive).
2. **Clear All** with a confirmation prompt.
3. **Auto‑save** after every add/remove, and auto‑load on start.

---

If you get stuck on any step, copy just **that step’s** snippet into your code and compare. You shouldn’t need the full solution to make progress—each step is small and testable. You can also veiw an example in the ListManager/Program.cs


