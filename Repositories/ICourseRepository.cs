using LoginAndCRUDCoreProject.Models;

namespace LoginAndCRUDCoreProject.Repositories
{
    public interface ICourseRepository
    {
        public Task<List<Course>> dbGetCoursesList();
        public bool dbAddCourse(Course course);
        public Course dbGetCourseById(int id);
        public bool dbUpdateCourse(Course course);
        public bool dbDeleteCourse(Course course);
        public bool SaveCourse();
    }
}
