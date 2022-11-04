using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.ViewsModels;
using LoginAndCRUDCoreProject.Services;
using Microsoft.AspNetCore.Mvc;
using LoginAndCRUDCoreProject.DTO;

namespace LoginAndCRUDCoreProject.Controllers
{
    public class CourseController : Controller
    {
        public readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> CourseList()
        {
            return View(await _courseService.doGetCourseList());
        }
        public async Task<IActionResult> CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourse(CourseVM coursevm)
        {
            if(ModelState.IsValid)
            {
                CourseDto courseDto = new CourseDto();
                courseDto.CourseName = coursevm.CourseName;
                _courseService.doAddCourse(courseDto);
                
                return RedirectToAction(nameof(CourseList));
            }
            return View("CourseCreate", coursevm);
        }

        public ActionResult UpdateCourse(int id)
        {
            Course course = _courseService.doGetCourseById(id);
            CourseDto courseDto = new CourseDto();
            courseDto.CourseId = course.CourseId;
            courseDto.CourseName =course.CourseName;    
            return View(courseDto);
        }

        [HttpPost]
        public ActionResult UpdateCourse(int id, CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                _courseService.doUpdateCourse(courseDto);
                return RedirectToAction(nameof(CourseList));
            }
            return View(courseDto);
        }

        [HttpPost]
        public ActionResult DeleteCourse(int id)
        {
            var course = _courseService.doGetCourseById(id);
            _courseService.doDeleteCourse(course);
            return RedirectToAction(nameof(CourseList));
        }
    }
}
