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
                Console.WriteLine("3. Exit");
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

            Console.Write("Number of copies: ");
            string copiesInput = Console.ReadLine() ?? "1"; // Handle null input
            int copies = int.TryParse(copiesInput, out int c) ? c : 1;

            // Create and add the book using your existing Book class
            Book newBook = new Book(nextBookId++, title, author, copies);
            shelf.Add(newBook);

            Console.WriteLine($"\n✅ Book '{title}' added successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// Displays all books in the library.
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
    }
}
