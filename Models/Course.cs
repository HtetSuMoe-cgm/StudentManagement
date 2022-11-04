using System.ComponentModel.DataAnnotations;

namespace LoginAndCRUDCoreProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
