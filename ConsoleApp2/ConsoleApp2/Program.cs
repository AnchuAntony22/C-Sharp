using System;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 1: Method to return an empty int array of random size between 2 and 25
        int[] randomArray = GenerateRandomIntArray();
        Console.WriteLine("Random Array Length: " + randomArray.Length);

        // Exercise 2: Fill an int array of size 8 with random numbers between 0 and 5
        int[] filledArray = new int[8];
        Random rand = new Random();
        for (int i = 0; i < filledArray.Length; i++)
        {
            filledArray[i] = rand.Next(0, 6); // Generates a random number between 0 and 5
        }
        Console.WriteLine("Filled Array: " + string.Join(", ", filledArray));

        // Exercise 3: Replace a random element of a string array with "_"
        string[] stringArray = { "overwrite", "depending", "incorrect", "endpoint", "using", "document" };
        int randomIndex = rand.Next(0, stringArray.Length); // Generates a random index
        stringArray[randomIndex] = "_";
        Console.WriteLine("Modified String Array: " + string.Join(", ", stringArray));
    }

    static int[] GenerateRandomIntArray()
    {
        Random rand = new Random();
        int size = rand.Next(2, 26); // Generates a random size between 2 and 25
        return new int[size];
    }
}
