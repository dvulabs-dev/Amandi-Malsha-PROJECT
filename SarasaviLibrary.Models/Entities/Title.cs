using System.Collections.Generic;

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
        
        public ICollection<BookCopy> Copies { get; set; } = new List<BookCopy>();
    }
}
