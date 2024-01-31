using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestForInterView.Model.Entity;
using TestForInterView.Repository.Interface;

namespace TestForInterView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherInterface _teachers;

        public TeacherController(ITeacherInterface _teachers)
        {
            this._teachers = _teachers;
        }
        [HttpPost("CreateTeacher")]
        public async Task<ActionResult> CreateTeacher(Teacher teacher)
        {
            await _teachers.CreateTeacher(teacher);
            return CreatedAtAction("GetTeachers", new { id = teacher.Tid }, teacher);
        }
        [HttpGet("GetTeachers")]
        public async Task<ActionResult> GetTeachers()
        {
            return Ok(await _teachers.GetTeachers());
        }
       
    }
}
