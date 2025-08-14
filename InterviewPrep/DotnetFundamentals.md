```Disclosure: I used ChatGPT for formatting and a bunch of boilerplate. I told it exactly what to include. I prepare on this same set of topics with every .Net interview.```

# 1. **C# & .NET Core Concepts**

## Value Types vs Reference Types

### Value Types

- Store data **directly** where they are declared — typically on the **stack**.
- Examples: `int`, `double`, `bool`, `DateTime`, `struct`
- When assigned or passed to a method, a **copy** of the data is made.
- Changes to one copy do **not** affect the other.
- Useful for small, immutable data.

### Reference Types

- A **reference type variable** holds a **pointer** to the object’s actual data — usually stored on the **heap**.
- Examples: `string`, `object`, `class`, `array`, `interface`, `delegate`
- **Assignment behavior**: When you assign one reference to another, you're copying the **reference**, not the data — both now point to the same object.
- **Reference semantics**: Changes made via one variable are reflected in the other, because they're both referencing the **same object**.
- Don't overthink “stack vs heap” — it’s a helpful mental model, but in practice, the **CLR may optimize** where things are stored.
- `Gotcha`: Be ready to explain how this differs from **value types**, especially when passed into methods — reference types preserve changes made inside the method.

---

# 2. **OOP Concepts in C#**

### Encapsulation

- Hides internal state and behavior; exposes only what’s necessary.
- Achieved via access modifiers (`private`, `public`, etc.).
- **Real-world analogy**: A remote control — you press a button, but don’t need to know the circuitry inside.

### Inheritance "Is-A Relationship"

- Allows a class to inherit members from a base class.
- Promotes reuse and logical hierarchy.
- **Real-world analogy**: A `Car` class inherited by `Sedan`, `Carrera`, `Coupe`. The Coupe `IS A Car`

### Polymorphism

- Ability for different types to be treated as the same base type.
- Achieved through method overriding or interface implementation.
- **Real-world analogy**: A single “Drive” method that behaves differently for `F1 Car`, `Car`, and `Tractor`.

### Abstraction

- Hides complex implementation details and shows only essential features.

---

### Interfaces vs Abstract Classes

- **Interface**: Contract with no implementation; allows multiple inheritance.
- **Abstract class**: Base with some shared implementation; single inheritance.
- Use **interfaces** for capabilities, and **abstract classes** when sharing code.
- Interfaces make **unit testing and mocking** easier.

---

# 3. **C# Language Features & Type Behavior**

### Structs vs Classes

- **Structs** are value types, **classes** are reference types.
- Structs are better for small, immutable data.
- Classes offer more flexibility and inheritance.
- Avoid large or mutable structs — copying can hurt performance.

---

### var vs Explicit Types

- `var` enables type inference at compile-time.
- Use `var` when the type is **obvious**; use explicit types for clarity or when code readability matters.
- Avoid `var` when the type is ambiguous or impacts understanding.

---

### Boxing and Unboxing

- **Boxing**: Converting a value type to an object/reference type.
- **Unboxing**: Extracting the value type back from the object.
- Costly in terms of performance — avoid in tight loops or performance-critical paths.

---

# 4. **Application Design & Architecture**

### ASP.NET Core Request Pipeline

- Built from **middleware** components.
- Each middleware can **handle**, **modify**, or **pass on** the request.
- Request → Middleware A → B → C → Response

---

### Dependency Injection (DI)

- Injects dependencies instead of creating them manually.
- Promotes **testability**, **modularity**, and **inversion of control**.
- Use built-in DI in ASP.NET Core for services and repositories.
- ASP.NET Core defines **three main service lifetimes**:

  - **Transient**  
    - A new instance is created **every time** it’s requested.  
    - Use for **lightweight**, stateless services.
    - Example: `services.AddTransient<IMyService, MyService>()`

  - **Scoped**  
    - One instance per **HTTP request**.  
    - Shared across that request's pipeline (e.g., controllers, middleware).
    - Example: `services.AddScoped<IMyService, MyService>()`

  - **Singleton**  
    - A **single instance** is created the first time it's requested and **shared for the application's lifetime**.  
    - Be careful with **stateful** or request-specific data — not safe to use `DbContext` here.
    - Example: `services.AddSingleton<IMyService, MyService>()`

