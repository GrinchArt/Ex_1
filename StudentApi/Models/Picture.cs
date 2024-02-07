using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Models
{
    public class Picture
    {     
        public int Id { get; set; }     
        public int StudentId { get; set; }
        public string ImageData { get; set; }
    }
}
