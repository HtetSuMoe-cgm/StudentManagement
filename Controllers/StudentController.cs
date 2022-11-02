using LoginAndCRUDCoreProject.Data;
using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAndCRUDCoreProject.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index()
        { 
           return View(await _studentService.doGetStudentList());
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Student());
            }
            else
            {
                return View(_studentService.doGetStudentById(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit(Student student)
        {
            if (ModelState.IsValid)
            {
                if(student.StudentId == 0)
                {
                    _studentService.doAddStudent(student); 
                }
                else
                {
                    _studentService.doUpdateStudent(student);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStudent(int id)
        {
            var studentById = _studentService.doGetStudentById(id);
            _studentService.doDeleteStudent(studentById);
            return RedirectToAction(nameof(Index));
        }
    }
}
