using LibApp.Models;

namespace LibApp
{
    class Program
    {
        private static readonly Shelf<Book> shelf = new();
        private static int nextBookId = 1;

        static void Main()
        {
            Console.Title = "VANTABLACK // Cyberpunk Library System";
            Console.CursorVisible = false;

            CyberpunkBoot();
            SplashVantablack();

            while (true)
            {
                Console.Clear();
                DrawFrame("⧉ CYBER LIBRARY INTERFACE // VANTABLACK");

                WriteOption("1", "➕ Add Book", ConsoleColor.Magenta);
                WriteOption("2", "📚 View All Books", ConsoleColor.Cyan);
                WriteOption("3", "🔍 Find Book", ConsoleColor.Yellow);
                WriteOption("4", "⛔ Exit", ConsoleColor.Red);

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n> INPUT: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": ViewBooks(); break;
                    case "3": FindBook(); break;
                    case "4": Exit(); break;

                    default:
                        Warning("System Error: Invalid Option.");
                        Console.ReadKey();
                        break;
                }
            }
        }



        // ======================================================
        // 🟣 CYBERPUNK BOOT + SPLASH
        // ======================================================

        static void CyberpunkBoot()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            string[] boot = {
                "BOOTING VANTABLACK OS █▒▒▒▒▒▒▒▒▒",
                "LOADING NEON MODULES ███▒▒▒▒▒▒▒",
                "ESTABLISHING SECURE LINK ███████▒▒▒",
                "SYNCING CONSOLE INTERFACE ██████████",
                "STATUS: ONLINE"
            };

            foreach (var line in boot)
            {
                Console.WriteLine(line);
                Thread.Sleep(180);
            }

            Thread.Sleep(300);
        }

        static void SplashVantablack()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            string[] splash =
            {
                "██╗   ██╗ █████╗ ███╗   ██╗████████╗ █████╗ ██████╗ ██╗      █████╗  ██████╗██╗  ██╗",
                "██║   ██║██╔══██╗████╗  ██║╚══██╔══╝██╔══██╗██╔══██╗██║     ██╔══██╗██╔════╝██║ ██╔╝",
                "██║   ██║███████║██╔██╗ ██║   ██║   ███████║██████╔╝██║     ███████║██║     █████╔╝ ",
                "╚██╗ ██╔╝██╔══██║██║╚██╗██║   ██║   ██╔══██║██╔══██╗██║     ██╔══██║██║     ██╔═██╗ ",
                " ╚████╔╝ ██║  ██║██║ ╚████║   ██║   ██║  ██║██║  ██║███████╗██║  ██║╚██████╗██║  ██╗",
                "  ╚═══╝  ╚═╝  ╚═╝╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝",
                "                               V A N T A B L A C K  //  S Y S T E M"
            };

            foreach (string line in splash)
            {
                Console.WriteLine(line);
                Thread.Sleep(40);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nINITIALIZING MODULES...\n");
            Thread.Sleep(600);

            Console.ResetColor();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }



        // ======================================================
        // 🟣 MENU ACTIONS (unchanged, only UI enhanced)
        // ======================================================

        static void AddBook()
        {
            Console.Clear();
            DrawFrame("➕ ADD NEW BOOK");

            string title = Prompt("📘 Title");
            string author = Prompt("✍️ Author");
            string genre = Prompt("🏷️ Genre");
            decimal price = PromptDecimal("💸 Price (€)");
            int copies = PromptInt("📦 Copies");

            var book = new Book(nextBookId++, title, author, genre, price, copies);
            shelf.Add(book);

            Success($"\n✔️ Book '{title}' uploaded to database.");
            PressToContinue();
        }

        static void ViewBooks()
        {
            Console.Clear();
            DrawFrame("📚 DATABASE — ALL BOOKS");

            var books = shelf.GetAll();

            if (!books.Any()) Warning("No data available.");
            else
            {
                foreach (var b in books)
                {
                    GlitchWrite($"ID {b.Id}  //  {b.Title}");
                    b.DisplayInfo();
                    Console.WriteLine();
                }
            }

            PressToContinue();
        }

        static void FindBook()
        {
            Console.Clear();
            DrawFrame("🔍 SEARCH DATABASE");

            string title = Prompt("🔎 Enter Title");

            var found = shelf.Find(title);

            if (found != null)
            {
                Success("\n📗 MATCH FOUND:");
                found.DisplayInfo();
            }
            else Warning("\n❌ No match in database.");

            PressToContinue();
        }

        static void Exit()
        {
            Console.Clear();
            DrawFrame("SYSTEM SHUTDOWN");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Closing VANTABLACK Interface...");
            Thread.Sleep(800);

            Environment.Exit(0);
        }



        // ======================================================
        // 🟣 UI HELPERS — ALL CYBERPUNKIZED
        // ======================================================

        static void DrawFrame(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string border = new string('═', title.Length + 10);

            Console.WriteLine($"╔{border}╗");
            Console.WriteLine($"║   {title}   ║");
            Console.WriteLine($"╚{border}╝\n");

            Console.ResetColor();
        }

        static void WriteOption(string number, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($" [{number}] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
        }

        static void GlitchWrite(string text)
        {
            var glitchColors = new[] {
                ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.DarkMagenta,
                ConsoleColor.Blue, ConsoleColor.DarkCyan
            };

            var rnd = new Random();

            foreach (var c in text)
            {
                Console.ForegroundColor = glitchColors[rnd.Next(glitchColors.Length)];
                Console.Write(c);
                Thread.Sleep(6);
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
            Console.WriteLine("\n> Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        static string Prompt(string label)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{label}: ");
            Console.ResetColor();
            return Console.ReadLine() ?? "";
        }

        static decimal PromptDecimal(string label)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{label}: ");
            Console.ResetColor();

            return decimal.TryParse(Console.ReadLine(), out var val) ? val : 0;
        }

        static int PromptInt(string label)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{label}: ");
            Console.ResetColor();

            return int.TryParse(Console.ReadLine(), out var val) ? val : 0;
        }
    }
}
