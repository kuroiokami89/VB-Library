# 📚 VB Library System

A lightweight, console-based library management application built with **C# .NET 9.0**. Manage books on shelves with search, categorization, and pricing features.

---

## 🎯 Features

- **Add Books** — Create new book entries with title, author, genre, price, and available copies.
- **View All Books** — Display all books in the library with complete details.
- **Find Books** — Search for books by title (case-insensitive).
- **Filter by Genre** — Retrieve books grouped by genre.
- **Price Range Filtering** — Find books within a specified price range.
- **In-Memory Storage** — Fast, zero-setup data management (persists during runtime).

---

## 📋 Project Structure

```
LibApp/
├── Models/
│   ├── Book.cs           # Book entity with title, author, genre, price, copies
│   └── Shelf.cs          # Generic shelf container for books with search/filter methods
├── Program.cs            # Main console application entry point and UI logic
├── LibApp.csproj         # Project file (targets .NET 9.0)
└── README.md             # This file
```

---

## 🔧 Models

### Book
Represents a single book in the library.

| Property | Type | Description |
|----------|------|-------------|
| `Id` | `int` | Unique identifier |
| `Title` | `string` | Book title |
| `Author` | `string` | Author name |
| `Genre` | `string` | Book genre/category |
| `Price` | `decimal` | Book price |
| `AvailableCopies` | `int` | Number of copies available |

**Methods:**
- `DisplayInfo()` — Prints book details to console in a formatted manner.

### Shelf<T>
A generic container for managing books with search and filtering capabilities.

| Method | Returns | Description |
|--------|---------|-------------|
| `Add(T book)` | `void` | Adds a book to the shelf |
| `Remove(T book)` | `void` | Removes a book from the shelf |
| `Find(string title)` | `T?` | Finds a book by title (case-insensitive); returns `null` if not found |
| `GetAll()` | `IEnumerable<T>` | Returns all books on the shelf |
| `GetByGenre(string genre)` | `IEnumerable<T>` | Returns books matching the specified genre |
| `GetByPriceRange(decimal minPrice, decimal maxPrice)` | `IEnumerable<T>` | Returns books within the price range |
| `PrintBooks()` | `void` | Prints all books to console |

---

## 🚀 Getting Started

### Prerequisites
- **.NET 9.0 SDK** ([Download](https://dotnet.microsoft.com/download/dotnet/9.0))
- A terminal or command prompt

### Installation & Running

1. **Clone or navigate to the project:**
   ```powershell
   cd "c:\Current Projects\C#\VB-Library\LibApp"
   ```

2. **Build the project:**
   ```powershell
   dotnet build
   ```

3. **Run the application:**
   ```powershell
   dotnet run
   ```

4. **Follow the console menu:**
   ```
   ===== 📚 VB LIBRARY CONSOLE =====
   1. Add Book
   2. View All Books
   3. Find Book
   4. Exit
   
   Choose an option:
   ```

---

## 📖 Usage Examples

### Adding a Book
```
Choose an option: 1

=== ADD NEW BOOK ===
Book Title: The Great Gatsby
Author: F. Scott Fitzgerald
Genre: Fiction
Price: 12.99
Number of copies: 5

✅ Book 'The Great Gatsby' added successfully!
```

### Viewing All Books
```
Choose an option: 2

=== ALL BOOKS ===
The Great Gatsby by F. Scott Fitzgerald — Copies: 5 — Genre: Fiction — Price: $12.99
1984 by George Orwell — Copies: 3 — Genre: Dystopian — Price: $15.99
```

### Finding a Book
```
Choose an option: 3

=== FIND A BOOK ===
Enter Book Title to Find: 1984

✅ Book Found:
1984 by George Orwell — Copies: 3 — Genre: Dystopian — Price: $15.99
```

---

## 🛠 Technologies

- **Language:** C# 12+
- **Framework:** .NET 9.0
- **Architecture:** Console Application with Generic Collections
- **Features:** Nullable Reference Types, String Interpolation, LINQ

---

## 📧 Contact

For questions or feedback, reach out via the repository's issue tracker or contact the maintainer.

---

**Happy reading! 📚**
