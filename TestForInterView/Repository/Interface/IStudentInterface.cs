using TestForInterView.Model.Entity;
using TestForInterView.ViewModel;

namespace TestForInterView.Repository.Interface
{
    public interface IStudentInterface
    {
        Task<IEnumerable<Student>> GetTeachers();
        Task<Student> CreateStudent(Student student);
        Task<IEnumerable<Student>> GetStudentByName(string name);
        List<ResponseViewModel> GetStudentsWithSubjectsAndTeachers();
    }
}
