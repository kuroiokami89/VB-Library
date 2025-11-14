using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibApp
{
    class Program
    {
        static Shelf<Book> shelf = new Shelf<Book>();
        static int nextBookId = 1;

        /// Main program loop that displays the menu and processes user input.
        static void Main()
        {
            Console.Title = "📚 VB Library System";

            while (true)
            {
                Console.Clear(); // Clear the console for better readability
                Console.WriteLine("===== 📚 VB LIBRARY CONSOLE ====="); // Title
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Find Book");
                Console.WriteLine("4. Exit");
                Console.Write("\nChoose an option: ");

                string? choice = Console.ReadLine(); // Add ? to make it nullable

                if (choice == "1")
                {
                    AddBook();
                }
                else if (choice == "2")
                {
                    ViewBooks();
                }
                else if (choice == "3")
                {
                    FindBook();
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Press any key...");
                    Console.ReadKey();
                }
            }
        }

        /// Adds a new book to the library.
        /// This method prompts the user to enter the book's title, author, and number of copies.
        /// It then creates a new Book object and adds it to the Shelf.
        static void AddBook()
        {
            Console.Clear();
            Console.WriteLine("=== ADD NEW BOOK ===");

            Console.Write("Book Title: ");
            string title = Console.ReadLine() ?? ""; // Use ?? to handle null

            Console.Write("Author: ");
            string author = Console.ReadLine() ?? ""; // Use ?? to handle null

            Console.Write("Genre: ");
            string genre = Console.ReadLine() ?? ""; // Handle null input

            Console.Write("Price: ");
            string priceInput = Console.ReadLine() ?? "0"; // Handle null input
            decimal price = decimal.TryParse(priceInput, out decimal p) ? p : 0; //Parsing of the string from priceInput to a float

            Console.Write("Number of copies: ");
            string copiesInput = Console.ReadLine() ?? "1"; // Handle null input
            int copies = int.TryParse(copiesInput, out int c) ? c : 1; //Parsing of the string from copiesInput to an integer

            // Create and add the book using your existing Book class
            Book newBook = new Book(nextBookId++, title, author, genre, price, copies);
            shelf.Add(newBook);

            Console.WriteLine($"\n✅ Book '{title}' added successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// Views all books in the library.
        /// This method displays all books in the library, including their title, author, and number of copies.
        /// It will also display a message if there are no books in the library.
        static void ViewBooks()
        {
            Console.Clear();
            Console.WriteLine("=== ALL BOOKS ===");
            var allBooks = shelf.GetAll();
            if (!allBooks.Any())
            {
                Console.WriteLine("No books in the library.");
            }
            else
            {
                foreach (Book book in allBooks)
                {
                    book.DisplayInfo();
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// Finds and displays a book from the library by title.
        /// If a book is found, it displays the book's information or it displays a message indicating that the book was not found.
        static void FindBook()
        {
            Console.Clear();
            Console.WriteLine("=== FIND A BOOK ===");

            Console.Write("Enter Book Title to Find: ");
            string title = Console.ReadLine() ?? "";

            Book? foundBook = shelf.Find(title);
            if (foundBook != null)
            {
                Console.WriteLine("\n✅ Book Found:");
                foundBook.DisplayInfo();
            }
            else
            {
                Console.WriteLine("\n❌ Book not found.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
