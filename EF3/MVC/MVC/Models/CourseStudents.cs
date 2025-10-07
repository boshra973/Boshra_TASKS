namespace MVC.Models
{
    public class CourseStudents
    {
        public int CourseStudentsId { get; set; } // PK (Identity)

        public int StudentId { get; set; }  // FK
        public Student Student { get; set; }

        public int CourseId { get; set; }   // FK
        public Course Course { get; set; }

        public int Degree { get; set; }
    }
}
