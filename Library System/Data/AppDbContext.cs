using Library_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<Loan> Loans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-M76SFLT\SQL2019;Database=LibrarySystemDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Primary Key
            modelBuilder.Entity<Loan>()
                .HasKey(l => new { l.BookId, l.BorrowerId });

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Loans)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId);

            modelBuilder.Entity<Borrower>()
                .HasMany(b => b.Loans)
                .WithOne(l => l.Borrower)
                .HasForeignKey(l => l.BorrowerId);



        }










    }
}