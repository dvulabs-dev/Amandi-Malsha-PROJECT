using System;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.Models.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }
        
        public int TitleId { get; set; }
        public Title Title { get; set; } = null!;
        
        public int UserNumber { get; set; }
        public Borrower Borrower { get; set; } = null!;
    }
}
