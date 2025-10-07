namespace MVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Salary { get; set; }
        public int DeptId { get; set; }
        public Department? Department { get; set; }
        public List<Course> Courses { get; set; } = new();
    }
}
