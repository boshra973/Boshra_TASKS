namespace MVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int Grade { get; set; }

        public int DeptId { get; set; }
        public Department? Department { get; set; }

        public List<CourseStudents> CourseStudents { get; set; } = new();
    }
}
