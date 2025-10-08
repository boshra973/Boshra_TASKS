using System.ComponentModel.DataAnnotations;


using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    [CustomValidation(typeof(Course), nameof(Course.ValidateDegree))]

    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(20, 50, ErrorMessage = "Minimum degree must be between 20 and 50")]
        public int MinDegree { get; set; }

        [Range(50, 100, ErrorMessage = "Degree must be between 50 and 100")]
        public int Degree { get; set; }

    
        public static ValidationResult? ValidateDegree(Course course, ValidationContext context)
        {
            if (course.MinDegree >= course.Degree)
            {
                return new ValidationResult("Minimum degree must be less than Degree");
            }
            return ValidationResult.Success;
        }

        // foreign key 
        [Required]
        public int DeptId { get; set; }
        public Department? Department { get; set; }

        [Required]

        public int InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
        public List<CourseStudents> CourseStudents { get; set; } = new();

    }
}
