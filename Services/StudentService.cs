
using LoginAndCRUDCoreProject.DTO;
using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.Repositories;
using LoginAndCRUDCoreProject.ViewsModels;

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
        public bool doAddStudent(StudentDto studentDto)
        {
            Student student = new Student();
            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Address = studentDto.Address;
            student.UserId = studentDto.UserId;
            return _stuRepository.dbAddStudent(student);
        }
        public Student doGetStudentById(int id)
        {
            Student student = _stuRepository.dbGetStudentById(id);
            return student;
        }
        public bool doUpdateStudent(StudentDto studentDto)
        {
            Student student = _stuRepository.dbGetStudentById(studentDto.StudentId);
            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Address = studentDto.Address;
            return _stuRepository.dbUpdateStudent(student);
        }
        public bool doDeleteStudent(Student student)
        {
            return _stuRepository.dbDeleteStudent(student);
        }
    }
}
