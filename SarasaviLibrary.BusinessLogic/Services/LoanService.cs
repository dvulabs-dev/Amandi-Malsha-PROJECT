using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class LoanService
    {
        public Loan PlaceLoan(int userNumber, string accessionNumber)
        {
            using var context = new AppDbContext();
            
            var borrower = context.Borrowers.Include(b => b.ActiveLoans).FirstOrDefault(b => b.UserNumber == userNumber);
            if (borrower == null) throw new Exception("Borrower not found.");
            
            var copy = context.BookCopies.FirstOrDefault(c => c.AccessionNumber == accessionNumber);
            if (copy == null) throw new Exception("Book copy not found.");
            
            if (copy.Status == CopyStatus.ReferenceOnly)
                throw new Exception("This book is for reference only and cannot be loaned.");
                
            if (copy.Status != CopyStatus.Available)
                throw new Exception($"Book copy is not available. Current status: {copy.Status}");
                
            var activeLoans = context.Loans.Where(l => l.UserNumber == userNumber && l.Status == LoanStatus.Active).ToList();
            
            if (activeLoans.Count >= 5)
                throw new Exception("Borrower has reached the maximum limit of 5 active loans.");
                
            if (activeLoans.Any(l => l.DueDate < DateTime.Now))
                throw new Exception("Borrower has overdue books. Cannot loan more until returned.");
                
            var loan = new Loan
            {
                UserNumber = userNumber,
                CopyId = copy.CopyId,
                LoanDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(14),
                Status = LoanStatus.Active
            };
            
            copy.Status = CopyStatus.OnLoan;
            
            context.Loans.Add(loan);
            context.SaveChanges();
            
            return loan;
        }

        public string ReturnLoan(string accessionNumber)
        {
            using var context = new AppDbContext();
            
            var copy = context.BookCopies.Include(c => c.Title).FirstOrDefault(c => c.AccessionNumber == accessionNumber);
            if (copy == null) throw new Exception("Book copy not found.");
            
            var activeLoan = context.Loans.FirstOrDefault(l => l.CopyId == copy.CopyId && l.Status == LoanStatus.Active);
            if (activeLoan == null) throw new Exception("This book is not currently on loan.");
            
            activeLoan.Status = LoanStatus.Returned;
            activeLoan.ReturnDate = DateTime.Now;
            
            // Check for reservations
            var pendingReservation = context.Reservations
                .Include(r => r.Borrower)
                .Where(r => r.TitleId == copy.TitleId && r.Status == ReservationStatus.Pending)
                .OrderBy(r => r.ReservationDate)
                .FirstOrDefault();
                
            string message = "Book returned successfully.";
            
            if (pendingReservation != null)
            {
                copy.Status = CopyStatus.Reserved;
                message += $"\nNOTIFICATION: This title was reserved by User {pendingReservation.Borrower.Name} (ID: {pendingReservation.UserNumber}). The copy is now reserved for them.";
            }
            else
            {
                copy.Status = CopyStatus.Available;
            }
            
            context.SaveChanges();
            
            return message;
        }
    }
}
