using System;
using System.Linq;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class UserService
    {
        public Borrower RegisterBorrower(string name, string address, Sex sex, string nationalId)
        {
            using var context = new AppDbContext();
            
            // Validate unique NationalId
            if (context.Borrowers.Any(b => b.NationalId == nationalId))
            {
                throw new Exception("A user with this National ID already exists.");
            }
            
            // Generate a unique UserNumber (start at 1001, increment from max existing)
            int nextUserNumber = context.People.Any()
                ? context.People.Max(p => p.UserNumber) + 1
                : 1001;

            var borrower = new Borrower
            {
                Name = name,
                Address = address,
                Sex = sex,
                NationalId = nationalId,
                RegisteredDate = DateTime.Now,
                UserNumber = nextUserNumber
            };
            
            context.Borrowers.Add(borrower);
            context.SaveChanges();
            
            return borrower;
        }

        public System.Collections.Generic.List<Borrower> GetAllBorrowers()
        {
            using var context = new AppDbContext();
            return context.Borrowers.ToList();
        }

        public void UpdateBorrower(int id, string name, string address, Sex sex, string nationalId)
        {
            using var context = new AppDbContext();
            var borrower = context.Borrowers.FirstOrDefault(b => b.Id == id);
            if (borrower == null) throw new Exception("Borrower not found.");

            // Check if another borrower has this NationalId
            if (context.Borrowers.Any(b => b.NationalId == nationalId && b.Id != id))
            {
                throw new Exception("Another user with this National ID already exists.");
            }

            borrower.Name = name;
            borrower.Address = address;
            borrower.Sex = sex;
            borrower.NationalId = nationalId;

            context.SaveChanges();
        }

        public void DeleteBorrower(int id)
        {
            using var context = new AppDbContext();
            var borrower = context.Borrowers.FirstOrDefault(b => b.Id == id);
            if (borrower == null) throw new Exception("Borrower not found.");

            context.Borrowers.Remove(borrower);
            context.SaveChanges();
        }
    }
}
