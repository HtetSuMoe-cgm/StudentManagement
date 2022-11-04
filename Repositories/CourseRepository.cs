using LoginAndCRUDCoreProject.Data;
using LoginAndCRUDCoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAndCRUDCoreProject.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentdbContext _context;

        public CourseRepository(StudentdbContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> dbGetCoursesList()
        {
            var course = await _context.Courses.Where(c => c.IsDeleted == false).ToListAsync();
            return course;
        }
        public bool dbAddCourse(Course course)
        {
            course.CreatedAt = DateTime.Now;
            _context.Add(course);
            return SaveCourse();
        }
       
        public Course dbGetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }
        public bool dbUpdateCourse(Course course)
        {
            course.UpdatedAt = DateTime.Now;
            _context.Update(course);
            return SaveCourse();
        }
        public bool dbDeleteCourse(Course course)
        {
            course.IsDeleted = true;
            course.DeletedAt = DateTime.Now;
            _context.Update(course);
            return SaveCourse();
        }
        public bool SaveCourse()
        {
            int save = _context.SaveChanges();
            return save > 0;
        }
    }
}
