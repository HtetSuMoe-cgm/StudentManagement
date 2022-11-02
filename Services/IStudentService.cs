using LoginAndCRUDCoreProject.Models;

namespace LoginAndCRUDCoreProject.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> doGetStudentList();
        public bool doAddStudent(Student student);
        public bool doUpdateStudent(Student student);
        public bool doDeleteStudent(Student student);
        public Student doGetStudentById(int id);
    }
}
