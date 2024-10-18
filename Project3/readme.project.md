# You're making PROGRESS!
## Nice - Let's get to work  

To do our next exercise, I have to show you lists in C#, they're kind of like ArrayLists in Java, or Lists for that matter 😁 (I don't remember java well)

### Lists
1. #### Instantiating a new List looks like this:  
    This creates an empty list of strings called fruits  
    ```List<string> fruits = new List<string>();```

2. #### Adding items to a list 
    ```
    fruits.Add("Apple");
    fruits.Add("Banana");
    fruits.Add("Cherry");
    ```
    The Add method is used to add elements to the list.

3. #### Accessing an Element from the List:  
    Use the index (starting from 0) to access items.  

    ```
    string firstFruit = fruits[0]; // Accessing the first element ("Apple")
    Console.WriteLine(firstFruit); // Outputs to screen/console: Apple
    ```
4. #### Fruit Loops (Get it?) We use a FOR loop with indexer  
    ```
    for (int i = 0; i < fruits.Count; i++)
    {
        Console.WriteLine(fruits[i]);
    }
    ```
5. #### Now a foreach loop
    ```
    foreach (string fruit in fruits)
    {
        Console.WriteLine(fruit);
    }
    ```

# The full example program
## Create a new Console Application in Visual Studio and try this
```
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Step 1: Instantiate the list
        List<string> fruits = new List<string>();

        // Step 2: Add items to the list
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Cherry");

        // Step 3: Access an element
        Console.WriteLine("First fruit: " + fruits[0]);

        // Step 4: Loop using for loop
        Console.WriteLine("Using for loop:");
        for (int i = 0; i < fruits.Count; i++)
        {
            Console.WriteLine(fruits[i]);
        }

        // Step 5: Loop using foreach loop
        Console.WriteLine("Using foreach loop:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }
    }
}
```

## Now show me what you can do and try your own!