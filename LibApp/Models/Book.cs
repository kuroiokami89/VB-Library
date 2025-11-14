namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int AvailableCopies { get; set; }

        // Constructor
        public Book(int id, string title, string author, string genre, decimal price, int availableCopies)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            Price = price;
            AvailableCopies = availableCopies;
        }

        // Method to display book information
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Title} by {Author} — Copies: {AvailableCopies} — " + $"Genre: {Genre} — Price: ${Price}");
        }
    }
}
