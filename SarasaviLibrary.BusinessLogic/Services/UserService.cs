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
            
            var borrower = new Borrower
            {
                Name = name,
                Address = address,
                Sex = sex,
                NationalId = nationalId,
                RegisteredDate = DateTime.Now
            };
            
            context.Borrowers.Add(borrower);
            context.SaveChanges();
            
            return borrower;
        }
    }
}
