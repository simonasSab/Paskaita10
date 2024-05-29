using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Uzduotis01
{
    internal class DatabaseService : IDatabaseService
    {
        private readonly string _connectionString;
        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Author> GetAuthorDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT * FROM Author";

                return db.Query<Author>(sql);
            }
        }
        public IEnumerable<Book> GetBookDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT * FROM Book";

                return db.Query<Book>(sql);
            }
        }
        public IEnumerable<BookCopies> GetBookCopiesDetails()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                SELECT * FROM BookCopies";

                return db.Query<BookCopies>(sql);
            }
        }

        public bool InsertAuthor(Author author)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Author (FirstName, LastName, BirthDate, Country) VALUES (@FirstName, @LastName, @BirthDate, @Country);";
                if (db.Execute(sql, author) > 0)
                    return true;
            }
            return false;
        }
        public bool InsertBook(Book book)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO Book (Title, PublicationYear, Genre, AuthorID) VALUES (@Title, @PublicationYear, @Genre, @AuthorID);";
                if (db.Execute(sql, book) > 0)
                    return true;
            }
            return false;
        }
        public bool InsertBookCopies(BookCopies bookCopies)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = "INSERT INTO BookCopies (BookID, Condition, Price, InStock) VALUES (@BookID, @Condition, @Price, @InStock);";
                if (db.Execute(sql, bookCopies) > 0)
                    return true;
            }
            return false;
        }

        public bool DeleteAuthor(int ID)
        {
            foreach (Book book in GetBookDetails())
            {
                if (book.AuthorID == ID)
                {
                    Console.WriteLine("Author still has books and cannot be deleted.\n");
                    return false;
                }
            }

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                DELETE FROM Author WHERE ID = @ID";
                if (db.Execute(sql, new { ID }) > 0)
                    return true;
                else
                    Console.WriteLine("ID not found, Author entry not deleted\n");
            }
            return false;
        }
        public bool DeleteBook(int ID)
        {
            foreach (BookCopies bookCopies in GetBookCopiesDetails())
            {
                if (bookCopies.BookID == ID)
                {
                    Console.WriteLine("Book still has copies and cannot be deleted.\n");
                    return false;
                }
            }
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                DELETE FROM Book WHERE ID = @ID";
                if (db.Execute(sql, new { ID }) > 0)
                    return true;
                else
                    Console.WriteLine("ID not found, Book entry not deleted\n");
            }
            return false;
        }
        public bool DeleteBookCopies(int ID)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                DELETE FROM BookCopies WHERE ID = @ID";
                if (db.Execute(sql, new { ID }) > 0)
                    return true;
                else
                    Console.WriteLine("ID not found, Book Copies entry not deleted\n");
            }
            return false;
        }

        public bool UpdateAuthor(Author author)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                UPDATE Author 
                SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate, Country = @Country
                WHERE ID = @ID";
                if (db.Execute(sql, author) > 0)
                    return true;
            }
            return false;
        }
        public bool UpdateBook(Book book)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                UPDATE Book 
                SET Title = @Title, PublicationYear = @PublicationYear, Genre = @Genre, AuthorID = @AuthorID
                WHERE ID = @ID";
                if (db.Execute(sql, book) > 0)
                    return true;
                else
                    Console.WriteLine("AuthorID not found, Book entry not updated\n");
            }
            return false;
        }
        public bool UpdateBookCopies(BookCopies bookCopies)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                const string sql = @"
                UPDATE BookCopies 
                SET BookID = @BookID, Condition = @Condition, Price = @Price, InStock = @InStock
                WHERE ID = @ID";
                if (db.Execute(sql, bookCopies) > 0)
                    return true;
                else
                    Console.WriteLine("BookID not found, BookCopies entry not updated\n");
            }
            return false;
        }

        public void PrintCollection(IEnumerable<object> collection)
        {
            int count = collection.Count();
            if (count == 0)
            {
                Console.WriteLine("The collection is empty.\n");
                return;
            }

            if (collection.FirstOrDefault() is Author)
            {
                foreach (object obj in collection)
                {
                    Author author = (Author)obj;
                    Console.WriteLine($"ID:{author.ID} {author.ToString()}");
                }
                Console.WriteLine();
            }
            else if (collection.FirstOrDefault() is Book)
            {
                foreach (object obj in collection)
                {
                    Book book = (Book)obj;
                    Console.WriteLine($"ID:{book.ID} {book.ToString()}");
                }
                Console.WriteLine();
            }
            else if (collection.FirstOrDefault() is BookCopies)
            {
                foreach (object obj in collection)
                {
                    BookCopies bookCopies = (BookCopies)obj;
                    Console.WriteLine($"ID:{bookCopies.ID} {bookCopies.ToString()}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Collection object is not Author, Book or BookCopies");
                return;
            }
        }
    }
}
