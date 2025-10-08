namespace MVC.Models
{
    public class CourseStudents
    {
        public int CourseStudentsId { get; set; } // PK

        public int StudentId { get; set; }  // fk
        public Student Student { get; set; }

        public int CourseId { get; set; }   //fk
        public Course Course { get; set; }

        public int Degree { get; set; }
    }
}
