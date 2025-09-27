using System;
using static Program;
class Program
{
    #region part3
    public class Subject
    {
        public int Code {  get; set; }
        public string Name { get; set; }
    }
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] subjects { get; set; }
    }
    #endregion part3
    static void Main (string[] args)
    {
        //#region part1
        //List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
        //#region query1
        //var query1 = numbers.Distinct().OrderBy (x => x).ToList();
        //Console.WriteLine("Query1: ");
        //foreach (var number in query1)
        //{
        //    Console.WriteLine(number);
        //}
        //#endregion query1
        //#region query2
        //foreach (var number in query1)
        //{
        //    Console.WriteLine($"Number: {number} , Multiply: {number*number}");
        //}
        //#endregion query2
        //#endregion part1

        //#region part2
        //string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
        //#region query1 pt2
        //var query1pt2 = names.Where( x => x.Length == 3);
        //foreach (var n in query1pt2)
        //{
        //    Console.WriteLine(n);
        //}
        //#endregion query1 pt2

        //#region query2 pt2
        //var query2pt2 = names.Where ( x => x.ToLower().Contains('a'))
        //    .OrderBy(x=>x.Length);
        //foreach (var n in query2pt2)
        //{
        //    Console.WriteLine(n);
        //}
        //#endregion query2 pt2
        //#region query3 pt2
        //var query3pt2 = names.Take(3);
        //foreach (var n in query3pt2)
        //{  Console.WriteLine(n); }
        //#endregion query3 pt2
        //#endregion part2

        #region part3
        List<Student> students = new List<Student>()
        {
            new Student()
            { 
             ID=1, FirstName="Ali", LastName="Mohammed",
             subjects=new Subject[]
             { 
                 new Subject(){ Code=22,Name="EF"},
                 new Subject(){Code=33,Name="UML"}
             }
            },

            new Student()
            { 
                ID=2, FirstName="Mona", LastName="Gala",
             subjects=new Subject []
             {
                new Subject(){ Code=22,Name="EF"},
                new Subject (){Code=34,Name="XML"},
                new Subject (){ Code=25, Name="JS"}
             }
            },
            new Student(){ ID=3, FirstName="Yara", LastName="Yousf",
               subjects=new Subject []{ new Subject (){ Code=22,Name="EF"},
                   new Subject (){Code=25,Name="JS"}}},

            new Student(){ ID=1, FirstName="Ali", LastName="Ali",
            subjects=new Subject []{ new Subject (){ Code=33,Name="UML"}}},
        };
        // query1
        var query1pt3 = students.Select
            (
            s => new
            {
                FullName = s.FirstName + " " + s.LastName,
                SubjectCount = s.subjects.Count()
            }
            );

        //foreach (var stud in query1pt3 )
        //{
        //    Console.WriteLine($"FullName: {stud.FullName}\t, Number of Subjects: {stud.SubjectCount}");
        //}

        // query2
        //var query2pt3 = students.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName)
        //  what will we print:
        // .Select(s => new { s.FirstName, s.LastName });

        // foreach (var stud in query2pt3)
        // {

        //     Console.WriteLine(stud.FirstName + " " + stud.LastName);
        // }

        // query3
        var query3pt3 = students.SelectMany
            (
             s => s.subjects, (student, subject) => new
             {
                 StdName = student.FirstName + " " + student.LastName,
                 subjName = subject.Name
             }
            )
            .GroupBy(x => x.StdName)
            .Select
            (n => new
                {
                   StdName = n.Key, // key to put each studetn within their groups 
                   Subjects = string.Join(", ", n.Select(x => x.subjName))
                 }
            );
        foreach ( var ss in query3pt3 )
        {
            Console.WriteLine($"Student: {ss.StdName},\t Subjects: {ss.Subjects}");
        }

        #endregion part3
    }
}

