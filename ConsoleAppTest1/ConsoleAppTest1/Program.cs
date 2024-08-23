using System;

public class PalindromeChecker
{
    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            // Check if characters at the left and right pointers are the same
            if (s[left] != s[right])
            {
                return false;
            }
            // Move towards the center
            left++;
            right--;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string to check if it's a palindrome:");
        string input = Console.ReadLine();

        if (IsPalindrome(input))
        {
            Console.WriteLine($"\"{input}\" is a palindrome.");
        }
        else
        {
            Console.WriteLine($"\"{input}\" is not a palindrome.");
        }
    }
}
