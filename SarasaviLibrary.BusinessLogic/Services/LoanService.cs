using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class ActiveLoanDto
    {
        public int LoanId { get; set; }
        public string AccessionNumber { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string BorrowerName { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public bool IsOverdue => DueDate < DateTime.Now;
    }

    public class ReturnedLoanDto
    {
        public int LoanId { get; set; }
        public string AccessionNumber { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string BorrowerName { get; set; } = string.Empty;
        public string ReturnDate { get; set; } = string.Empty;
    }

    /// <summary>
    /// Result returned by CheckLoan – no data is saved, purely informational.
    /// </summary>
    public class LoanCheckResult
    {
        public bool BorrowerFound      { get; set; }
        public string BorrowerName     { get; set; } = string.Empty;
        public int    ActiveLoanCount  { get; set; }
        public bool   HasOverdue       { get; set; }

        public bool   CopyFound        { get; set; }
        public string BookTitle        { get; set; } = string.Empty;
        public CopyStatus CopyStatus   { get; set; }

        /// <summary>True when all rules pass and the librarian can confirm the loan.</summary>
        public bool   CanLoan          { get; set; }
        /// <summary>Human-readable reason why the loan cannot proceed (empty when CanLoan is true).</summary>
        public string BlockReason      { get; set; } = string.Empty;
    }

    public class LoanService
    {
        public System.Collections.Generic.List<ActiveLoanDto> GetAllActiveLoans()
        {
            using var context = new AppDbContext();
            return context.Loans
                .Include(l => l.BookCopy).ThenInclude(c => c.Title)
                .Include(l => l.Borrower)
                .Where(l => l.Status == LoanStatus.Active)
                .Select(l => new ActiveLoanDto
                {
                    LoanId = l.LoanId,
                    AccessionNumber = l.BookCopy.AccessionNumber,
                    BookTitle = l.BookCopy.Title != null ? l.BookCopy.Title.Name : "Unknown",
                    BorrowerName = l.Borrower.Name,
                    DueDate = l.DueDate,
                    Status = l.Status.ToString()
                })
                .ToList();
        }

        /// <summary>
        /// Read-only check: validates all business rules and returns a result object.
        /// Nothing is written to the database.
        /// </summary>
        public LoanCheckResult CheckLoan(int userNumber, string accessionNumber)
        {
            using var context = new AppDbContext();
            var result = new LoanCheckResult();

            // ── Borrower ────────────────────────────────────────────────
            var borrower = context.Borrowers
                .FirstOrDefault(b => b.UserNumber == userNumber);

            if (borrower == null)
            {
                result.BorrowerFound = false;
                result.CanLoan       = false;
                result.BlockReason   = "Borrower not found for User Number " + userNumber + ".";
                return result;
            }

            result.BorrowerFound = true;
            result.BorrowerName  = borrower.Name;

            var activeLoans = context.Loans
                .Where(l => l.UserNumber == userNumber && l.Status == LoanStatus.Active)
                .ToList();

            result.ActiveLoanCount = activeLoans.Count;
            result.HasOverdue      = activeLoans.Any(l => l.DueDate < DateTime.Now);

            // ── Book Copy ───────────────────────────────────────────────
            var copy = context.BookCopies
                .Include(c => c.Title)
                .FirstOrDefault(c => c.AccessionNumber == accessionNumber);

            if (copy == null)
            {
                result.CopyFound   = false;
                result.CanLoan     = false;
                result.BlockReason = "Book copy \"" + accessionNumber + "\" not found.";
                return result;
            }

            result.CopyFound   = true;
            result.BookTitle   = copy.Title?.Name ?? accessionNumber;
            result.CopyStatus  = copy.Status;

            // ── Business Rules ──────────────────────────────────────────
            if (copy.Status == CopyStatus.ReferenceOnly)
            {
                result.CanLoan     = false;
                result.BlockReason = "This copy is Reference Only and cannot be borrowed.";
                return result;
            }

            if (copy.Status != CopyStatus.Available)
            {
                result.CanLoan     = false;
                result.BlockReason = $"Copy is not available (current status: {copy.Status}).";
                return result;
            }

            if (result.ActiveLoanCount >= 5)
            {
                result.CanLoan     = false;
                result.BlockReason = "Borrower already has 5 active loans (maximum reached).";
                return result;
            }

            if (result.HasOverdue)
            {
                result.CanLoan     = false;
                result.BlockReason = "Borrower has overdue books. All overdue copies must be returned first.";
                return result;
            }

            result.CanLoan = true;
            return result;
        }

        /// <summary>
        /// Confirms the loan after the librarian has reviewed the CheckLoan result
        /// and clicked Accept. Applies all guards again for safety.
        /// </summary>
        public Loan PlaceLoan(int userNumber, string accessionNumber)
        {
            using var context = new AppDbContext();
            
            var borrower = context.Borrowers.Include(b => b.ActiveLoans)
                .FirstOrDefault(b => b.UserNumber == userNumber);
            if (borrower == null) throw new Exception("Borrower not found.");
            
            var copy = context.BookCopies
                .FirstOrDefault(c => c.AccessionNumber == accessionNumber);
            if (copy == null) throw new Exception("Book copy not found.");
            
            if (copy.Status == CopyStatus.ReferenceOnly)
                throw new Exception("This book is for reference only and cannot be loaned.");
                
            if (copy.Status != CopyStatus.Available)
                throw new Exception($"Book copy is not available. Current status: {copy.Status}");
                
            var activeLoans = context.Loans
                .Where(l => l.UserNumber == userNumber && l.Status == LoanStatus.Active)
                .ToList();
            
            if (activeLoans.Count >= 5)
                throw new Exception("Borrower has reached the maximum limit of 5 active loans.");
                
            if (activeLoans.Any(l => l.DueDate < DateTime.Now))
                throw new Exception("Borrower has overdue books. Cannot loan more until returned.");
                
            var loan = new Loan
            {
                UserNumber = userNumber,
                CopyId     = copy.CopyId,
                LoanDate   = DateTime.Now,
                DueDate    = DateTime.Now.AddDays(14),
                Status     = LoanStatus.Active
            };
            
            copy.Status = CopyStatus.OnLoan;
            
            context.Loans.Add(loan);
            context.SaveChanges();
            
            return loan;
        }

        public string ReturnLoan(string accessionNumber)
        {
            using var context = new AppDbContext();
            
            var copy = context.BookCopies.Include(c => c.Title)
                .FirstOrDefault(c => c.AccessionNumber == accessionNumber);
            if (copy == null) throw new Exception("Book copy not found.");
            
            var activeLoan = context.Loans
                .FirstOrDefault(l => l.CopyId == copy.CopyId && l.Status == LoanStatus.Active);
            if (activeLoan == null) throw new Exception("This book is not currently on loan.");
            
            activeLoan.Status     = LoanStatus.Returned;
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
                message += $"\nNOTIFICATION: This title was reserved by User {pendingReservation.Borrower.Name} " +
                           $"(ID: {pendingReservation.UserNumber}). The copy is now reserved for them.";
            }
            else
            {
                copy.Status = CopyStatus.Available;
            }
            
            context.SaveChanges();
            context.SaveChanges();
            return message;
        }

        public System.Collections.Generic.List<ReturnedLoanDto> GetAllReturnedLoans()
        {
            using var context = new AppDbContext();
            return context.Loans
                .Include(l => l.BookCopy).ThenInclude(c => c.Title)
                .Include(l => l.Borrower)
                .Where(l => l.Status == LoanStatus.Returned)
                .OrderByDescending(l => l.ReturnDate)
                .Select(l => new ReturnedLoanDto
                {
                    LoanId = l.LoanId,
                    AccessionNumber = l.BookCopy.AccessionNumber,
                    BookTitle = l.BookCopy.Title != null ? l.BookCopy.Title.Name : "Unknown",
                    BorrowerName = l.Borrower.Name,
                    ReturnDate = l.ReturnDate.HasValue ? l.ReturnDate.Value.ToShortDateString() : ""
                })
                .ToList();
        }

        public void DeleteLoan(int id)
        {
            using var context = new AppDbContext();
            var loan = context.Loans.Find(id);
            if (loan != null)
            {
                context.Loans.Remove(loan);
                context.SaveChanges();
            }
        }
    }
}
