

namespace Library_System.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ISBN { get; set; }
        // Foreign key for Author
        public int AuthorId { get; set; }
        // Navigation property 
        public Author Author { get; set; } = null!;
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}