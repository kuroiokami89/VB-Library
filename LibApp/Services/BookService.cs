// using System;
// using System.Collections.Generic;
// using System.Linq;
// using LibApp.Models;

// namespace LibApp.Services
// {
//     public class BookService
//     {
//         // Store all books in memory (shared across application)
//         private static List<Book> books = new List<Book>();
//         private static int nextId = 1;

//         // Initialize with sample data when app starts
//         static BookService()
//         {
//             books.Add(new Book
//             {
//                 Id = nextId++,
//                 Title = "1984",
//                 ISBN = "978-0451524935",
//                 Author = "George Orwell",
//                 PublicationYear = 1949,
//                 Status = "Available"
//             });

//             books.Add(new Book
//             {
//                 Id = nextId++,
//                 Title = "Harry Potter",
//                 ISBN = "978-0439708180",
//                 Author = "J.K. Rowling",
//                 PublicationYear = 1997,
//                 Status = "Available"
//             });

//             books.Add(new Book
//             {
//                 Id = nextId++,
//                 Title = "To Kill a Mockingbird",
//                 ISBN = "978-0061120084",
//                 Author = "Harper Lee",
//                 PublicationYear = 1960,
//                 Status = "Borrowed"
//             });
//         }

//         public List<Book> GetAllBooks()
//         {
//             return books;
//         }

//         public Book GetBookById(int id)
//         {
//             return books.FirstOrDefault(b => b.Id == id);
//         }

//         public List<Book> SearchBooks(string searchTerm)
//         {
//             if (string.IsNullOrEmpty(searchTerm))
//                 return books;

//             return books.Where(b =>
//                 b.Title.ToLower().Contains(searchTerm.ToLower()) ||
//                 b.Author.ToLower().Contains(searchTerm.ToLower())
//             ).ToList();
//         }

//         public List<Book> GetAvailableBooks()
//         {
//             return books.Where(b => b.Status == "Available").ToList();
//         }

//         public void AddBook(Book book)
//         {
//             book.Id = nextId++;
//             book.Status = "Available";
//             books.Add(book);
//         }

//         public void UpdateBook(Book book)
//         {
//             var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
//             if (existingBook != null)
//             {
//                 existingBook.Title = book.Title;
//                 existingBook.ISBN = book.ISBN;
//                 existingBook.Author = book.Author;
//                 existingBook.PublicationYear = book.PublicationYear;
//             }
//         }

//         public void DeleteBook(int id)
//         {
//             var book = books.FirstOrDefault(b => b.Id == id);
//             if (book != null)
//             {
//                 books.Remove(book);
//             }
//         }

//         public void UpdateBookStatus(int bookId, string status)
//         {
//             var book = books.FirstOrDefault(b => b.Id == bookId);
//             if (book != null)
//             {
//                 book.Status = status;
//             }
//         }
//     }
// }
