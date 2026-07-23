using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.Models.Entities
{
    public class BookCopy
    {
        public int CopyId { get; set; }
        public string AccessionNumber { get; set; } = string.Empty;
        public CopyStatus Status { get; set; }
        
        public int TitleId { get; set; }
        public Title Title { get; set; } = null!;
    }
}
