using System;
using System.Linq;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class BookService
    {
        public Title RegisterTitle(string isbn, string name, string authorNames, string publisher, string classification)
        {
            using var context = new AppDbContext();
            
            // Check if title already exists by ISBN
            if (context.Titles.Any(t => t.ISBN == isbn))
            {
                throw new Exception("A title with this ISBN already exists.");
            }
            
            // The brief says classification is 1-byte (e.g. F) and we append 4 digits.
            // Let's just generate the next number for this prefix.
            string prefix = classification.Length > 0 ? classification.Substring(0, 1).ToUpper() : "X";
            
            var existingPrefixCount = context.Titles.Count(t => t.BookNumberPrefix.StartsWith(prefix));
            string newPrefix = $"{prefix}{(existingPrefixCount + 1):D4}";
            
            var title = new Title
            {
                ISBN = isbn,
                Name = name,
                AuthorNames = authorNames,
                Publisher = publisher,
                Classification = classification,
                BookNumberPrefix = newPrefix
            };
            
            context.Titles.Add(title);
            context.SaveChanges();
            return title;
        }

        public void AddCopies(int titleId, int count, bool isReferenceOnly)
        {
            using var context = new AppDbContext();
            
            var title = context.Titles.Find(titleId);
            if (title == null) throw new Exception("Title not found.");
            
            var existingCopiesCount = context.BookCopies.Count(c => c.TitleId == titleId);
            
            for (int i = 1; i <= count; i++)
            {
                string accessionNumber = $"{title.BookNumberPrefix}-{(existingCopiesCount + i):D2}";
                
                var copy = new BookCopy
                {
                    TitleId = titleId,
                    AccessionNumber = accessionNumber,
                    Status = isReferenceOnly ? CopyStatus.ReferenceOnly : CopyStatus.Available
                };
                context.BookCopies.Add(copy);
            }
            
            context.SaveChanges();
        }
    }
}
