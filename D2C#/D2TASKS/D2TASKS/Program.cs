internal class Program
{
    // for part3
    struct time
    {
        public int hrs, mins, secs;
    };
    static void Main(string[] args)
    {
        #region part1
        Console.Write("Enter number of Students: ");
        int n = Convert.ToInt32(Console.ReadLine());
        string[] names = new string[n];
        for (int i = 0; i < n; i++)
        {
            names[i] = Console.ReadLine();
        }
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
        #endregion
        Console.ReadKey();
        #region part2
        Console.Write("Enter number of Students: ");
        int studentsNum = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number of Tracks: ");
        int Tracks = Convert.ToInt32(Console.ReadLine());
        string[] students = new string[studentsNum];
        string[] tracksArr = new string[studentsNum];
        int[] ages = new int[studentsNum];
        int[] sum = new int[studentsNum];
        int[] total = new int[studentsNum];
        for (int i = 0; i < studentsNum; i++)
        {
            Console.Write($"Enter student number{i+1} name:");
            students[i] = Console.ReadLine();
            Console.Write($"Enter student number{i+1} Track:");
            tracksArr[i] = Console.ReadLine();
            Console.Write($"Enter student number{i + 1} age: ");
            ages[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < studentsNum; i++)// comparing one track by all the others
        {
            for (int j = 0; j < studentsNum; j++)
            {
                if (tracksArr[i] == tracksArr[j])
                {
                    sum[i] += ages[j];
                    total[i]++;
                }
            }
        }

        string[] printedTracks = new string[studentsNum];
        int Counter = 0;
        for (int i = 0; i < studentsNum; i++)
        {
            bool once = false;
            for (int j = 0; j < Counter; j++)
            {
                if (tracksArr[i] == printedTracks[j])
                {
                    once = true;
                }

            }
            if (!once)
            {
                Console.WriteLine($"Average age of Students in {tracksArr[i]} track is {Convert.ToDouble(sum[i] / total[i])} years. ");
                printedTracks[Counter] = tracksArr[i];
                Counter++;
            }
        }
        #endregion

        #region part3
        time Time= new time();
        Time.hrs = Convert.ToInt32(Console.ReadLine());
        Time.mins = Convert.ToInt32(Console.ReadLine());
        Time.secs= Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"{Time.hrs}H:{Time.mins}M:{Time.secs}S");
        #endregion

    }
}
