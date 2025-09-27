using System;
using System.Collections;
using System.Runtime.Intrinsics.X86;
internal class Program
{
    // part 1: optimize bubble sort 
    // bubble sort still loops for the whole array till the end 
    // even if the array is sorted 
    // so we can optimize it by stop the swapping when the array is already sorted 
    public static void bubbleSort (int[] arr)
    {
        int n = arr.Length;
        bool flag;

        for (int i=0;i <n-1;i++)
        {
            flag = false;
            for (int j=0; j<n-1;j++)
            {
                if (arr[j] > arr[j+1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j+1];
                    arr[j+1] = temp;
                    flag = true;
                }
            }
            if (!flag)
            {
                break;
             
            }
        }
    }
    // part2
    public class Range<T> where T : IComparable<T>
    {
        public T min { get; set; }
        public T max { get; set; }

        // set values using the constructor: 
        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }

        // method to check range: 
        public bool IsInRange(T num)
        {
            // compareTo : return -1 if less than min (not acceptable)
            //                    0 if == 
            //                    1 if greater than 
            return num.CompareTo(min) >= 0 && num.CompareTo(max) <= 0;
            // same with max except that we accept 0 and -1 only 
            // 1 means taht the value is greater than max so we use <=0
        }
        public dynamic length()
        {
            // we must use dynamic to check if the subtraction is acceptable or not 

            // we cannot use var here as the compiler still doesn't know what is 
            // the data tpye
            return (dynamic)max - (dynamic)min;
        }

    }
    // part3 
    public static void ReverseArr(ArrayList arr)
    {
        int start = 0;
        int end = arr.Count - 1;
        while (start < end)
        {
            var temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            start++; end--;
        }
    }

    //part4
    public static void extractEvens(List<int> numbers)
    {

        foreach (var i in numbers)
        {
            if (i % 2 == 0)
            {
                Console.Write(i + " ");
            }
        }

    }

    // part5
    public class FixedSizeList<T>
    {
        private T[] elements;
        private int count;

        // consrtuctor to take the capacity 
        public FixedSizeList(int capacity)
        {

            elements = new T[capacity]; // we make the array with the fixed capacity
            count = 0;
        }
        // method to add numbers to the array 
        public void Add(T num)
        {
            {
                if (count >= elements.Length)
                {
                    throw new InvalidOperationException("List is Full");
                }
                else
                    elements[count] = num;
                count++;
            }
        }
        // check if an index is valid  print it or if it's not valid throw exception 
        public T Get (int index)

        {
            if (index<0 || index >= elements.Length)
            {
                throw new InvalidOperationException("Invalid index!");
            }
            else 
                return elements[index]; 
        }
    }

    // part6
    public static int notRepeated (string str)
    {
        Dictionary <char, int> count = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (count.ContainsKey(c))
                count[c]++;
            else count[c] = 1;
        }
        // we need to spot the first unrepeated character 
        for (int i=0;i<str.Length;i++)
        {
            if (count[str[i]] == 1)
                return i;
            else 
                return -1;
        }
        return 0;
    }
    static void Main(string[] args)
    {

        // part1 
        int[] arr = { 5, 1, 2, 4, 3 };
        bubbleSort(arr);
        foreach (int i in arr)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine("/////////////////////");

        // part2
        //var range = new Range<int>(10, 20);
        //Console.WriteLine(range.IsInRange(15));
        //Console.WriteLine(range.IsInRange(21));
        //Console.WriteLine("Length is: " + range.length());


        // part3
        ArrayList array = new ArrayList() { 1, 2, 3, 4, 5 };
        ReverseArr(array);
        foreach (var i in array)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        //part4
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        extractEvens(numbers);

        // part 5
        var list = new FixedSizeList<int>(5);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);
        list.Add(7);

        Console.WriteLine();
        Console.WriteLine(list.Get(0));
        Console.WriteLine(list.Get(1));
        Console.WriteLine(list.Get(2));

        // list.Add(7); // Exception
        // Console.WriteLine(list.Get(7)); // exception

        string s1 = "Boshra";
        string s2 = "aabbcc";

        Console.WriteLine(notRepeated(s1));
        Console.WriteLine(notRepeated(s2));


    }

}
