namespace MVC1.Models
{
    public class Students
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string image { get; set; }   

        public int departmentId { get; set; }
        public int InstructorId { get; set; }
    }
}
