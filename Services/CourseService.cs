using LoginAndCRUDCoreProject.DTO;
using LoginAndCRUDCoreProject.Models;
using LoginAndCRUDCoreProject.Repositories;
using System.Collections.Generic;

namespace LoginAndCRUDCoreProject.Services
{
    public class CourseService : ICourseService
    {
        public readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }
        public async Task<List<CourseDto>> doGetCourseList()
        {
            List<CourseDto> courseDtos = new List<CourseDto>();
            var s = await _courseRepository.dbGetCoursesList();
            foreach(var item in s)
            {
                var course = new CourseDto();
                course.CourseId = item.CourseId;
                course.CourseName = item.CourseName;
                courseDtos.Add(course);
            }
            return (courseDtos);
        }
        public bool doAddCourse(CourseDto courseDto)
        {
            Course course = new Course();
            course.CourseName = courseDto.CourseName;
            return _courseRepository.dbAddCourse(course);
        }
        public Course doGetCourseById(int id)
        {
            return _courseRepository.dbGetCourseById(id);
        }
        public bool doUpdateCourse(CourseDto courseDto)
        {
            Course course = _courseRepository.dbGetCourseById(courseDto.CourseId);
            course.CourseName = courseDto.CourseName;
            return _courseRepository.dbUpdateCourse(course);
        }
        public bool doDeleteCourse(Course course)
        { 
            return _courseRepository.dbDeleteCourse(course);
        }
    }
}
