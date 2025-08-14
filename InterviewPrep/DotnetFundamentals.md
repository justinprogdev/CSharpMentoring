# 1. C# & .NET Core Concepts

## **Value Types vs Reference Types — Interview Summary**

**Value types**

  - Store data directly where declared (often on the stack).
  - Examples: `int`, `double`, `bool`, `DateTime`, `struct`.
  - Copied when assigned — changes to one copy don’t affect the other.

**Reference types**

  - Store a reference on the stack pointing to data on the heap.
  - Examples: `string`, `object`, `class`, `array`.
  - Assigned by reference — multiple variables can point to the same object in memory.  
  - **Key difference** → **Copy semantics vs reference semantics**, not strictly stack vs heap.
  - Stack/heap explanation is a common mental model, but the CLR may optimize storage.

**Common OOP Questions**

1. Explain encapsulation, inheritance, polymorphism, abstraction — and give a small real-world analogy for each.
   
2. Interfaces vs abstract classes - When to use one vs the other, and the impact on flexibility and testability.
   
3. Structs vs classes - Differences in behavior, performance, and use cases.
   
5. var vs explicit types - Pros, cons, concerns?
   
6. Boxing and unboxing - What it is, when it happens, and performance implications.

# 2. Application Design & Architecture

- ASP.NET Core Request Pipeline
  How middleware works, and the lifecycle of a request.

- Dependency Injection
  Why DI is used, and what benefits it gives in maintainability and testing.

- MVC vs Minimal APIs
  Strengths, trade-offs, and typical use cases.

- REST API Design 
  HTTP verbs, status codes, and why consistency matters.

- Common Design Patterns in .NET
  Repository, Singleton, Factory — when each makes sense.

# 3. Data & Persistence

- Entity Framework Core basics
  How EF Core maps objects to database tables.

- Eager vs Lazy Loading
  How they differ, and when to use one over the other.

- IEnumerable vs IQueryable
  Execution differences, and why it matters for performance.

# 4. Asynchronous Programming

- async / await
  What problem it solves and how it works conceptually.

- Tasks vs Threads
  Differences in purpose and overhead.

- I/O-bound vs CPU-bound operations
  Which async applies to, and why.

# 5. Error Handling & Reliability

- Exception handling flow
  How try/catch/finally works and when to create custom exceptions.

- Logging strategies
  Importance of logging levels and structured logging.

# 6. Performance & Memory

- Garbage Collection in .NET
  What it does, when it runs, and common misconceptions.

- IDisposable & using
  Why deterministic disposal matters.

- Caching
  Types of caching and when to use them.

# 7. Testing & Quality

- Unit Testing Philosophy
  Why we test, what to test vs not test.

- Mocking in Tests
  What mocking solves, and when it’s overkill.

- Testable Architecture
  How DI and clean separation of concerns help testing.

# 8. Behavioral & Experience-Based

- Refactoring Experience
  Be ready to describe a time you improved legacy code.

- System Design Trade-offs
  How you balance scalability, readability, and maintainability.

- Team Collaboration
  How you’ve explained technical concepts to non-technical stakeholders.