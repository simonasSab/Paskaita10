namespace Uzduotis01
{
    internal class BookCopies
    {
        // Properties
        public int ID { get; set; }
        public int BookID { get; set; }
        public string Condition { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }

        public BookCopies()
        {
        }

        // Overloaded Constructor
        public BookCopies(int bookID, string condition, decimal price, int inStock)
        {
            BookID = bookID;
            Condition = condition;
            Price = price;
            InStock = inStock;
        }
        public BookCopies(int id, int bookID, string condition, decimal price, int inStock)
        {
            ID = id;
            BookID = bookID;
            Condition = condition;
            Price = price;
            InStock = inStock;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"BookID:{BookID}, Condition: {Condition}, Price: {Price:C}, In Stock: {InStock}";
        }
    }
}
