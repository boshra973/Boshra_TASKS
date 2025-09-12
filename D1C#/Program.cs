static void Main(string[] args)
{
    #region part1
    Console.WriteLine("Enter a character: ");
    Console.Write("Enter a character: ");
    char input = Convert.ToChar(Console.ReadLine());
    int output = (int)input;
    Console.WriteLine(output);
    Console.WriteLine("ASCII code for this character is: " + output);
    #endregion

    #region part2
    Console.Write("Enter an ASCII code for a character: ");
    int input2 = Convert.ToInt32(Console.ReadLine());
    char output2 = Convert.ToChar(input2);
    Console.WriteLine("Character is: " + output2);
    #endregion

    #region part3
    Console.Write("Enter a number: ");
    int n = Convert.ToInt32(Console.ReadLine());
    if (n % 2 == 0)
    {
        Console.WriteLine("Number is Even.");
    }
    else
        Console.WriteLine("Number is Odd.");
    #endregion

    #region part4
    Console.WriteLine("Welcome to my simple Calculator! ");
    Console.Write("Enter the first number: ");
    int n1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the second number: ");
    int n2 = Convert.ToInt32(Console.ReadLine());
    int sum = n1 + n2;
    int sub = n1 - n2;
    int prod = n1 * n2;
    Console.WriteLine("Sum = " + sum);
    Console.WriteLine("Difference = " + sub);
    Console.WriteLine("Product = " + prod);
    #endregion

    #region part5
    Console.Write("Enter Student's degree: ");
    int deg = Convert.ToInt32(Console.ReadLine());
    char grade;
    if (deg >= 90 && deg <= 100)
    {
        grade = 'A';
    }
    else if (deg >= 75 && deg <= 89)
    {
        grade = 'B';
    }
    else if (deg >= 60 && deg <= 74)
    {
        grade = 'C';
    }
    else if (deg >= 50 && deg <= 59)
    {
        grade = 'D';
    }
    else
        grade = 'F';
    Console.WriteLine("Student's Grade is: " + grade);
    #endregion

    #region part6
    Console.Write("Enter  a number to view it's time table: ");
    int num = Convert.ToInt32(Console.ReadLine());
    for (int i = 0; i <= 12; i++)
    {
        Console.WriteLine(i + "*" + num + "= " + (i * num));
    }
    #endregion
}



