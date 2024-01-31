using TestForInterView.Model.Entity;

namespace TestForInterView.Repository.Interface
{
    public interface ISubjectInterface
    {
        Task<Subject> CreateSubject(Subject subject);
        Task<IEnumerable<Subject>> GetSubjects();
    }
}
