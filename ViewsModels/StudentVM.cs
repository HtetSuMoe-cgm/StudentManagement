using System.ComponentModel.DataAnnotations;

namespace LoginAndCRUDCoreProject.ViewsModels
{
    public class StudentVM
    {
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
