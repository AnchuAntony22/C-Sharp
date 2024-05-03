using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 1: Change a string value into a string array
        Console.WriteLine("Change a string value into a string array");
        string text1 = "If we want to restrict this feature, we need to set a flag";
        string[] array1 = text1.Split(' ');
        Console.WriteLine("Array 1: " + string.Join(", ", array1));
        Console.WriteLine();

        // Exercise 2: Change a string value into a string array separated by commas
        Console.WriteLine("Change a string value into a string array separated by commas");
        string text2 = "If,we,want,to,restrict,this,feature,we,need,to,set,a,flag";
        string[] array2 = text2.Split(',');
        Console.WriteLine("Array 2: " + string.Join(", ", array2));
        Console.WriteLine();

        // Exercise 3: Change a string value into a string array without spaces
        Console.WriteLine("Change a string value into a string array without spaces");
        string text3 = " If , we ,want,to, restrict , this , feature,we, need ,to ,set,a, flag ";
        string[] array3 = text3.Trim().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Array 3: " + string.Join(", ", array3));
        Console.WriteLine();

        // Exercise 4: Remove the first three words from a string
        Console.WriteLine("Remove the first three words from a string");
        string text4 = "If we want to restrict this feature, we need to set a flag";
        int newText = text4.IndexOf(' ', text4.IndexOf(' ', text4.IndexOf(' ') + 1) + 1) + 1;
        string newText1 = text4.Substring(newText);
        Console.WriteLine("New Text: " + newText1);
        Console.WriteLine();

        // Exercise 5: Find the index of the first occurrence of 's'
        Console.WriteLine("Find the index of the first occurrence of 's'");
        string text5 = "If we want to restrict this feature, we need to set a flag";
        Console.WriteLine("Array 4: " + text5);
        int index = text5.IndexOf('s');
        Console.WriteLine("Index of 's': " + index);
    }
}
