

namespace Library_System.Models
{
    public class Borrower
    {
        public int BorrowerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; } 
        public ICollection<Loan> Loans { get; set; } = new List<Loan>();
    }
}