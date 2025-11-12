namespace LibApp.Models
{
    public class Shelf<Book>
    {
        private List<Book> books = new List<Book>();

        /// Adds a new book to the shelf.
        public void Add(Book book)
        {
            books.Add(book);
        }

        /// Returns a list of all books currently on the shelf.
        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        /// Prints a list of all books currently on the shelf to the console.
        public void PrintBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
