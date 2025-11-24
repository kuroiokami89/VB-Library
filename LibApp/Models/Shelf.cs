using System.Collections.Generic;
using System.Linq;

namespace LibApp.Models
{
    public class Shelf<T>
        where T : Book
    {
        private List<T> books = new List<T>();

        /// Adds a new book to the shelf.
        public void Add(T book)
        {
            books.Add(book);
        }

        /// Removes a book from the shelf.
        public void Remove(T book)
        {
            books.Remove(book);
        }

        /// Finds and returns a book from the shelf by title, or default if not found.
        public T? Find(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return default(T);
            }

            foreach (var book in books)
            {
                if (book != null && book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return default(T);
        }

        /// Returns a list of all books currently on the shelf.
        public IEnumerable<T> GetAll()
        {
            return books;
        }

        public IEnumerable<T> GetByGenre(string genre)
        {
            return books.Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<T> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return books.Where(b => b.Price >= minPrice && b.Price <= maxPrice);
        }
    }
}
