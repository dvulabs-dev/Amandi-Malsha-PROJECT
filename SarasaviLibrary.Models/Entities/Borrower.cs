using System;
using System.Collections.Generic;

namespace SarasaviLibrary.Models.Entities
{
    public class Borrower : Person
    {
        public int UserNumber { get; set; }
        public DateTime RegisteredDate { get; set; }
        
        public ICollection<Loan> ActiveLoans { get; set; } = new List<Loan>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
