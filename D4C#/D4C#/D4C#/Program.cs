

internal class Program
{
    #region Company, Departments, Employees, Courses
    // Departments and Employees are lists names 
    public class Courses
    {
        public string CoursName { get; set; }
        public float CoursePrice { get; set; }
       public Courses(string CourseName,float CoursePrice)
        {
            this.CoursName = CourseName;
            this.CoursePrice = CoursePrice;
        }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        // Employees enrolls courses 
        public List<Courses> courses { get; set; }

        // we should link the courses to the employees 
        public void EnrolledCourses(Courses crs)
        {
            // add to the list name 
            courses.Add(crs);
        }
        public Employee(int EmployeeId,string EmployeeName)
        {
            this.EmployeeId = EmployeeId;
            this.EmployeeName = EmployeeName;
            courses = new List<Courses>();
        }

    }
    public class Department
    {
        public string Dname { get; set; }
        public int DId  { get; set; }

        // Departments contains Employees
        public List<Employee> Employees { get; set; }

        // we should link the employees to departments 
        public void AddEmps(Employee emps)
        {
            Employees.Add(emps);
        }
        public Department(string Dname, int DId)
        {
            this.Dname = Dname;
            this.DId = DId;
            Employees = new List<Employee>();
            
        }
    }
    public class Company
    {
        public string Cname {  get; set; }
        public string CFeild {  get; set; }

        // company contains departments 
        public List<Department> Departments { get; set; }
        public Company(string Cname, string CFeild)
        {
            this.CFeild = CFeild;
            this.Cname = Cname;
            Departments = new List<Department>();
          
        }
        // we should link departments to the company 
        public void AddDeps(Department dep)
        {
            Departments.Add(dep);
        }
        // print employees info
        public void EmployeesInfo()
        {
            foreach (var d in Departments)
            {
                foreach(var e in d.Employees)
                {
                    Console.WriteLine($"Employee Name: {e.EmployeeName}\n" +
                        $"Employee Department: {d.Dname}\nEnrolled Courses:");
                    foreach(var c in e.courses)
                    {
                        Console.WriteLine($"-{c.CoursName} ({c.CoursePrice}$)\n");
                    }
                }
                Console.WriteLine();
            }
        }
      
    }
    #endregion Company, Departments, Employees, Courses

    #region car and engine
    public class Engine
    {
        public string Type { get; set; }
        public Engine (string type)
        {
            Type = type;
        }

    }
    public class Car
    {
        public string Model { get; set; }
        public Car (string model, string engType)
        {
            Model = model;
            Engine engine  = new Engine (engType);
        }
    }
    #endregion car and engine
    #region Instructor, Student, Course2
    public class Course2
    {
        public string nameCrs { get; set; }
        public float priceCrs { get; set; }

        public Course2(string nameCrs, float priceCrs)
        {
            this.nameCrs = nameCrs;
            this.priceCrs = priceCrs;
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age {  get; set; }

        public Person(string name, int age)
        {
            Name = name; Age = age;
        }
        public virtual void Introduce(Course2 c)
        {
            Console.WriteLine("Introducing.");
        }
    }
    public class Instructor : Person
    {
        public Instructor (string name, int age): base(name,age)
        {}
        public void  TeachCourse(Course2 cours)
        {
                                            // print the property itself
            Console.WriteLine($"Instructor: {Name} teaches {cours.nameCrs}");
        }
        public override void Introduce( Course2 c)
        {
            Console.WriteLine($"Good Morning! I am Professor {Name} , I'm {Age} years old ");
            Console.WriteLine($"As an Instructor I will teach you the {c.nameCrs} course");
        }
    }
    public class Student : Person
    {
        public Student (string name, int age): base(name,age)
        {}
        public void  RegisterCourse(Course2 cors)
        {
            Console.WriteLine($"Student: {Name} registered {cors.nameCrs}");

        }
        public override void Introduce( Course2 c)
        {
            Console.WriteLine($"Good Morning! I am student {Name} , I'm {Age} years old ");
            Console.WriteLine($"I learn the {c.nameCrs} course");
        }
    }
    #endregion Instructor, Student, Course2

    #region shapes
    public interface IDrawable
    {
        void Draw();
    }
    public abstract class Shapes: IDrawable
    {
        
        public abstract void Area();// we must override in the inheriting classes 
        public abstract void Draw();
        public Shapes()
        { }
    }
    // interface: outlines what will we do but
    // it doesn't implement what will we actually do 
   
