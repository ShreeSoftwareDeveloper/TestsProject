
using Microsoft.EntityFrameworkCore;
using TestForInterView.Model;
using TestForInterView.Model.Entity;
using TestForInterView.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using TestForInterView.ViewModel;

namespace TestForInterView.Repository.Service
{
    public class StudentService:IStudentInterface
    {
        private readonly TestForInterviewContext _context;

        public StudentService(TestForInterviewContext _context)
        {
            this._context = _context;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var students = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return students.Entity;
        }

        public async Task<IEnumerable<Student>>GetTeachers()
        {
            return await _context.Students.ToListAsync();          

        }
        public async Task<IEnumerable<Student>> GetStudentByName(string name)
        {
            IQueryable<Student> query = _context.Students;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            return await query.ToListAsync();


        }
        public List<ResponseViewModel> GetStudentsWithSubjectsAndTeachers()
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
                .Select(joined => new ResponseViewModel
                {
                    StudentId = joined.StudentTeacher.Student.RollNo,
                    StudentName = joined.StudentTeacher.Student.Name,
                    ClassName = joined.StudentTeacher.Student.Class,
                    TeacherId = joined.StudentTeacher.Teacher.Tid,
                    TeacherName = joined.StudentTeacher.Teacher.TeacherName,
                    SubjectId = joined.Subject.Sid,
                    SubjectName = joined.Subject.SubjectName,
                    Language1 = joined.Subject.Lanaguage1,
                    Language2 = joined.Subject.Lanaguage2,
                    Language3 = joined.Subject.Lanaguage3
                }).ToList();

            return result;
        }

    }
}
