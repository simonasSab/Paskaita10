namespace Uzduotis01
{
    internal class Book
    {
        // Properties
        public int ID { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }
        public int AuthorID { get; set; }

        public Book()
        {
        }
        // Overloaded Constructor
        public Book(string title, int publicationYear, string genre, int authorID)
        {
            Title = title;
            PublicationYear = publicationYear;
            Genre = genre;
            AuthorID = authorID;
        }
        public Book(int id, string title, int publicationYear, string genre, int authorID)
        {
            ID = id;
            Title = title;
            PublicationYear = publicationYear;
            Genre = genre;
            AuthorID = authorID;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"{Title}, {PublicationYear}, Genre: {Genre}, AuthorId: {AuthorID}";
        }
    }
}
