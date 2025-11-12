using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        [Display(Name = "Book")]
        public int BookId { get; set; }

        [Display(Name = "Borrow Date")]
        public DateTime BorrowDate { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Return Date")]
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned { get; set; }

        // For display purposes (optional)
        public string ClientName { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
    }
}
