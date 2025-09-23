using System;

// extension methods must be in a static class 
// can't be nested in the program class 
public static class ExtensionMethods 
{
    #region part2
    // this: attach the method to be to each string 
    public static int countingWords(this string s)
    {
        return s.Split(' ').Length;
    }
    #endregion part2
    #region part3
    public static bool isEven (this int num)
    {
        if (num % 2 == 0)
            return true;
        else return false;
    }
    #endregion part3

    #region part4
    public static int calculateAge (this DateTime DOB)
    {
        // bug: age is not accurate 
        // this calculates what the age you will be in 2025 
        // not your age according to the year and month right now 
        int age = DateTime.Now.Year - DOB.Year;
        // adjust the calculation 
        if (DateTime.Now.Month > DOB.Month ||
            DateTime.Now.Month == DOB.Month && DateTime.Now.Day < DOB.Day)
            // if birthday didn't pass yet (month or we are in the month but the day didn't came yet)
            return age -= 1;
        else
            return age;
    }
    #endregion part4

    #region part5
    public static string ReversString(this string st)
    {
        // we must declare it as char array not string
        char [] reversed = new char[st.Length];
        int index = 0;
        for (int i= st.Length - 1; i >= 0; i--)
        {
            reversed[index] = st[i];
            index++;
        }
        return new string ( reversed);
    }
    #endregion part 5
}

internal class Program
{
    #region part1
    class Product
    {
        public string name { get; set; }
        public float price { get; set; }
    }
    static Product createProduct ()
    {
        // method that return an anonymous object of 
        // (Product) object 
        //                in name return:     in price return: 
        return new Product { name = "Laptop", price = 40000.00f };
    }
    #endregion part1

   
    static void Main (string[] args)
    {
        #region part1
        Product prod = createProduct();
        Console.WriteLine($"Product name : {prod.name}, Price: {prod.price}");

        #endregion part2
        #region part2
        string text = "Hello world";
        int count = text.countingWords();
        Console.WriteLine($"There is {count} words ");
        #endregion part2

        #region part3
        int n = 9;
        bool check = n.isEven();
        if (check)
            Console.WriteLine($"{n} is an Even number.");
        else
            Console.WriteLine($"{n} is an Odd number.");
        #endregion part3

        #region part4
        DateTime birthday = new DateTime(2003, 12, 2);
        int age = birthday.calculateAge();
        Console.WriteLine($"You are {age} years old");
        #endregion part4
        #region part5
        string txt = "Hello";
        Console.WriteLine($"Reversed Text: {txt.ReversString()}");

        #endregion part5
    }
}