using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class Student
    {      
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Group { get; set; }
        public double Rate { get; set; }
    }
}
