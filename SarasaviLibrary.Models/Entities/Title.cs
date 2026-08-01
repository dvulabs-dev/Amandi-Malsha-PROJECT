using System.Collections.Generic;
using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.Models.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public string BookNumberPrefix { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string AuthorNames { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public BookType BookType { get; set; } = BookType.Borrowable;
        
        public ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int CopyCount => Copies?.Count ?? 0;
    }
}
