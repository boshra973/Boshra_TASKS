using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public int Degree { get; set; }
        public int MinimumDegree { get; set; }
        public int Hours { get; set; }

        // FK by convention
        [Required]
        public int DeptId { get; set; }
        public Department? Department { get; set; }

        [Required]

        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public List<CourseStudents> CourseStudents { get; set; } = new();

    }
}
