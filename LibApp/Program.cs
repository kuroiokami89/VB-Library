using LibApp.Models;

namespace LibApp
{
    class Program
    {
        private static readonly Shelf<Book> shelf = new();
        private static int nextBookId = 1;

        static void Main()
        {
            Console.Title = "📚 VB Library System";
            Console.CursorVisible = false;

            while (true)
            {
                Console.Clear();
                DrawFrame("📚 VB LIBRARY SYSTEM");

                WriteOption("1", "📖 Add Book", ConsoleColor.Green);
                WriteOption("2", "📚 View All Books", ConsoleColor.Cyan);
                WriteOption("3", "🔍 Find Book", ConsoleColor.Yellow);
                WriteOption("4", "❌ Exit", ConsoleColor.Red);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n👉 Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": ViewBooks(); break;
                    case "3": FindBook(); break;
                    case "4": Exit(); break;

                    default:
                        Warning("Invalid choice! Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }


        // ---------------------- MENU ACTIONS ----------------------
        static void AddBook()
        {
            Console.Clear();
            DrawFrame("➕ ADD NEW BOOK");

            string title = Prompt("📘 Book Title");
            string author = Prompt("✍️ Author");
            string genre = Prompt("🏷️ Genre");
            decimal price = PromptDecimal("💸 Price (€)");
            int copies = PromptInt("📦 Number of copies");

            var book = new Book(nextBookId++, title, author, genre, price, copies);
            shelf.Add(book);

            Success($"\n✔️ Book '{title}' added successfully!");
            PressToContinue();
        }

        static void ViewBooks()
        {
            Console.Clear();
            DrawFrame("📚 ALL BOOKS");

            var books = shelf.GetAll();

            if (!books.Any())
            {
                Warning("No books found.");
            }
            else
            {
                foreach (var book in books)
                {
                    RainbowWrite($"📘 ID {book.Id} — {book.Title}");
                    book.DisplayInfo();
                    Console.WriteLine();
                }
            }

            PressToContinue();
        }

        static void FindBook()
        {
            Console.Clear();
            DrawFrame("🔍 FIND A BOOK");

            string title = Prompt("🔎 Enter title");

            var found = shelf.Find(title);

            if (found != null)
            {
                Success("\n📗 Book Found:");
                found.DisplayInfo();
            }
            else Warning("\n❌ Book not found.");

            PressToContinue();
        }

        static void Exit()
        {
            Console.Clear();
            DrawFrame("👋 EXITING SYSTEM");
            Console.WriteLine("Thanks for using VB Library!");
            Environment.Exit(0);
        }



        // ---------------------- UI HELPERS ----------------------

        // Fancy box frame
        static void DrawFrame(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            string border = new string('═', title.Length + 6);
            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║   {title}   ║");
            Console.WriteLine($"╚{border}╝\n");

            Console.ResetColor();
        }

        static void WriteOption(string number, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($" {number}. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        static void RainbowWrite(string text)
        {
            ConsoleColor[] colors = 
            {
                ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow,
                ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Blue
            };

            int i = 0;
            foreach (char c in text)
            {
                Console.ForegroundColor = colors[i % colors.Length];
                Console.Write(c);
                i++;
                Thread.Sleep(5); // slight animation
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        static void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        static void PressToContinue()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        static string Prompt(string label)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{label}: ");
            Console.ResetColor();
            return Console.ReadLine() ?? "";
        }

        static decimal PromptDecimal(string label)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{label}: ");
            Console.ResetColor();

            return decimal.TryParse(Console.ReadLine(), out var val) ? val : 0;
        }

        static int PromptInt(string label)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{label}: ");
            Console.ResetColor();

            return int.TryParse(Console.ReadLine(), out var val) ? val : 0;
        }
    }
}
