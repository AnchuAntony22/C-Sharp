using System;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 1: Method to return an empty int array of random size between 2 and 25
        int[] randomArray = GenerateRandomIntArray();
        Console.WriteLine("Random Array Length: " + randomArray.Length);
        Console.Write("Array Vlues:");
        foreach (int num in randomArray)
        {
            Console.Write(num + " "); 
        }

        Console.WriteLine();
        // Exercise 2: Fill an int array of size 8 with random numbers between 0 and 5
        int[] filledArray = new int[8];
        Random rand = new Random();
        int i = 0;
        foreach (int num in filledArray)
        {
            filledArray[i] = rand.Next(0, 6);
            i++;
        }

        //for (int i = 0; i < filledArray.Length; i++)
        //{
        //    filledArray[i] = rand.Next(0, 6); 
        //}
        Console.WriteLine("Filled Array: " + string.Join(", ", filledArray));

        // Exercise 3: Replace a random element of a string array with "_"
        string[] stringArray = { "overwrite", "depending", "incorrect", "endpoint", "using", "document" };
        int randomIndex = rand.Next(0, stringArray.Length); 
        stringArray[randomIndex] = "_";
        Console.WriteLine("Modified String Array: " + string.Join(", ", stringArray));
    }

    static int[] GenerateRandomIntArray()
    {
        Random rand = new Random();
        int size = rand.Next(2, 26); 
        return new int[size];
    }
}
