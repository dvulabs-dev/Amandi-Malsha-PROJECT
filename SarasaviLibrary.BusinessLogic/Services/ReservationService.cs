using System;
using System.Linq;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class ReservationService
    {
        public Reservation ReserveTitle(int userNumber, int titleId)
        {
            using var context = new AppDbContext();
            
            var borrower = context.Borrowers.Find(userNumber);
            if (borrower == null) throw new Exception("Borrower not found.");
            
            var title = context.Titles.Find(titleId);
            if (title == null) throw new Exception("Title not found.");
            
            // Check if there are available copies, if so, no need to reserve.
            bool hasAvailable = context.BookCopies.Any(c => c.TitleId == titleId && c.Status == CopyStatus.Available);
            if (hasAvailable)
                throw new Exception("There are available copies for this title. No need to reserve.");
                
            // Queue reservation
            var reservation = new Reservation
            {
                UserNumber = userNumber,
                TitleId = titleId,
                ReservationDate = DateTime.Now,
                Status = ReservationStatus.Pending
            };
            
            context.Reservations.Add(reservation);
            context.SaveChanges();
            
            return reservation;
        }
    }
}
