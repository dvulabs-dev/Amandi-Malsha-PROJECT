using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class InquiryService
    {
        /// <summary>
        /// Searches book copies by accession number, title name, or author name.
        /// Returns full copy details including the parent Title for display in the inquiry grid.
        /// </summary>
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

        /// <summary>
        /// Searches titles by name or author name.
        /// Used by the reservation form to let the librarian pick a title by name.
        /// </summary>
        public List<Title> SearchTitles(string query)
        {
            using var context = new AppDbContext();

            return context.Titles
                .Where(t => t.Name.Contains(query) || t.AuthorNames.Contains(query))
                .ToList();
        }
    }
}
