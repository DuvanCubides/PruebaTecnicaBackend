using Backend.Data;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/Courses")]
    public class CourseController:ControllerBase
    {
        [HttpGet]
        public List<CoursesModel> Getcourse()
        {
            return CourseData.GetCourses();
        }
        [HttpGet("{id}")]
        public CoursesModel Getcourse(int id)
        {
            return CourseData.GetCourse(id);
        }
        [HttpPost]
        public bool PostCourse(CoursesModel course)
        {
            return CourseData.Create(course);
        }
        [HttpPut("{id}")]
        public bool Putcourse(CoursesModel course, int id)
        {
            return CourseData.Update(course, id);
        }
        [HttpDelete("{id}")]
        public bool Deletecourse(int id)
        {
            return CourseData.Delete(id);
        }
    }
}
