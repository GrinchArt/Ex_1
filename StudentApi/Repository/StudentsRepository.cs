using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        StudentsDbContext context;

        public StudentsRepository(StudentsDbContext context)
        {
            this.context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
           context.Student.AddAsync(student);
            context.SaveChanges();
            return student;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            Student deleteStudent = await context.Student.FindAsync(id);
            context.Student.Remove(deleteStudent);
            context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await context.Student.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await context.Student.FindAsync(id);
        }

        public async Task<bool> UpdateStudent(int id, Student student)
        {
           var updateStudent = await GetStudentById(id);
            if (updateStudent == null)
            {
                return false;
            }
            else
            {
				updateStudent.Name = student.Name;
				updateStudent.Email = student.Email;
                updateStudent.Group = student.Group;
                updateStudent.Rate = student.Rate;
                context.SaveChanges();
            }
            return true;

        }
    }
}
