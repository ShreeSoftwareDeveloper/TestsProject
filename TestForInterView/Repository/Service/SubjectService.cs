using TestForInterView.Model.Entity;
using TestForInterView.Model;
using TestForInterView.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace TestForInterView.Repository.Service
{
    public class SubjectService:ISubjectInterface
    {
        private readonly TestForInterviewContext _subjectContext;

        public SubjectService(TestForInterviewContext _subjectContext)
        {
            this._subjectContext = _subjectContext;
        }
        public async Task<Subject> CreateSubject(Subject subject)
        {
            var subjects = await _subjectContext.Subjects.AddAsync(subject);
            await _subjectContext.SaveChangesAsync();
            return subjects.Entity;
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _subjectContext.Subjects.ToListAsync();

        }
    }
}
