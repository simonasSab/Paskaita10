namespace Uzduotis01
{
    internal class Program
    {
        // This is an educational testing of the program-database functionality.
        // User has to always provide existing IDs to receive the desired result
        public static void Main(string[] args)
        {
            IDatabaseService databaseService = new DatabaseService("Server=DESKTOP-OD4Q280;Database=Paskaita10;Integrated Security=True;");
            Random random = new();


            // AUTHOR _________________________________________________________________
            databaseService.PrintCollection((List<Author>)databaseService.GetAuthorDetails());

            // Insert Author
            Console.WriteLine($"Insert author...");
            Author author1 = new("Paulius", "Paulauskas", DateTime.Now, "Afghanistan");
            if (databaseService.InsertAuthor(author1))
                Console.WriteLine($"Inserted {author1.ToString()}\n");

            // Delete Author
            Console.WriteLine($"Delete author...");
            if (databaseService.DeleteAuthor(SelectID()))
                Console.WriteLine($"Author deleted\n");

            // Update Author
            Console.WriteLine($"Update author...");
            Author author2 = new(SelectID(), "Pakeistas", "Pakeistauskas", DateTime.Now, "Wonderland");
            if (databaseService.UpdateAuthor(author2))
                Console.WriteLine($"Updated to {author2.ToString()}\n");



            // BOOK _________________________________________________________________
            databaseService.PrintCollection((List<Book>)databaseService.GetBookDetails());

            // Insert Book
            Console.WriteLine($"Insert book by author...");
            Book book1 = new("Kliedesys", 2024, "Horror", SelectID());
            if (databaseService.InsertBook(book1))
                Console.WriteLine($"Inserted {book1.ToString()}\n");

            // Delete Book
            Console.WriteLine($"Delete book...");
            if (databaseService.DeleteBook(SelectID()))
                Console.WriteLine($"Book deleted.\n");

            // Update Book
            Console.WriteLine($"Update book...");
            Book book2 = new("Vytauto Dienorastis", 1411, "Autobiography", SelectID());
            if (databaseService.UpdateBook(book2))
                Console.WriteLine($"Updated to {book2.ToString()}\n");



            // BOOK COPIES _________________________________________________________________
            databaseService.PrintCollection((List<BookCopies>)databaseService.GetBookCopiesDetails());

            // Insert Copies
            Console.WriteLine($"Insert book copies of book...");
            decimal price = (decimal)Math.Round((random.NextDouble() * 100), 2);
            BookCopies bookCopies = new(SelectID(), Enum.GetName(typeof(Condition), random.Next(3)), price, random.Next(5, 150));
            if (databaseService.InsertBookCopies(bookCopies))
                Console.WriteLine($"Inserted {bookCopies.ToString()}\n");

            // Delete Copies
            Console.WriteLine($"Delete book copies...");
            if (databaseService.DeleteBookCopies(SelectID()))
                Console.WriteLine($"Book copies deleted.\n");

            // Update Book Copies
            Console.WriteLine($"Update book copies...");
            price = (decimal)Math.Round((random.NextDouble() * 100), 2);
            BookCopies bookCopies2 = new(SelectID(), Enum.GetName(typeof(Condition), random.Next(3)), price, random.Next(5, 150));
            if (databaseService.UpdateBookCopies(bookCopies2))
                Console.WriteLine($"Updated to {bookCopies2.ToString()}\n");
        }

        public static int SelectID()
        {
            int id;
            bool isInt;
            do
            {
                Console.WriteLine("Enter ID... (Cancel: -1)\n");
                isInt = int.TryParse(Console.ReadLine(), out id);
                if (id == -1)
                {
                    Console.WriteLine("\nCancelled\n");
                    return id;
                }
            }
            while (!isInt || id < 1);

            Console.WriteLine();

            return id;
        }
    }
}
