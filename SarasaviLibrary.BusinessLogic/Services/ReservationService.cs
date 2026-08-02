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
    /// Strongly-typed DTO for the Reservations grid.
    /// Anonymous types cast to object[] lose their property metadata,
    /// which breaks DataGridView DataPropertyName binding (blank cells).
    /// </summary>
    public class ReservationDetailDto
    {
        public int    ReservationId   { get; set; }
        public string ReservationDate { get; set; } = string.Empty;
        public string BookTitle       { get; set; } = string.Empty;
        public string BorrowerName    { get; set; } = string.Empty;
        public string Status          { get; set; } = string.Empty;
        public int    UserNumber      { get; set; }
        public int    TitleId         { get; set; }
    }

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
                (r.Status == ReservationStatus.Pending || r.Status == ReservationStatus.ReadyForPickup));
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

        public List<ReservationDetailDto> GetAllReservationsDetail()
        {
            using var context = new AppDbContext();
            return context.Reservations
                .Include(r => r.Title)
                .Include(r => r.Borrower)
                .OrderByDescending(r => r.ReservationDate)
                .AsEnumerable()                         // switch to client-side so ToString() works
                .Select(r => new ReservationDetailDto
                {
                    ReservationId   = r.ReservationId,
                    ReservationDate = r.ReservationDate.ToShortDateString(),
                    BookTitle       = r.Title?.Name  ?? "(unknown)",
                    BorrowerName    = r.Borrower?.Name ?? "(unknown)",
                    Status          = r.Status.ToString(),
                    UserNumber      = r.UserNumber,
                    TitleId         = r.TitleId
                })
                .ToList();
        }

        /// <summary>
        /// Activates the loan for a ReadyForPickup reservation.
        /// Finds the reserved copy, places the loan for the reserved borrower,
        /// and marks the reservation as Fulfilled.
        /// </summary>
        public void ActivateReservationLoan(int reservationId)
        {
            using var context = new AppDbContext();

            var reservation = context.Reservations
                .Include(r => r.Borrower)
                .Include(r => r.Title)
                .FirstOrDefault(r => r.ReservationId == reservationId);

            if (reservation == null)
                throw new Exception("Reservation not found.");

            if (reservation.Status != ReservationStatus.ReadyForPickup)
                throw new Exception("This reservation is not in a Ready-for-Pickup state.");

            // Find the copy that is currently held (Reserved) for this title
            var reservedCopy = context.BookCopies
                .FirstOrDefault(c => c.TitleId == reservation.TitleId && c.Status == CopyStatus.Reserved);

            if (reservedCopy == null)
                throw new Exception("No reserved copy found for this title. The copy may have already been re-allocated.");

            // Validate borrower eligibility
            var borrower = context.Borrowers
                .Include(b => b.ActiveLoans)
                .FirstOrDefault(b => b.UserNumber == reservation.UserNumber);

            if (borrower == null)
                throw new Exception("Borrower not found.");

            var activeLoans = context.Loans
                .Where(l => l.UserNumber == reservation.UserNumber && l.Status == LoanStatus.Active)
                .ToList();

            if (activeLoans.Count >= 5)
                throw new Exception("Borrower already has 5 active loans (maximum reached). Cannot activate loan.");

            if (activeLoans.Any(l => l.DueDate < DateTime.Now))
                throw new Exception("Borrower has overdue books. All overdue copies must be returned before activating this loan.");

            // Place the loan
            var loan = new Loan
            {
                UserNumber = reservation.UserNumber,
                CopyId     = reservedCopy.CopyId,
                LoanDate   = DateTime.Now,
                DueDate    = DateTime.Now.AddDays(14),
                Status     = LoanStatus.Active
            };

            reservedCopy.Status = CopyStatus.OnLoan;
            reservation.Status  = ReservationStatus.Fulfilled;

            context.Loans.Add(loan);
            context.SaveChanges();
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
