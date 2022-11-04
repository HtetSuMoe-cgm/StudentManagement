using LoginAndCRUDCoreProject.DTO;
using LoginAndCRUDCoreProject.Models;

namespace LoginAndCRUDCoreProject.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> doGetStudentList();
        public bool doAddStudent(StudentDto studentDto);
        public bool doUpdateStudent(StudentDto studentDto);
        public bool doDeleteStudent(Student student);
        public Student doGetStudentById(int id);
    }
}
