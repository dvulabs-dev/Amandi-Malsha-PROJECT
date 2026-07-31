using System;
using System.Linq;
using SarasaviLibrary.DataAccess.Contexts;
using SarasaviLibrary.Models.Entities;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.BusinessLogic.Services
{
    public class BookService
    {
        public Title RegisterTitle(string isbn, string name, string authorNames, string publisher, string classification, BookType bookType)
        {
            using var context = new AppDbContext();
            
            // Check if title already exists by ISBN
            if (context.Titles.Any(t => t.ISBN == isbn))
            {
                throw new Exception("A title with this ISBN already exists.");
            }
            
            // Generate book number prefix from classification (e.g. F0001)
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
                BookNumberPrefix = newPrefix,
                BookType = bookType
            };
            
            context.Titles.Add(title);
            context.SaveChanges();
            return title;
        }

        public void AddCopies(int titleId, int count, BookType bookType)
        {
            using var context = new AppDbContext();
            
            var title = context.Titles.Find(titleId);
            if (title == null) throw new Exception("Title not found.");
            
            var existingCopiesCount = context.BookCopies.Count(c => c.TitleId == titleId);
            
            CopyStatus copyStatus = bookType == BookType.ReferenceOnly
                ? CopyStatus.ReferenceOnly
                : CopyStatus.Available;
            
            for (int i = 1; i <= count; i++)
            {
                string accessionNumber = $"{title.BookNumberPrefix}-{(existingCopiesCount + i):D2}";
                
                var copy = new BookCopy
                {
                    TitleId = titleId,
                    AccessionNumber = accessionNumber,
                    Status = copyStatus
                };
                context.BookCopies.Add(copy);
            }
            
            context.SaveChanges();
        }

        public System.Collections.Generic.List<Title> GetAllTitles()
        {
            using var context = new AppDbContext();
            return context.Titles.ToList();
        }

        public void UpdateTitle(int id, string isbn, string name, string authorNames, string publisher, string classification, BookType bookType)
        {
            using var context = new AppDbContext();
            var title = context.Titles.FirstOrDefault(t => t.TitleId == id);
            if (title == null) throw new Exception("Title not found.");

            // Check if another title has this ISBN
            if (context.Titles.Any(t => t.ISBN == isbn && t.TitleId != id))
            {
                throw new Exception("Another title with this ISBN already exists.");
            }

            title.ISBN = isbn;
            title.Name = name;
            title.AuthorNames = authorNames;
            title.Publisher = publisher;
            
            // If classification changes, should we recalculate BookNumberPrefix? For now, leave it.
            title.Classification = classification;
            title.BookType = bookType;

            context.SaveChanges();
        }

        public void DeleteTitle(int id)
        {
            using var context = new AppDbContext();
            var title = context.Titles.FirstOrDefault(t => t.TitleId == id);
            if (title == null) throw new Exception("Title not found.");

            // Optionally check for copies/loans before delete if needed, but EF will throw FK exception if copies are associated.
            if (context.BookCopies.Any(c => c.TitleId == id))
            {
                throw new Exception("Cannot delete this book because it has registered copies. Please remove all copies first.");
            }

            context.Titles.Remove(title);
            context.SaveChanges();
        }
    }
}
