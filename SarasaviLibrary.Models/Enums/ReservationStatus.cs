namespace SarasaviLibrary.Models.Enums
{
    public enum ReservationStatus
    {
        Pending,          // Book is still on loan by someone else
        ReadyForPickup,   // Book has been returned; reserved copy is waiting for this borrower
        Fulfilled,        // Borrower has collected the book (loan activated)
        Cancelled
    }
}
