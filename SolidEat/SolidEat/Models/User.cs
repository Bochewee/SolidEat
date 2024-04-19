using SQLite;

namespace SolidEat.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100), Unique]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        public int Age { get; set; } 
        public string Role { get; set; }

        public string DisplayInfo => $"Nom: {FirstName} {LastName}, Email: {Email}, Âge: {Age}, Role: {Role}";

    }
}
