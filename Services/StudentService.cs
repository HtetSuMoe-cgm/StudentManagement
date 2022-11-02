
using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.Repositories;

namespace LoginAndCRUDCoreProject.Services
{
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _stuRepository;

        public StudentService(IStudentRepository stuRepository)
        {
            this._stuRepository = stuRepository;
        }
        public async Task<List<Student>> doGetStudentList()
        {
            return await _stuRepository.dbGetStudentsList();
        }
        public bool doAddStudent(Student student)
        {
            return _stuRepository.dbAddStudent(student);
        }
        public Student doGetStudentById(int id)
        {
            Student student = _stuRepository.dbGetStudentById(id);
            return student;
        }
        public bool doUpdateStudent(Student student)
        {
            return _stuRepository.dbUpdateStudent(student);
        }
        public bool doDeleteStudent(Student student)
        {
            return _stuRepository.dbDeleteStudent(student);
        }
    }
}
