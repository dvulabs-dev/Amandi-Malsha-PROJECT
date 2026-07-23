using System;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.Models.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public LoanStatus Status { get; set; }
        
        public int CopyId { get; set; }
        public BookCopy BookCopy { get; set; } = null!;
        
        public int UserNumber { get; set; }
        public Borrower Borrower { get; set; } = null!;
    }
}
