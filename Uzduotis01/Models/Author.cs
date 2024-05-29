namespace Uzduotis01
{
    internal class Author
    {
        // Properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }

        public Author()
        {
        }

        // Overloaded Constructor
        public Author(string firstName, string lastName, DateTime birthDate, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Country = country;
        }
        public Author(int id, string firstName, string lastName, DateTime birthDate, string country)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Country = country;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"{FirstName} {LastName}, born in {BirthDate.ToShortDateString()} in {Country}";
        }
    }
}
