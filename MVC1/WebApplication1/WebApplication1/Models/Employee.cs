using System.ComponentModel.DataAnnotations.Schema;

namespace MVC1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress    { get; set; }
        public int Salary { get; set; }

        //public Department Department { get; set; }
        // generate foreign key: DepartmentID

        // if you want to set the foreign key by yourself
        // [ForeginKey("Department")] --> this must be the object name
        // // that's what are we doing hee 
        public int DepartmentId { get; set; }
       
        public Department Department { get; set; }


    }
}
