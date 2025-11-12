namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int AvailableCopies { get; set; }

        // Constructor
        public Book(int id, string title, string author, int availableCopies)
        {
            Id = id;
            Title = title;
            Author = author;
            AvailableCopies = availableCopies;
        }

        // Method to display book information
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Title} by {Author} — Copies: {AvailableCopies}");
        }
    }
}
