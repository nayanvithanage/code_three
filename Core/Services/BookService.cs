using code_three.Core.Entities;
using code_three.Core.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace code_three.Core.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        /* ### Syntax Breakdown

            - `Task<IEnumerable<Book>>`:  
            - `Task<T>` is the return type for asynchronous methods in C#.  
            - `IEnumerable<Book>` means the method will return a collection of `Book` objects.
            - `GetAllAsync()`:  
            - The method name ends with `Async`, following C# convention for async methods.
            - No parameters in this case.

            ### What It Does

            - Declares an asynchronous method in the `IBookRepository` interface.
            - When implemented, this method will fetch all books from a data source (e.g., database) without blocking the calling thread.

            ### Usage Example


            // Calling the method asynchronously
            var books = await bookRepository.GetAllAsync();
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }


            ### Why Use `Task<IEnumerable<Book>>`?

            - Allows the method to run in the background (e.g., database query).
            - The `await` keyword can be used to wait for the result without blocking the thread.
            - Improves scalability and responsiveness in web applications.

            **Summary:**  
            This line defines an async method that, when called, will return a list of books after completing its operation, typically from a database, using C# async/await patterns.
        */
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _repository.AddAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _repository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}

/*
Certainly! Here’s an explanation of the selected method:

```csharp
public async Task AddBookAsync(Book book)
{
    await _repository.AddAsync(book);
}
```

---

### What Does This Method Do?

- **Purpose:**  
  Adds a new `Book` to the data source (e.g., database) asynchronously.

- **Parameters:**  
  - `Book book`: The book object to be added.

- **Return Type:**  
  - `Task`: Indicates the method is asynchronous and returns no value (void in async context).

- **Implementation:**  
  - Calls `_repository.AddAsync(book)` and awaits its completion.
  - `_repository` is an instance of `IBookRepository`, which defines how books are stored.

---

### Why Use `async` and `await`?

- `async` allows the method to run asynchronously.
- `await` pauses execution until the repository finishes adding the book, without blocking the thread.
- This is important for scalability and responsiveness, especially in web applications.

---

### Usage Example

Suppose you have a controller or another service:

```csharp
await bookService.AddBookAsync(new Book { Title = "Clean Code", Author = "Robert C. Martin", Year = 2008 });
```

This will add the book to your data source asynchronously.

---

### Summary

- This method is part of the service layer.
- It delegates the actual data storage to the repository.
- It uses async/await for non-blocking, scalable operations.
- It’s a best practice for modern .NET applications, especially when working with databases or APIs.
*/

/*
Absolutely! Here’s a beginner-friendly explanation of the `Task` keyword in C#:

---

## What is `Task`?

- `Task` is a type in C# used for asynchronous programming.
- It represents an operation that will finish in the future.
- Think of it like a “promise” that something will be done later.

---

## Why Use `Task`?

- In modern apps, some operations (like saving to a database, calling an API, or reading a file) can take time.
- If you do these operations synchronously, your app will “wait” and can become slow or unresponsive.
- By using `Task`, you let your app start the operation and keep working on other things while it waits for the result.

---

## How Does It Work?

- You mark a method as `async` and return a `Task` (or `Task<T>` for a result).
- Inside the method, you use `await` to pause until the operation is done, but without blocking the thread.

**Example:**
```csharp
public async Task AddBookAsync(Book book)
{
    await _repository.AddAsync(book);
}
```
- This method starts adding a book, but doesn’t block the app while waiting for the database.
- The `Task` tells the caller: “I’m working on it, I’ll let you know when I’m done.”

---

## Types of Task

- `Task`: For methods that don’t return a value (like `void`).
- `Task<T>`: For methods that return a value (like `int`, `Book`, etc.).

---

## How Do You Use It?

When you call an async method, you use `await`:

```csharp
await bookService.AddBookAsync(newBook);
```
- This line waits for the book to be added, but doesn’t block the app.

---

## Summary

- `Task` is used for async operations.
- It helps keep your app fast and responsive.
- It’s a core part of modern C# programming, especially for web and database code.

*/