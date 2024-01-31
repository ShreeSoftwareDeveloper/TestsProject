using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestForInterView.Model;
using TestForInterView.Model.Entity;
using TestForInterView.Repository.Interface;
using TestForInterView.Repository.Service;
using TestForInterView.ViewModel;

namespace TestForInterView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentInterface _students;
        private readonly TestForInterviewContext _context;

        public StudentController(IStudentInterface _students, TestForInterviewContext _context)
        {
            this._students = _students;
            this._context = _context;
        }
        [HttpPost("CreateStudent")]
        public async Task<ActionResult> CreateStudent(Student student)
        {
            await _students.CreateStudent(student);
            return CreatedAtAction("GetStudent", new { id = student.RollNo }, student);
        }
        [HttpGet("GetStudents")]
        public async Task<ActionResult> GetStudents()
        {
            return Ok(await _students.GetTeachers());
        }

        [HttpGet("{name}/GetStudentByName")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentByName(string name)
        {
            var result = await _students.GetStudentByName(name);

            if (result == null)
            {
                return NotFound("******Data Is Not available******");
            }
            return Ok(result);

        }
        [HttpGet("GetStudentsWithSubjectsAndTeachers")]
        /* public ActionResult GetStudentsWithSubjectsAndTeachers()
         {
             var result = _context.Students
            .Join(_context.Teachers,
             student => student.Tid,
             teacher => teacher.Tid,
             (student, teacher) => new { Student = student, Teacher = teacher })
             .Join(_context.Subjects,
             joined => joined.Student.Sid,
             subject => subject.Sid,
             (joined, subject) => new { StudentTeacher = joined, Subject = subject })
            .Select(joined => new
             {
            StudentId = joined.StudentTeacher.Student.Sid,
            StudentName = joined.StudentTeacher.Student.Name,
            Class=joined.StudentTeacher.Student.Class,
            TeacherId = joined.StudentTeacher.Teacher.Tid,
            TeacherName = joined.StudentTeacher.Teacher.TeacherName,
            SubjectId = joined.Subject.Sid,
            SubjectName = joined.Subject.SubjectName,
            Language1=joined.Subject.Lanaguage1,
            Language2=joined.Subject.Lanaguage2,
            Language3=joined.Subject.Lanaguage3
            }).ToList();


             return Ok(result);

         
         }*/
        public ActionResult GetStudentsWithSubjectsAndTeachers()
        {
            var result = _students.GetStudentsWithSubjectsAndTeachers();
            return Ok(result);
        }
    }
}