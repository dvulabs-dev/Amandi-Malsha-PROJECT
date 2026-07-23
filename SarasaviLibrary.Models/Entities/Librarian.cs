namespace SarasaviLibrary.Models.Entities
{
    public class Librarian : Person
    {
        public int StaffId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