    public class Circles: Shapes 
    {
        public float radius {  get; set; }
        public Circles(float radius) 
        {
            this.radius = radius;
        }
        public override void Area()
        {
            // 3.14 is considered double so taht we must type cast 
            Console.WriteLine($"Area of Circle is {(float)3.14*radius*radius} cm^2");
        }
        public override void Draw()
        {
            Console.WriteLine("Circle Drawing; ");
            Console.WriteLine("  ***  ");
            Console.WriteLine(" *   * ");
            Console.WriteLine("  ***  ");
        }
    }
    public class Rectangle : Shapes 
    {
        public float length {  get; set; }
        public float width {  get; set; }
        public Rectangle(float l, float w)
        {
            length = l;
            width = w;
        }
        public override void Area()
        {
            Console.WriteLine($"Area of rectangle is {length*width} cm^2");
            
        }
        public override void Draw()
        {
            Console.WriteLine("Rectangle Drawing: ");
            Console.WriteLine("------------");
            Console.WriteLine("|          |");
            Console.WriteLine("|          |");
            Console.WriteLine("------------");
        }
    }
    #endregion shapes 

    #region IdGenerator, Instructor, Grade
    public static class IdGenerator
    {
        // static : you don't create a new object 
        // youre sharing the property allover all classes 
        private static int currId = 0;
        public static int GenerateId()
        { return currId++; }
    }
    public abstract class Person1
    { 
      public int Id { get; set; }
        public string Name { get; set; }
        public Person1 (string name)
        {
            Name = name;
            Id = IdGenerator.GenerateId();
        }
    }
    public class Grade
    {
        public int value { get; set; }
        public Grade(int value)
        {
            this.value = value;
        }
        // overloading operator: 
        public static Grade operator  +(Grade g1 , Grade g2)
        {
           // value here is the original property 
            return new Grade(g1.value + g2.value);
        }
        public static Grade operator ==(Grade g3, Grade g4)
        {
            if (g3.value == g4.value)
                return new Grade(1);//same
            else 
                return new Grade(0);//same
        }
        public static Grade operator !=(Grade g3, Grade g4)
        {
            if (g3.value != g4.value)
                return new Grade(1); //diff
            else 
                return new Grade(0); //same
        }

    }
    public class Instructor1 : Person1
    {
        public Instructor1(string name) : base(name) { }
        
    }
    public class Students1 : Person1
    {
        public Students1(string name) : base(name) { }
        // grades 
        public List<Grade> grade = new List<Grade>();
        public Grade Grades { get; set; }
        public Grade TotalGrade()
        {
            Grade total = new Grade(0);
            foreach (var g in grade)
            {
                total += g; 
            }
            return total;
        }
    }
    #endregion IdGenerator, Instructor, Grade

    #region Enum
    enum Courslevel
    { 
        Beginner, Intermediate, Advanced
    }

    #endregion Enum

    #region Sytem
    public class Lesson
    {
        public string name {  get; set; }
        public string level { get; set; }
        public Lesson (string name, string level)
        {
            this.name = name;
            this.level = level;
        }

        // aggregation 
        public Professor assignedProff { get; set; }

    }
    public class Partition
    {
        public string name { get; set; }
        public List<Worker> staff { get; set; } = new List<Worker>();
         public Partition(string name )
            { this.name = name; }

    }
    public class Worker
    {
        public string name { get; set; }
        public Worker(string name) { this.name = name; }
    }
    public class Professor
    {
        public string name { get; set; }
        // list of lessons 
       
        public Professor(string name)
        {
            this.name = name;
        }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

    }
    public class Learner
    {
        public string name { get; set; }
        public Learner(string name)
        { this.name = name; }
        public List<Lesson> lessons { get; set; } = new List<Lesson>();
        // lessons  marks 
        public List<int> scores { get; set; } = new List<int>();
        // total
        public int totalScore()
        {
            int total = 0;
            foreach(int s in scores)
            {
                total += s;
            }
            return total;
        }
    }
    // Company 
    public class Organization
    {
        public string Name { get; set; }
        public List<Partition> Partitions { get; set; } = new List<Partition>();
        public List<Professor> Professors { get; set; } = new List<Professor>();
        public List<Learner> Learners { get; set; } = new List<Learner>();

        public Organization(string name) { Name = name; }
    }

