using Schulprojekt_Bibliothek.DCF;

namespace Schulprojekt_Bibliothek
{
    public class Program
    {
        private LibraryContext dbContext = new LibraryContext();

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Main_Menu();
        }

        public void Main_Menu()
        {

            bool loggedIn = false;

            while (!loggedIn)
            {
                Console.Clear();
                Console.WriteLine(@"  
   _____                  _       ____              _        
  / ____|                ( )     |  _ \            | |       
 | (___   ___  __ _ _ __ |/ ___  | |_) | ___   ___ | | _____ 
  \___ \ / _ \/ _` | '_ \  / __| |  _ < / _ \ / _ \| |/ / __|
  ____) |  __/ (_| | | | | \__ \ | |_) | (_) | (_) |   <\__ \
 |_____/ \___|\__,_|_| |_| |___/ |____/ \___/ \___/|_|\_\___/
                                                             
                                                             
");

                Console.WriteLine("Welcome to Sean's Books");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Please choose an option: ");
                string loginOrRegister = Console.ReadLine();


                switch (loginOrRegister)
                {
                    case "1":
                        // Login
                        if (Login())
                        {
                            Console.WriteLine("Login successful!");
                            loggedIn = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
                        break;
                    case "2":
                        // Register
                        Register();
                        break;
                    case "3":
                        Console.WriteLine("Goodbye!");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (loggedIn)
                {
                    // If logged in, proceed to main menu
                    MainMenuAfterLogin();
                }
                else
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

        }

        public bool Login()
        {
            Console.WriteLine("Login:");
            Console.Write("Enter Nachname: ");
            string username = Console.ReadLine();

            // Initialize pin to an invalid value
            int pin = -1;

            // Prompt the user to enter a valid pin until they provide one
            while (pin == -1)
            {
                Console.Write("Enter Pin: ");
                string pinInput = Console.ReadLine();

                // Attempt to parse the input into an integer
                if (int.TryParse(pinInput, out int parsedPin))
                {
                    // If parsing succeeds, assign the parsed value to pin
                    pin = parsedPin;
                }
                else
                {
                    // If parsing fails, inform the user and prompt them to try again
                    Console.WriteLine("Invalid input! Please enter a valid numeric pin.");
                }
            }

            // Find user in the database by username and pin
            User user = dbContext.Users.FirstOrDefault(u => u.Nachname == username && u.Pin == pin);

            // Check if user exists
            if (user != null)
            {
                return true;
            }
            else
            {
                // Inform the user that the username or pin is incorrect
                Console.WriteLine("Incorrect username or pin. Please try again.");
                // Return false to indicate login failure
                return false;
            }
        }



        public void Register()
        {
            Console.WriteLine("Registration:");
            Console.Write("Enter Vorname: ");
            string vorname = Console.ReadLine();
            Console.Write("Enter Nachname: ");
            string nachname = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine(); 
            Console.Write("Enter Stadt: ");
            string stadt = Console.ReadLine();
            Console.Write("Enter Pin: ");
            
            int pin;
            while (!int.TryParse(Console.ReadLine(), out pin))
            {
                Console.WriteLine("Invalid input! Please enter a valid numeric pin.");
                Console.Write("Enter Pin: ");
            }
            // Create a new User object
            User newUser = new User
            {
                Vorname = vorname,
                Nachname = nachname,
                Email = email,
                Stadt = stadt,
                Pin = pin
                
            };

            // Add the new user to the database
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            Console.WriteLine("Registration successful!");
        }


        public void MainMenuAfterLogin()
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"  
   _____                  _       ____              _        
  / ____|                ( )     |  _ \            | |       
 | (___   ___  __ _ _ __ |/ ___  | |_) | ___   ___ | | _____ 
  \___ \ / _ \/ _` | '_ \  / __| |  _ < / _ \ / _ \| |/ / __|
  ____) |  __/ (_| | | | | \__ \ | |_) | (_) | (_) |   <\__ \
 |_____/ \___|\__,_|_| |_| |___/ |____/ \___/ \___/|_|\_\___/
                                                             
                                                             
                                                                                       
                1. Search for Books
                2. Borrow a Book
                3. Return a Book
                4. Borrowed Books.
                5. Logout
                         ");
                Console.Write("Please enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Search for books functionality
                        SearchForBooks();
                        break;
                    case "2":
                        // Borrow a book functionality
                        BorrowBook();
                        break;
                    case "3":
                        // Return a book functionality
                        ReturnBook();
                        break;
                    case "4":
                        Console.Write("Enter your Nachname (Last Name): ");
                        string nachname = Console.ReadLine();
                        ShowBorrowedBooks(nachname); 
                        break;
                    case "5":
                        Console.WriteLine("Logout successful!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ShowBorrowedBooks(string nachname)
        {
            Console.Clear();
            Console.WriteLine($"Borrowed Books for {nachname}:\n");
            Console.WriteLine("ID\tTitle\t\t\tBorrow Date\tReturn Date\n");

            var userBorrowings = dbContext.Ausleihungen
                                         .Where(b => b.User.Nachname == nachname)
                                         .ToList();

            if (userBorrowings.Any())
            {
                foreach (var borrowing in userBorrowings)
                {
                    Console.WriteLine($"{borrowing.id}\t{borrowing.Buch.PadRight(30)}{borrowing.AusleihDatum.ToString("dd/MM/yyyy")}\t{borrowing.AbgabeDatum.ToString("dd/MM/yyyy")}");
                }
            }
            else
            {
                Console.WriteLine("No books are currently borrowed by this user.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }



        public void SearchForBooks()
        {
            Console.Clear();
            Console.WriteLine("All Available Books:\n");
            Console.WriteLine("ID\tTitle\t\t\t     Author\t\tPages\n");

            var allBooks = dbContext.Buche.ToList();

            if (allBooks.Any())
            {
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"{book.id}\t{book.Titel.PadRight(30)}{book.Autor.PadRight(25)}{book.Seiten}");
                }
            }

            else
            {
                Console.WriteLine("No books available.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }


        public void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine("Borrow a Book:\n");

            // Display available books
            Console.WriteLine("Available Books:\n");
            Console.WriteLine("ID\tTitle\t\t\tAuthor\t\t\tPages\n");

            var allBooks = dbContext.Buche.ToList();

            if (allBooks.Any())
            {
                foreach (var book in allBooks)
                {
                    Console.WriteLine($"{book.id}\t{book.Titel.PadRight(30)}{book.Autor.PadRight(25)}{book.Seiten}");
                }

                Console.Write("\nEnter the ID of the book you want to borrow: ");
                if (int.TryParse(Console.ReadLine(), out int bookId))
                {
                    var selectedBook = dbContext.Buche.FirstOrDefault(b => b.id == bookId);

                    if (selectedBook != null)
                    {
                        // Book found, proceed to borrow
                        Console.Write("Enter your Nachname (Last Name): ");
                        string nachname = Console.ReadLine();

                        var user = dbContext.Users.FirstOrDefault(u => u.Nachname == nachname);

                        if (user != null)
                        {
                            // User found, proceed to borrow the book
                            Ausleihungen newBorrowing = new Ausleihungen
                            {
                                User = user,
                                Buch = selectedBook.Titel,
                                AusleihDatum = DateTime.Now, // Set borrowing date to current date
                                AbgabeDatum = DateTime.Now.AddDays(14) // Due date is set to 14 days from borrowing
                            };

                            dbContext.Ausleihungen.Add(newBorrowing);
                            dbContext.SaveChanges();

                            Console.WriteLine("Book borrowed successfully!");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("User not found. Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book not found. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid book ID. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("No books available to borrow.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("Return a Book:\n");

            // Display borrowed books
            Console.WriteLine("Borrowed Books:\n");
            Console.WriteLine("ID\tTitle\t\t\tBorrower\t\tBorrow Date\tReturn Date\n");

            var borrowedBooks = dbContext.Ausleihungen.ToList();

            if (borrowedBooks.Any())
            {
                foreach (var borrowing in borrowedBooks)
                {
                    Console.WriteLine($"{borrowing.id}\t{borrowing.Buch.PadRight(30)}{borrowing.User.Nachname.PadRight(25)}{borrowing.AusleihDatum.ToString("dd/MM/yyyy")}\t{borrowing.AbgabeDatum.ToString("dd/MM/yyyy")}");
                }

                Console.Write("\nEnter the ID of the book you want to return: ");
                if (int.TryParse(Console.ReadLine(), out int borrowingId))
                {
                    var selectedBorrowing = dbContext.Ausleihungen.FirstOrDefault(b => b.id == borrowingId);

                    if (selectedBorrowing != null)
                    {
                        // Mark the book as returned
                        dbContext.Ausleihungen.Remove(selectedBorrowing);
                        dbContext.SaveChanges();

                        Console.WriteLine("Book returned successfully!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Borrowing record not found. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid borrowing ID. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("No books are currently borrowed.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }
}