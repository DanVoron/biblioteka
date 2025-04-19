class Book
{
    public string Title { get; }

    public string Author { get; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"\"{Title}\" by {Author}";
    }
}

class Library
{
    private static List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Added {book.Title} by {book.Author}");
    }

    public void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(b => b.Title == title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
        else
        {
            Console.WriteLine($"Book {title} not found");
        }
    }

    public void ListBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There are no books");
        }
        else
        {
            Console.WriteLine("Books:");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }

    public void SearchBook(string query)
    {
        var foundBooks = books.FindAll(b =>
            b.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
            b.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

        if (foundBooks.Count > 0)
        {
            Console.WriteLine($"Found {foundBooks.Count} books");
            foreach (var book in foundBooks)
            {
                Console.WriteLine(book);
            }
        }
        else
        {
            Console.WriteLine("No books found");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("Choose a thinge");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. List all books");
            Console.WriteLine("4. Search a book");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Book name: ");
                    string title = Console.ReadLine();
                    Console.WriteLine("Book author: ");
                    string author = Console.ReadLine();
                    Book book = new Book(title, author);
                    library.AddBook(book);
                    break;

                case "2":
                    Console.WriteLine("Book name to delete: ");
                    string titleToRemove = Console.ReadLine();
                    library.RemoveBook(titleToRemove);
                    break;

                case "3":
                    library.ListBooks();
                    break;

                case "4":
                    Console.WriteLine("Book name or author to search: ");
                    string query = Console.ReadLine();
                    library.SearchBook(query);
                    break;

                case "5":
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}