using SarasaviLibrary.Models.Enums;

namespace SarasaviLibrary.Models.Entities
{
    public abstract class Person
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Sex Sex { get; set; }
        public string NationalId { get; set; } = string.Empty;
    }
}