    #endregion System 
    static void Main(string[] args)
    {
        //#region Company, Departments, Employees, Courses
        //// deps with comp done 
        //// emps with deps done 
        //// courses with emps done 
        //Company cmpny = new Company("Meta","Social Media");
        //Department FB = new Department("Facebook",1);
        //Department IG = new Department("Instagram", 2);

        //cmpny.AddDeps(FB);
        //cmpny.AddDeps(IG);

        //Employee E1 = new Employee(10, "Boshra");
        //Employee E2 = new Employee(10, "Ola");
        //// function AddEmps found in the Department class so we need to access 
        //// it through the Departments objects
        //FB.AddEmps(E1);
        //IG.AddEmps(E2);

        //Courses cors1 = new Courses("Ui/Ux", 300f);
        //Courses cors2 = new Courses("Web", 400f);

        //E1.EnrolledCourses(cors1);
        //E2.EnrolledCourses(cors2);

        //// print 
        //cmpny.EmployeesInfo();
        //#endregion Company, Departments, Employees, Courses

        //#region car and engine
        //Car car = new Car("G 63 AMG", "V8");
        //#endregion car and engine

        //#region  Instructor, Student, Course2
        //Course2 Csharp = new Course2("C#", 400f);
        //Course2 Python = new Course2("Python", 500f);

        //Instructor Inst1 = new Instructor("Sabry", 30);
        //Instructor Inst2 = new Instructor("Ola", 25);

        //Student stud1 = new Student("Boshra", 19);
        //Student stud2 = new Student("Basma", 20);

        //Inst1.TeachCourse(Csharp);
        //Inst1.Introduce(Csharp);
        //Console.WriteLine();
        //Inst2.TeachCourse(Python);
        //Inst1.Introduce(Python);

        //Console.WriteLine();
        //stud1.RegisterCourse(Csharp);
        //stud1.Introduce(Csharp);
        //Console.WriteLine();
        //stud2.RegisterCourse(Python);
        //stud2.Introduce(Python);
        //Console.WriteLine();
        //#endregion Instructor, Student, Course2
        //#region shapes
        //List<Shapes> shapes = new List<Shapes>
        //{
        //   new Circles(5),
        //   new Rectangle(2,3)
        //};
        //foreach (Shapes s in shapes)
        //{
        //    s.Area();
        //    s.Draw();
        //    Console.WriteLine();

        //}
        //#endregion shapes 

        //#region IdGenerator, Instructor, Grade
        //Students1 s1 = new Students1("Ola");
        //Students1 s2 = new Students1("Mona");

        //s1.grade.Add(new Grade(10));
        //s1.grade.Add(new Grade(20));

        //s2.grade.Add(new Grade(30));
        //s2.grade.Add(new Grade(40));

        //Console.WriteLine($"Student: {s1.Name}'s total grades is {s1.TotalGrade().value}");
        //Console.WriteLine($"Student: {s2.Name}'s total grades is {s2.TotalGrade().value}");
        //#endregion IdGenerator, Instructor, Grade

        //#region enum
        //Courslevel level = Courslevel.Beginner;
        //switch(level)
        //{
        //   case Courslevel.Beginner:
        //        Console.WriteLine("Good luck starting out!");
        //        break;

        //   case Courslevel.Intermediate:
        //        Console.WriteLine("Great Job!");
        //        break;

        //   case Courslevel.Advanced :
        //        Console.WriteLine("This will be challenging!");
        //        break;
        //}

        //#endregion enum 

        #region Sytem
        
        Organization org = new Organization("BeTech");

        // Add partitions
        Partition electPartition = new Partition("Electronics");
        Partition hrPartition = new Partition("HR");
        org.Partitions.Add(electPartition);
        org.Partitions.Add(hrPartition);

        // Add workers
        electPartition.staff.Add(new Worker("Ahmed"));
        electPartition.staff.Add(new Worker("Soha"));

        hrPartition.staff.Add(new Worker("Hoda"));

        // Add professors
        Professor prof1 = new Professor("Dr. Sabry");
        Professor prof2 = new Professor("Dr. Boshra");
        org.Professors.Add(prof1);
        org.Professors.Add(prof2);

        //lessons
        Lesson lesson1 = new Lesson("C# Basics", "Beginner") { assignedProff = prof1 };
        Lesson lesson2 = new Lesson("Machine Learning", "Advanced") { assignedProff = prof2 };
        prof1.Lessons.Add(lesson1);
        prof2.Lessons.Add(lesson2);

        // Students 
        Learner l1 = new Learner("Ola");
        Learner l2 = new Learner("Mohsen");
        org.Learners.Add(l1);
        org.Learners.Add(l2);

        // set lessons to students 
        l1.lessons.Add(lesson1);
        l1.lessons.Add(lesson2);

        l2.lessons.Add(lesson1);

        // set scores to the students 
        l1.scores.Add(80);
        l1.scores.Add(90);

        l2.scores.Add(70);
        l2.scores.Add(95);

        // reports
        Console.WriteLine("Learners Report: ");
        foreach (var learner in org.Learners)
        {
            Console.WriteLine($"Learner: {learner.name}");
            Console.Write("Enrolled Lessons: ");
            foreach (var lesson in learner.lessons)
            {
                Console.Write($"{lesson.name} ({lesson.level}), ");

            }
            Console.WriteLine($"\nTotal Score: {learner.totalScore()}\n");
        }

        Console.WriteLine("Professors Report: ");
        foreach (var prof in org.Professors)
        {
            Console.WriteLine($"Professor: {prof.name}");
            Console.Write("Lessons they teach: ");

            foreach (var lesson in prof.Lessons)
                Console.Write($"{lesson.name} ({lesson.level}), ");

            Console.WriteLine("\n");
        }

        #endregion System 
    }
}


