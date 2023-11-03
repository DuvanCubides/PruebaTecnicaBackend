using Backend.Data;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/Students")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public List<StudentModel> GetStudents()
        {
            return StudentData.GetStudents();
        }
        [HttpGet("{id}")]
        public StudentModel GetStudent(int id)
        {
            return StudentData.GetStudent(id);
        }
        [HttpPost]
        public bool PostStudent(StudentModel student)
        {
            return StudentData.Create(student);
        }
        [HttpPut("{id}")]
        public bool PutStudent(StudentModel student, int id)
        {
            return StudentData.Update(student, id);
        }
        [HttpDelete("{id}")]
        public bool DeleteStudent(int id)
        {
            return StudentData.Delete(id);
        }
    }
}
