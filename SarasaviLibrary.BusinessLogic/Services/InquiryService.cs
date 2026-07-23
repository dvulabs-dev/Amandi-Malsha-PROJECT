using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class InquiryService
    {
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
    }
}
