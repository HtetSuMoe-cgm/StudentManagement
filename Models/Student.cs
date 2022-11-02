using System.ComponentModel.DataAnnotations;

namespace LoginAndCRUDCoreProject.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
