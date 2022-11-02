using LoginAndCRUDCoreProject.Models;

namespace LoginAndCRUDCoreProject.Repositories
{
    public interface IStudentRepository
    {
        public Task<List<Student>> dbGetStudentsList();
        public bool dbAddStudent(Student student);
        public Student dbGetStudentById(int id);
        public bool dbUpdateStudent(Student student);
        public bool dbDeleteStudent(Student student);
        public bool SaveStudent();
    }
}
