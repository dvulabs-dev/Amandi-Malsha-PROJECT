using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.Models.Entities;

namespace SarasaviLibrary.DataAccess.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Title> Titles { get; set; } = null!;
        public DbSet<BookCopy> BookCopies { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<Borrower> Borrowers { get; set; } = null!;
        public DbSet<Librarian> Librarians { get; set; } = null!;
        public DbSet<Loan> Loans { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Note: In a real app, use a connection string from appsettings.json
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SarasaviLibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // TPT (Table-Per-Type) mapping for inheritance
            modelBuilder.Entity<Borrower>().ToTable("Borrowers");
            modelBuilder.Entity<Librarian>().ToTable("Librarians");
            
            // Enforce Unique NationalId
            modelBuilder.Entity<Person>()
                .HasIndex(p => p.NationalId)
                .IsUnique();

            // BookCopy to Title relationship
            modelBuilder.Entity<BookCopy>()
                .HasOne(b => b.Title)
                .WithMany(t => t.Copies)
                .HasForeignKey(b => b.TitleId);

            // Loan relationships
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.BookCopy)
                .WithMany()
                .HasForeignKey(l => l.CopyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Borrower)
                .WithMany(b => b.ActiveLoans)
                .HasForeignKey(l => l.UserNumber)
                .OnDelete(DeleteBehavior.Restrict);

            // Reservation relationships
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Title)
                .WithMany()
                .HasForeignKey(r => r.TitleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Borrower)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.UserNumber)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
