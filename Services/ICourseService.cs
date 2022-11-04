using LoginAndCRUDCoreProject.DTO;
using LoginAndCRUDCoreProject.Models;

namespace LoginAndCRUDCoreProject.Services
{
    public interface ICourseService
    {
        public Task<List<CourseDto>> doGetCourseList();
        public bool doAddCourse(CourseDto course);
        public Course doGetCourseById(int id);
        public bool doUpdateCourse(CourseDto courseDto);
        public bool doDeleteCourse(Course course);
    }
}
