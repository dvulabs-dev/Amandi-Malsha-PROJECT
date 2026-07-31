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
            
            // Fix: look up by UserNumber, not by EF primary key (Id)
            var borrower = context.Borrowers.FirstOrDefault(b => b.UserNumber == userNumber);
            if (borrower == null) throw new Exception($"Borrower with User Number {userNumber} not found.");
            
            var title = context.Titles.Find(titleId);
            if (title == null) throw new Exception("Title not found.");
            
            // Check if there are available copies — no need to reserve
            bool hasAvailable = context.BookCopies.Any(c => c.TitleId == titleId && c.Status == CopyStatus.Available);
            if (hasAvailable)
                throw new Exception("There are available copies for this title. Please borrow directly instead of reserving.");
            
            // Prevent duplicate reservation by the same borrower for the same title
            bool alreadyReserved = context.Reservations.Any(r =>
                r.UserNumber == userNumber &&
                r.TitleId == titleId &&
                r.Status == ReservationStatus.Pending);
            if (alreadyReserved)
                throw new Exception("You already have a pending reservation for this title.");
            
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

        public object[] GetAllReservationsDetail()
        {
            using var context = new AppDbContext();
            return context.Reservations
                .OrderByDescending(r => r.ReservationDate)
                .Select(r => new
                {
                    ReservationId = r.ReservationId,
                    Date = r.ReservationDate.ToShortDateString(),
                    BookTitle = r.Title.Name,
                    BorrowerName = r.Borrower.Name,
                    Status = r.Status.ToString()
                })
                .ToArray();
        }

        public void DeleteReservation(int id)
        {
            using var context = new AppDbContext();
            var res = context.Reservations.Find(id);
            if (res != null)
            {
                context.Reservations.Remove(res);
                context.SaveChanges();
            }
        }
    }
}
