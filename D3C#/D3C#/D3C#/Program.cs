using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
class Program
{
    #region part1.1, part1.2 (class calc)
    class Calc
    {
        public int sum(int x,int y)
        {
            return x + y;
        }
        //overloading
        public double sum( double x, int y)
        {
            return x + y;
        }
        public int mul(int x, int y)
        {
            return x * y;
        }
        //overloading multiplication method
        public float mul(float x, float y)
        {
            return x * y;
        }
        public float div(float x, float y)
        {
            if (y != 0f)
            {
                return x / y;
            }
            else return 0;
           
        }
    }
    #endregion
    #region part2.1, part2.2 (class questions)
    class Question 
    {
        // encapsulation property
        // parameters which will be sent to constructors 
        private string header;
        private string body;
        private int mark;

        // here we set values 
        public string Header
        {
            get { return header; }
            set { header = value; }
        }
        public string Body
        {
            get { return body; }
            set { body = value; }
        }
        public int Mark
        {
            get { return mark; }
            set 
            { 
                if (value>=0)
                    mark = value;
            }
          
        }
        // Constructor
        // 1 the default
       public Question()
        {
            header = "--";
            body = "--";
            mark = 0;
        }
        //2 parameteraized constructor 
       public Question(string head,string bod, int mrk)
        {
            header = head;
            body = bod;
            mark = mrk;
        }


        public void show()
        {
            Console.WriteLine($"[{Header}] question is: {Body} \nmark is: {Mark}");
            Console.WriteLine();
        }

    }
    #endregion part1.3 , part 1.4 

    #region part3(MCQ)
    class Question1
    {
        // another way to write setter and getter functions
        // as there is no validations
        public string header { get; set; }
        
        public string body { get; set; }


        public int mark { get; set; }

        public Question1(string Header, string Body, int Mark)
        {
            header = Header;
            body = Body;
            mark = Mark;
        }
        public void show()
        {
            Console.WriteLine($"[{header}] Q:{body} ,({mark}) Marks ");
        }
        public class MCQ
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public int Mark { get; set; }
            public string[] Choices { get; set; }

            // constructor
            public MCQ (string header, string body , int mark , string[]choices)
            {
                Header = header;
                Body = body;
                Mark = mark;
                Choices = choices;
            }
            public void show()
            {
                Console.WriteLine($"[{Header}] Q:{Body} ,({Mark}) Marks ");
                char c = 'a';
                for (int i=0; i<Choices.Length; i++)
                 {
                    Console.WriteLine($"{c}. {Choices[i]}");
                    c++;
                 }
            }
        }
    }
    #endregion

    static void Main(string[] args)
    {
        //#region part1 , part1.2 (demo)
        //Calc operation = new Calc();
        //Console.WriteLine(operation.sum(3, 3));
        //// overloading
        //Console.WriteLine(operation.sum(3.3, 9));
        ////______________________________________
        //Console.WriteLine(operation.mul(3,5));
        ////overloading
        //Console.WriteLine(operation.mul(3.6f,7.2f));
        ////______________________________________
        //Console.WriteLine(operation.div(25,5));
        //Console.WriteLine(operation.div(23,0));
        //#endregion

        //#region part2.1, part 2.2
        //Question question = new Question();
        //question.show();

        ////parameteraized constructor
        //Question question2 = new Question("C#", "What is encapsulation?", 10);
        //question2.show();

        //// use encapsulation property
        //Question question3 = new Question();
        //question3.Header = "DB";
        //question3.Body = "What is ERD?";
        //question3.Mark = 15;
        //question3.show();
        //#endregion part2.1, part 2.2

        #region
        Console.Write("Enter number of questions:");
        int n= Convert.ToInt32 (Console.ReadLine());
        Question1.MCQ[] mcqs = new Question1.MCQ[n];
         
        for(int i = 0;i<n;i++)
        {
            Console.WriteLine("\nQuestion "+(i+1));
            Console.Write("Header: ");
            string header = Console.ReadLine();

            Console.Write("Body: ");
            string body = Console.ReadLine();

            Console.Write("Mark: ");
            int mark = Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("Enter Choices: ");
            string[] choose = new string[4];// 4: a,b,c,d
            char c = 'a';
            for (int j=0;j<4;j++)
            {
                Console.Write($"{c}.");
                choose[j] = Console.ReadLine();
                c++;
            }
            mcqs[i] = new Question1.MCQ(header, body, mark, choose);
            mcqs[i].show();
        }
        #endregion
    }
}
