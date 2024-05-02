using System;

class Program
{
    static void Main(string[] args)
    {
        // Exercise 1: Change a string value into a string array
        string text1 = "If we want to restrict this feature, we need to set a flag";
        string[] array1 = text1.Split(' ');
        Console.WriteLine("Array 1: " + string.Join(", ", array1));

        // Exercise 2: Change a string value into a string array separated by commas
        string text2 = "If,we,want,to,restrict,this,feature,we,need,to,set,a,flag";
        string[] array2 = text2.Split(',');
        Console.WriteLine("Array 2: " + string.Join(", ", array2));

        // Exercise 3: Change a string value into a string array without spaces
        string text3 = " If , we ,want,to, restrict , this , feature,we, need ,to ,set,a, flag ";
        string[] array3 = text3.Trim().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Array 3: " + string.Join(", ", array3));

        // Exercise 4: Remove the first three words from a string
        string text4 = "If we want to restrict this feature, we need to set a flag";
        string newText = text4.Substring(text4.IndexOf(' ') + 1).Substring(text4.IndexOf(' ') + 1).Substring(text4.IndexOf(' ') + 1);
        Console.WriteLine("New Text: " + newText);

        // Exercise 5: Find the index of the first occurrence of 's'
        string text5 = "If we want to restrict this feature, we need to set a flag";
        int index = text5.IndexOf('s');
        Console.WriteLine("Index of 's': " + index);
    }
}
