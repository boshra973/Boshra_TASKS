using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "Grade must be between 10 and 100")]
        public int Grade { get; set; }

        [Display(Name = "Department")]
        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public Department? Department { get; set; }
    }
}
