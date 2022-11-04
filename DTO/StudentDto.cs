using LoginAndCRUDCoreProject.Models;
using System.ComponentModel.DataAnnotations;

namespace LoginAndCRUDCoreProject.DTO
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
