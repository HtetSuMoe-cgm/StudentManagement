using LoginAndCRUDCoreProject.Data;
using LoginAndCRUDCoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LoginAndCRUDCoreProject.Migrations;

namespace LoginAndCRUDCoreProject.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentdbContext _context;

        public StudentRepository(StudentdbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> dbGetStudentsList()
        {
            var student = await _context.Students.Where(s => s.IsDeleted == false).ToListAsync();
            return student;
        }
        public bool dbAddStudent(Student student)
        {
            student.CreatedAt = DateTime.Now;
            _context.Add(student);
            return SaveStudent();
        }
        public Student dbGetStudentById(int id)
        {
            return _context.Students.Find(id);
        }
        public bool dbUpdateStudent(Student student)
        {
            student.UpdatedAt = DateTime.Now;
            _context.Update(student);
            return SaveStudent();
        }
        
        public bool dbDeleteStudent(Student student)
        {
            student.IsDeleted = true;
            student.DeletedAt = DateTime.Now;
            _context.Update(student);
            return SaveStudent();
        }
        public bool SaveStudent()
        {
            int save = _context.SaveChanges();
            return save > 0;
        }
    }
}
