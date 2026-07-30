using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.BusinessLogic.Services
{
    /// <summary>
    /// DTO for a single book copy row in search results, including optional borrower info.
    /// </summary>
    public class BookCopyRow
    {
        public string BookNumber      { get; set; } = string.Empty;
        public string Title           { get; set; } = string.Empty;
        public string Author          { get; set; } = string.Empty;
        public string Publisher       { get; set; } = string.Empty;
        public string Classification  { get; set; } = string.Empty;
        public string BookType        { get; set; } = string.Empty;
        public string Availability    { get; set; } = string.Empty;
        /// <summary>UserNumber of the borrower who currently has this copy on loan. Empty if not on loan.</summary>
        public string BorrowedByUserId { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO returned by SearchBorrower – flat data ready for UI display.
    /// </summary>
    public class BorrowerLoanRow
    {
        public string AccessionNumber { get; set; } = string.Empty;
        public string BookTitle       { get; set; } = string.Empty;
        public DateTime LoanDate      { get; set; }
        public DateTime DueDate       { get; set; }
        public DateTime? ReturnDate   { get; set; }
        public string Status          { get; set; } = string.Empty;
        public bool IsOverdue         { get; set; }
    }

    public class BorrowerSearchResult
    {
        public bool   Found          { get; set; }
        public string Name           { get; set; } = string.Empty;
        public int    UserNumber     { get; set; }
        public string NationalId     { get; set; } = string.Empty;
        public string Address        { get; set; } = string.Empty;
        public string Sex            { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; }
        public int    TotalLoans     { get; set; }
        public int    ActiveLoans    { get; set; }
        public int    OverdueLoans   { get; set; }
        public List<BorrowerLoanRow> Loans { get; set; } = new List<BorrowerLoanRow>();
    }

    public class InquiryService
    {
        /// <summary>
        /// Searches book copies by accession number, title name, or author name.
        /// Returns full copy details including the parent Title for display in the inquiry grid.
        /// </summary>
        public List<BookCopy> SearchCopies(string query)
        {
            using var context = new AppDbContext();
            
            var results = context.BookCopies
                .Include(c => c.Title)
                .Where(c => c.AccessionNumber.Contains(query) || 
                            c.Title.Name.Contains(query) || 
                            c.Title.AuthorNames.Contains(query))
                .ToList();
                
            return results;
        }

        /// <summary>
        /// Same as SearchCopies but also includes the UserNumber of whoever
        /// currently has each copy on loan (empty string if not on loan).
        /// </summary>
        public List<BookCopyRow> SearchCopiesDetail(string query)
        {
            using var context = new AppDbContext();

            var copies = context.BookCopies
                .Include(c => c.Title)
                .Where(c => c.AccessionNumber.Contains(query) ||
                            c.Title.Name.Contains(query) ||
                            c.Title.AuthorNames.Contains(query))
                .ToList();

            // Build a lookup: CopyId → UserNumber for all active loans
            var copyIds = copies.Select(c => c.CopyId).ToList();
            var activeLoanMap = context.Loans
                .Where(l => copyIds.Contains(l.CopyId) && l.Status == LoanStatus.Active)
                .ToDictionary(l => l.CopyId, l => l.UserNumber);

            return copies.Select(c => new BookCopyRow
            {
                BookNumber      = c.AccessionNumber,
                Title           = c.Title.Name,
                Author          = c.Title.AuthorNames,
                Publisher       = c.Title.Publisher,
                Classification  = c.Title.Classification,
                BookType        = c.Title.BookType.ToString(),
                Availability    = c.Status.ToString(),
                BorrowedByUserId = activeLoanMap.TryGetValue(c.CopyId, out int uid)
                                    ? uid.ToString()
                                    : string.Empty
            }).ToList();
        }

        /// <summary>
        /// Searches titles by name or author name.
        /// Used by the reservation form to let the librarian pick a title by name.
        /// </summary>
        public List<Title> SearchTitles(string query)
        {
            using var context = new AppDbContext();

            return context.Titles
                .Where(t => t.Name.Contains(query) || t.AuthorNames.Contains(query))
                .ToList();
        }

        /// <summary>
        /// Looks up a borrower by User Number (numeric) or National ID (string).
        /// Returns borrower profile + full loan history with book details and dates.
        /// </summary>
        public BorrowerSearchResult SearchBorrower(string query)
        {
            using var context = new AppDbContext();

            Borrower? borrower = null;

            // Try as UserNumber first
            if (int.TryParse(query.Trim(), out int userNum))
            {
                borrower = context.Borrowers
                    .FirstOrDefault(b => b.UserNumber == userNum);
            }

            // Fall back to NationalId search
            if (borrower == null)
            {
                borrower = context.Borrowers
                    .FirstOrDefault(b => b.NationalId == query.Trim());
            }

            if (borrower == null)
                return new BorrowerSearchResult { Found = false };

            // Load all loans with book copy + title
            var loans = context.Loans
                .Include(l => l.BookCopy).ThenInclude(c => c.Title)
                .Where(l => l.UserNumber == borrower.UserNumber)
                .OrderByDescending(l => l.LoanDate)
                .ToList();

            var loanRows = loans.Select(l => new BorrowerLoanRow
            {
                AccessionNumber = l.BookCopy.AccessionNumber,
                BookTitle       = l.BookCopy.Title?.Name ?? "—",
                LoanDate        = l.LoanDate,
                DueDate         = l.DueDate,
                ReturnDate      = l.ReturnDate,
                Status          = l.Status.ToString(),
                IsOverdue       = l.Status == LoanStatus.Active && l.DueDate < DateTime.Now
            }).ToList();

            return new BorrowerSearchResult
            {
                Found          = true,
                Name           = borrower.Name,
                UserNumber     = borrower.UserNumber,
                NationalId     = borrower.NationalId,
                Address        = borrower.Address,
                Sex            = borrower.Sex.ToString(),
                RegisteredDate = borrower.RegisteredDate,
                TotalLoans     = loans.Count,
                ActiveLoans    = loans.Count(l => l.Status == LoanStatus.Active),
                OverdueLoans   = loanRows.Count(r => r.IsOverdue),
                Loans          = loanRows
            };
        }
    }
}
