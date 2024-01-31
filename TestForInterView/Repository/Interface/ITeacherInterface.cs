using TestForInterView.Model.Entity;

namespace TestForInterView.Repository.Interface
{
    public interface ITeacherInterface
    {
        Task<Teacher> CreateTeacher(Teacher teacher);
        Task<IEnumerable<Teacher>> GetTeachers();
    }
}
