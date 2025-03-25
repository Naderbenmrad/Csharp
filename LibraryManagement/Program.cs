public class LibraryManager
{
    static void Main()
    {
        string[] books = new string[5];
        Dictionary<string, bool> borrowedBooks = new Dictionary<string, bool>();
        int booksBorrowed = 0;

        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Remove a book");
            Console.WriteLine("3. Display books");
            Console.WriteLine("4. Search for a book");
            Console.WriteLine("5. Borrow a book");
            Console.WriteLine("6. Check-in a book");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook(books);
                    break;
                case "2":
                    RemoveBook(books);
                    break;
                case "3":
                    DisplayBooks(books);
                    break;
                case "4":
                    SearchBook(books);
                    break;
                case "5":
                    BorrowBook(books, borrowedBooks, ref booksBorrowed);
                    break;
                case "6":
                    CheckInBook(borrowedBooks, ref booksBorrowed);
                    break;
                case "7":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddBook(string[] books)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (string.IsNullOrEmpty(books[i]))
            {
                Console.Write("Enter the title of the book to add: ");
                books[i] = Console.ReadLine();
                Console.WriteLine($"'{books[i]}' added to the library.");
                return;
            }
        }
        Console.WriteLine("The library is full. No more books can be added.");
    }

    static void RemoveBook(string[] books)
    {
        if (books.All(string.IsNullOrEmpty))
        {
            Console.WriteLine("The library is empty. No books to remove.");
            return;
        }

        Console.Write("Enter the title of the book to remove: ");
        string removeBook = Console.ReadLine();

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null && books[i].Equals(removeBook, StringComparison.OrdinalIgnoreCase))
            {
                books[i] = null;
                Console.WriteLine($"'{removeBook}' removed from the library.");
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }

    static void DisplayBooks(string[] books)
    {
        Console.WriteLine("\nAvailable books:");
        bool isEmpty = true;
        for (int i = 0; i < books.Length; i++)
        {
            if (!string.IsNullOrEmpty(books[i]))
            {
                Console.WriteLine($"- {books[i]}");
                isEmpty = false;
            }
        }

        if (isEmpty)
        {
            Console.WriteLine("Library is empty.");
        }
    }

    static void SearchBook(string[] books)
    {
        Console.Write("Enter the title of the book to search: ");
        string searchTitle = Console.ReadLine();

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null && books[i].Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"'{searchTitle}' is available in the library.");
                return;
            }
        }
        Console.WriteLine($"'{searchTitle}' is not in the library.");
    }

    static void BorrowBook(string[] books, Dictionary<string, bool> borrowedBooks, ref int booksBorrowed)
    {
        if (booksBorrowed >= 3)
        {
            Console.WriteLine("You have reached the borrowing limit (3 books).");
            return;
        }

        Console.Write("Enter the title of the book to borrow: ");
        string borrowTitle = Console.ReadLine();

        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] != null && books[i].Equals(borrowTitle, StringComparison.OrdinalIgnoreCase))
            {
                if (borrowedBooks.ContainsKey(borrowTitle) && borrowedBooks[borrowTitle])
                {
                    Console.WriteLine($"'{borrowTitle}' is already borrowed.");
                    return;
                }

                borrowedBooks[borrowTitle] = true;
                booksBorrowed++;
                Console.WriteLine($"'{borrowTitle}' borrowed successfully.");
                return;
            }
        }
        Console.WriteLine($"'{borrowTitle}' is not available in the library.");
    }

    static void CheckInBook(Dictionary<string, bool> borrowedBooks, ref int booksBorrowed)
    {
        Console.Write("Enter the title of the book to check in: ");
        string checkInTitle = Console.ReadLine();

        if (borrowedBooks.ContainsKey(checkInTitle) && borrowedBooks[checkInTitle])
        {
            borrowedBooks[checkInTitle] = false;
            booksBorrowed--;
            Console.WriteLine($"'{checkInTitle}' checked in successfully.");
        }
        else
        {
            Console.WriteLine($"'{checkInTitle}' was not borrowed or does not exist.");
        }
    }
}