using Backend.Data;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/Teachers")]
    public class TeacherController:ControllerBase
    {
        [HttpGet]
        public List<TeacherModel> Getteachers()
        {
            return TeacherData.GetTeachers();
        }
        [HttpGet("{id}")]
        public TeacherModel Getteacher(int id)
        {
            return TeacherData.GetTeacher(id);
        }
        [HttpPost]
        public bool Postteacher(TeacherModel teacher)
        {
            return TeacherData.Create(teacher);
        }
        [HttpPut("{id}")]
        public bool Putteacher(TeacherModel teacher, int id)
        {
            return TeacherData.Update(teacher, id);
        }
        [HttpDelete("{id}")]
        public bool Deleteteacher(int id)
        {
            return TeacherData.Delete(id);
        }
    }
}
