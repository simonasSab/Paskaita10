namespace Uzduotis01
{
    internal interface IDatabaseService
    {
        IEnumerable<Author> GetAuthorDetails();
        IEnumerable<Book> GetBookDetails();
        IEnumerable<BookCopies> GetBookCopiesDetails();

        bool DeleteAuthor(int ID);
        bool DeleteBook(int ID);
        bool DeleteBookCopies(int ID);

        bool InsertAuthor(Author author);
        bool InsertBook(Book book);
        bool InsertBookCopies(BookCopies bookCopies);

        bool UpdateAuthor(Author author);
        bool UpdateBook(Book book);
        bool UpdateBookCopies(BookCopies bookCopies);

        void PrintCollection(IEnumerable<object> collection);
    }
}
