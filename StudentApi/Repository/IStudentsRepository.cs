using StudentApi.Models;

namespace StudentApi.Repository
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student);
        Task<bool> UpdateStudent(int id,Student student);
        Task<bool> DeleteStudent(int id);
    }
}
