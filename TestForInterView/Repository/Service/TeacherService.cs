using Microsoft.EntityFrameworkCore;
using TestForInterView.Model;
using TestForInterView.Model.Entity;
using TestForInterView.Repository.Interface;

namespace TestForInterView.Repository.Service
{
    public class TeacherService : ITeacherInterface
    {
        private readonly TestForInterviewContext _teacherContext;

        public TeacherService(TestForInterviewContext _teacherContext)
        {
            this._teacherContext = _teacherContext;
        }
        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            var teachers = await _teacherContext.Teachers.AddAsync(teacher);
            await _teacherContext.SaveChangesAsync();
            return teachers.Entity;
        }

        public async Task<IEnumerable<Teacher>> GetTeachers()       
        {
                return await _teacherContext.Teachers.ToListAsync();

        }
        
    }
}
