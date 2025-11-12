// using System;
// using System.Collections.Generic;
// using System.Linq;
// using LibApp.Models;

// namespace LibApp.Services
// {
//     public class LoanService
//     {
//         // Store loans in memory
//         private static List<Loan> loans = new List<Loan>();
//         private static int nextId = 1;

//         private BookService bookService = new BookService();
//         private ClientService clientService = new ClientService();

//         // Get all loans with client and book names
//         public List<Loan> GetAllLoans()
//         {
//             return loans.Select(l => new Loan
//             {
//                 Id = l.Id,
//                 ClientId = l.ClientId,
//                 BookId = l.BookId,
//                 BorrowDate = l.BorrowDate,
//                 DueDate = l.DueDate,
//                 ReturnDate = l.ReturnDate,
//                 IsReturned = l.IsReturned,
//                 ClientName = clientService.GetClientById(l.ClientId)?.Name,
//                 BookTitle = bookService.GetBookById(l.BookId)?.Title
//             }).ToList();
//         }

//         // Get active loans (not returned)
//         public List<Loan> GetActiveLoans()
//         {
//             return GetAllLoans().Where(l => !l.IsReturned).ToList();
//         }

//         // Get overdue loans
//         public List<Loan> GetOverdueLoans()
//         {
//             return GetAllLoans()
//                 .Where(l => !l.IsReturned && l.DueDate < DateTime.Now)
//                 .ToList();
//         }

//         // Get client's active loans
//         public List<Loan> GetClientActiveLoans(int clientId)
//         {
//             return GetAllLoans()
//                 .Where(l => l.ClientId == clientId && !l.IsReturned)
//                 .ToList();
//         }

//         // Get client's loan history
//         public List<Loan> GetClientLoanHistory(int clientId)
//         {
//             return GetAllLoans()
//                 .Where(l => l.ClientId == clientId)
//                 .ToList();
//         }

//         // Borrow a book
//         public string BorrowBook(int bookId, int clientId)
//         {
//             var book = bookService.GetBookById(bookId);
//             if (book == null)
//                 return "Book not found";

//             if (book.Status != "Available")
//                 return "Book is not available";

//             var client = clientService.GetClientById(clientId);
//             if (client == null)
//                 return "Client not found";

//             // Create new loan
//             var loan = new Loan
//             {
//                 Id = nextId++,
//                 BookId = bookId,
//                 ClientId = clientId,
//                 BorrowDate = DateTime.Now,
//                 DueDate = DateTime.Now.AddDays(14), // 2 weeks loan period
//                 IsReturned = false
//             };

//             loans.Add(loan);
//             bookService.UpdateBookStatus(bookId, "Borrowed");

//             return $"Book borrowed successfully! Due date: {loan.DueDate.ToShortDateString()}";
//         }

//         // Return a book
//         public string ReturnBook(int loanId)
//         {
//             var loan = loans.FirstOrDefault(l => l.Id == loanId);
//             if (loan == null)
//                 return "Loan not found";

//             if (loan.IsReturned)
//                 return "Book already returned";

//             loan.ReturnDate = DateTime.Now;
//             loan.IsReturned = true;
//             bookService.UpdateBookStatus(loan.BookId, "Available");

//             // Calculate late fee if overdue
//             int daysLate = (DateTime.Now - loan.DueDate).Days;
//             if (daysLate > 0)
//             {
//                 decimal lateFee = CalculateLateFee(daysLate);
//                 return $"Book returned. Late fee: ${lateFee:F2} ({daysLate} days late)";
//             }

//             return "Book returned successfully on time!";
//         }

//         // Calculate late fee
//         public decimal CalculateLateFee(int daysLate)
//         {
//             decimal feePerDay = 0.50m; // $0.50 per day
//             return daysLate * feePerDay;
//         }

//         // Get loan by ID
//         public Loan GetLoanById(int id)
//         {
//             var loan = loans.FirstOrDefault(l => l.Id == id);
//             if (loan != null)
//             {
//                 loan.ClientName = clientService.GetClientById(loan.ClientId)?.Name;
//                 loan.BookTitle = bookService.GetBookById(loan.BookId)?.Title;
//             }
//             return loan;
//         }
//     }
// }
