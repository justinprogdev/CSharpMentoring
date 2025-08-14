# C# & .NET Core Demo Instructions

## Value Types vs Reference Types
1. Create a value type (`int`) variable, copy it to another variable, change one, and print both.
   - **Result:** Changing one value type does not affect the other.
2. Create a reference type (`class` with a property), assign one variable to another, change a property, and print both.
   - **Result:** Both variables reflect the same change because they reference the same object.

## OOP Concepts
3. Build a small class with private fields and public methods to show encapsulation.
   - **Result:** Internal fields are not accessible directly, only through public methods.
4. Create a base class and a derived class to demonstrate inheritance.
   - **Result:** Derived class inherits and can use members from the base class.
5. Implement a virtual method in the base class, override it in the derived class, and show polymorphism in action.
   - **Result:** Method behavior changes based on the actual object type, even when referenced by the base type.
6. Create an interface and a class that implements it; show how multiple classes can share the same contract.
   - **Result:** Multiple classes can be treated the same through the interface type.

## Structs vs Classes
7. Create a struct and a class with the same fields; copy each to another variable and modify them.
   - **Result:** Struct copies are independent, class copies share changes.

## var vs Explicit Types
8. Declare variables using `var` and explicit types.
   - **Result:** `var` infers types at compile-time, but explicit typing improves clarity when type is not obvious.

## Boxing and Unboxing
9. Store a value type in an `object` variable (boxing), then retrieve it (unboxing) and display it.
   - **Result:** Shows that boxing wraps a value type into an object, and unboxing extracts it.

## ASP.NET Core Request Pipeline
10. Add simple middleware in an ASP.NET Core app to log requests and responses.
    - **Result:** Middleware intercepts and logs each request and response.

## Dependency Injection
11. Register a service with Transient, Scoped, and Singleton lifetimes, then demonstrate instance reuse.
    - **Result:** Transient creates a new instance each time, Scoped reuses per request, Singleton reuses across the app.

## MVC vs Minimal APIs
12. Build a simple “Hello World” API using MVC, then using Minimal APIs.
    - **Result:** Shows difference in setup complexity and code structure.

## Entity Framework Core Basics
13. Create a model, a DbContext, and run a migration to create a table.
    - **Result:** Database table created from the model.
14. Demonstrate eager vs lazy loading by querying related data with and without `.Include()`.
    - **Result:** Eager loading fetches related data immediately; lazy loading fetches only when accessed.

## IEnumerable vs IQueryable
15. Query a database with both `IEnumerable` and `IQueryable`.
    - **Result:** `IQueryable` defers execution and queries the database; `IEnumerable` works on in-memory collections.

## Async / Await
16. Create a method that simulates I/O-bound work and use `async`/`await`.
    - **Result:** Code runs without blocking the main thread.
17. Compare CPU-bound work using `Task.Run` vs direct execution.
    - **Result:** `Task.Run` offloads CPU work to a separate thread, avoiding UI or main thread blocking.

## Exception Handling
18. Write a method with `try/catch/finally` that throws and handles an exception.
    - **Result:** Exception is caught and handled gracefully, `finally` runs regardless.
19. Create a custom exception type and use it in a method.
    - **Result:** Demonstrates meaningful, domain-specific error handling.

## Logging
20. Add `ILogger` to a service, log messages at different levels.
    - **Result:** Logs appear in the configured output with appropriate severity levels.

## IDisposable & using
21. Write a class that implements `IDisposable`, then use it in a `using` statement.
    - **Result:** Cleanup code runs automatically when the object goes out of scope.

## Caching
22. Implement in-memory caching for a method result using `IMemoryCache`.
    - **Result:** Data is retrieved from cache on subsequent calls, avoiding redundant work.

## Unit Testing
23. Write a small function and a unit test to validate it.
    - **Result:** Test passes when the function works as expected.
24. Mock a dependency using `Moq` and verify method calls.
    - **Result:** Confirms that the dependent method was called as expected.