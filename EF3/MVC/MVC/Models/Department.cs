using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(100)]
        public string ManagerName { get; set; } = string.Empty;

        
        public List<Student> Students { get; set; } = new();
        public List<Instructor> Instructors { get; set; } = new();
        public List<Course> Courses { get; set; } = new();
    }
}
