namespace MVC1.Models
{
    public class StudentBL
    {
        List <Students> students;
        public StudentBL()
        {
            students = new List<Students>();
            students.Add(new Students() 
            {
                id =1 , 
                name = "Boshra",
                InstructorId =  10,
                departmentId = 20,
                image = "1.png"
            }
            );
            students.Add(new Students() 
            {
                id =2 , 
                name = "Ahmed",
                InstructorId =  10,
                departmentId = 20,
                image = "2.png"
            }
            );
            students.Add(new Students() 
            {
                id =3 , 
                name = "Ola",
                InstructorId =  11,
                departmentId = 23,
                image = "3.png"
            }
            );
            students.Add(new Students() 
            {
                id =4 , 
                name = "Mohsen",
                InstructorId =  12,
                departmentId = 22,
                image = "4.png"
            }
            );
            students.Add(new Students() 
            {
                id =5 , 
                name = "Farida",
                InstructorId =  12,
                departmentId = 22,
                image = "5.png"
            }
            );
        }

        public List<Students> GetAll()
        {
            return students;
        }

        public Students GetById (int id )
        {
            return students.First(s => s.id == id);
        }

    }
}