- **Gotcha**: Injecting a `Scoped` service into a `Singleton` will throw an error — or worse, behave unpredictably. Use `IServiceScopeFactory` when needed.

- **Real-world analogy**:  
  - Transient: a new disposable coffee cup  
  - Scoped: your personal cup for the day  
  - Singleton: the office coffee machine
---

### MVC vs Minimal APIs

- **MVC**: Best for full-featured apps with views and controllers.
- **Minimal APIs**: Great for lightweight APIs and microservices.
- Trade-offs in flexibility, startup time, and complexity.

---

### REST API Design

- Use standard HTTP verbs (`GET`, `POST`, `PUT`, `DELETE`).
- Return appropriate status codes (e.g., `200`, `404`, `500`).
- Keep resource URIs consistent and intuitive.

---

### Common Design Patterns in .NET

- **Repository**: Abstracts data access logic.
- **Singleton**: Ensures a class has only one instance.
- **Factory**: Creates objects without specifying exact types.

---

# 5. **Data & Persistence**

### Entity Framework Core Basics

- ORM that maps C# objects to database tables.
- Supports migrations, LINQ queries, and change tracking.

---

### Eager vs Lazy Loading

- **Eager**: Loads related data upfront with `.Include()`.
- **Lazy**: Loads related data when accessed.
- Be cautious — lazy loading can cause **N+1 query issues**.

---

### IEnumerable vs IQueryable

- `IEnumerable`: In-memory iteration; executes queries immediately.
- `IQueryable`: Composable; queries translated to SQL and executed at DB level.
- Use `IQueryable` for database queries to optimize performance.

---

# 6. **Asynchronous Programming**

### async / await

- Simplifies asynchronous code; avoids blocking threads.
- `await` unwraps the result of a `Task` without blocking.

---

### Tasks vs Threads

- `Task`: Abstraction over work that may run concurrently.
- `Thread`: Lower-level, manual control over execution.
- Prefer `Task` for most async I/O operations.

---

### I/O-bound vs CPU-bound

- **I/O-bound**: Use `async`/`await` — waiting on external resources (files, network).
- **CPU-bound**: Use `Task.Run` to offload heavy computation.

---

# 7. **Error Handling & Reliability**

### Exception Handling Flow

- Use `try/catch/finally` to manage exceptions.
- Don’t swallow exceptions — log or handle them meaningfully.
- Create **custom exceptions** for domain-specific errors.

---

### Logging Strategies

- Use structured logging (`Serilog`, `ILogger`) with levels: `Info`, `Warning`, `Error`, etc.
- Logs help trace issues and support observability in production.

---

# 8. **Performance & Memory**

### Garbage Collection in .NET

- Automatically reclaims memory from unused objects.
- Runs in **generations** (Gen 0, 1, 2) to optimize frequency.
- Avoid holding onto references longer than needed.

---

### IDisposable & using

- Use `IDisposable` for unmanaged resources (e.g., files, streams).
- `using` ensures deterministic disposal, even in exceptions.

---

### Caching

- Use memory or distributed cache (`IMemoryCache`, `IDistributedCache`) to reduce DB load.
- Cache only what's safe to reuse and update appropriately.

---

# 9. **Testing & Quality**

### Unit Testing Philosophy

- Focus on small, isolated units of logic.
- Don’t test third-party libraries or frameworks.
- Tests are documentation and safety nets.

---

### Mocking in Tests

- Replace real dependencies with fakes/mocks.
- Tools: `Moq`, `NSubstitute`, `FakeItEasy`
- Avoid over-mocking — focus on behavior over implementation.

---

### Testable Architecture

- Use DI to inject dependencies.
- Follow SOLID principles to make code modular and test-friendly.
- Separate concerns into layers (e.g., services, repositories, controllers).