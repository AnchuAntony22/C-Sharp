using System;
using System.IO;
using System.Text;

class Hangman
{
    static string[] words = { "apple", "banana", "orange", "grape", "pear" };
    static Random rand = new Random();
    static string secretWord = words[rand.Next(words.Length)];
    static char[] guessedWord = new char[secretWord.Length];
    static StringBuilder incorrectGuesses = new StringBuilder();
    static int remainingGuesses = 10;

    static void Main(string[] args)
    {
        InitializeGuessedWord();
        Console.WriteLine("Welcome to Hangman!");

        while (remainingGuesses > 0 && !IsWordGuessed())
        {
            DisplayGameStatus();
            Console.WriteLine($"Remaining guesses: {remainingGuesses}");
            Console.WriteLine("Enter a letter or guess the whole word:");
            string input = Console.ReadLine().ToLower();

            if (input.Length == 1)
            {
                GuessLetter(input[0]);
            }
            else if (input.Length == secretWord.Length)
            {
                GuessWord(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a single letter or guess the whole word.");
            }
        }

        if (IsWordGuessed())
        {
            Console.WriteLine($"Congratulations! You guessed the word: {secretWord}");
        }
        else
        {
            Console.WriteLine($"Sorry, you ran out of guesses. The word was: {secretWord}");
        }
    }

    static void InitializeGuessedWord()
    {
        for (int i = 0; i < secretWord.Length; i++)
        {
            guessedWord[i] = '_';
        }
    }

    static void DisplayGameStatus()
    {
        Console.WriteLine("Word: " + string.Join(" ", guessedWord));
        Console.WriteLine("Incorrect guesses: " + incorrectGuesses);
    }

    static void GuessLetter(char letter)
    {
        bool letterFound = false;
        for (int i = 0; i < secretWord.Length; i++)
        {
            if (secretWord[i] == letter)
            {
                guessedWord[i] = letter;
                letterFound = true;
            }
        }

        if (!letterFound)
        {
            if (!incorrectGuesses.ToString().Contains(letter))
            {
                incorrectGuesses.Append(letter + " ");
                remainingGuesses--;
            }
        }
    }

    static void GuessWord(string word)
    {
        if (word == secretWord)
        {
            for (int i = 0; i < secretWord.Length; i++)
            {
                guessedWord[i] = secretWord[i];
            }
        }
        else
        {
            remainingGuesses--;
        }
    }

    static bool IsWordGuessed()
    {
        return !Array.Exists(guessedWord, element => element == '_');
    }
}
