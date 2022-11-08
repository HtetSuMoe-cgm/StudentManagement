using LoginAndCRUDCoreProject.Data;
using LoginAndCRUDCoreProject.DTO;
using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.Services;
using LoginAndCRUDCoreProject.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAndCRUDCoreProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly UserManager<User> _userManager;

        public StudentController(IStudentService studentService, UserManager<User> userManager)
        {
            _studentService = studentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        { 
           return View(await _studentService.doGetStudentList());
        }

        //[Authorize(Policy = "RequireAdministratorRole")]
        //public IActionResult AddOrEdit(int id=0)
        //{
        //    if (id == 0)
        //    {
        //        return View(new Student());
        //    }
        //    else
        //    {
        //        return View(_studentService.doGetStudentById(id));
        //    }
        //}

        //[Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(StudentVM studentVM)
        {
            //private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
            var userId = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                StudentDto studentDto = new StudentDto();
                studentDto.Name = studentVM.Name;
                studentDto.Email = studentVM.Email;
                studentDto.Address = studentVM.Address;
                studentDto.UserId = userId;
                _studentService.doAddStudent(studentDto);

                return RedirectToAction(nameof(Index));
                //return View("/courseList");
            }
            return View("CreateStudent", studentVM);
        }

        //[Authorize(Policy = "RequireAdministratorRole")]
        public ActionResult UpdateStudent(int id)
        {
            Student student = _studentService.doGetStudentById(id);
            StudentDto studentDto = new StudentDto();
            studentDto.StudentId = student.StudentId;
            studentDto.Name = student.Name;
            studentDto.Email = student.Email;
            studentDto.Address = student.Address;
            return View(studentDto);
        }

        [HttpPost]
        public ActionResult UpdateStudent(int id, StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                _studentService.doUpdateStudent(studentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDto);
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
