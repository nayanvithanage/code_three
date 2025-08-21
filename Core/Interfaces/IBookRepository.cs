using code_three.Core.Entities;

namespace code_three.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync(); //?
        /*
        
        ### 1. What is an Interface?

        - An interface in C# defines a contract—a set of methods that a class must implement.
        - Here, `IBookRepository` is an interface for working with books in a data source.

        ### 2. What is `Task<T>`?

        - `Task<T>` is a type used for asynchronous programming in C#.
        - It represents an operation that will complete in the future and eventually return a value of type `T`.
        - In web and database programming, async methods help keep your app responsive and scalable.

        ### 3. What is `IEnumerable<Book>`?

        - `IEnumerable<Book>` is a collection of `Book` objects.
        - It allows you to loop through all books, like with a `foreach` loop.

        ### 4. What is `GetAllAsync()`?

        - This is a method signature (no implementation here, just a definition).
        - The method name ends with `Async` by convention, meaning it’s asynchronous.

        ### 5. What Does This Line Do?

        - It defines a method that, when implemented, will asynchronously fetch all books from a data source (like a database).
        - The method returns a `Task` that, when awaited, gives you a collection of books.

        ### 6. How Do You Use It?

        Suppose you have a class that implements this interface:

        public class BookRepository : IBookRepository
        {
            public async Task<IEnumerable<Book>> GetAllAsync()
            {
                // Fetch books from database asynchronously
                return await dbContext.Books.ToListAsync();
            }
        }

        And you call it like this:

        var books = await bookRepository.GetAllAsync();
        foreach (var book in books)
        {
            Console.WriteLine(book.Title);
        }

        ### 7. Why Use Async?

        - Async methods don’t block the main thread while waiting for slow operations (like database queries).
        - This makes your app more scalable and responsive, especially for web APIs.

        **Summary:**  
        This line defines an asynchronous method in an interface that will return all books as a collection, once the operation completes. It’s a best practice for modern, scalable applications.
        */
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}