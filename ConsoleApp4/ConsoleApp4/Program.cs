using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class HangmanGame
{
    private string[] words; 
    private string secretWord; 
    private char[] guessedLetters; 
    private StringBuilder incorrectGuesses; 
    private int remainingGuesses = 10; 
    private int incorrectAttempts = 0; 

    public HangmanGame()
    {
        
        words = File.ReadAllLines(@"F:\netcourse\C_Sharp\ConsoleApp4\ConsoleApp4\words.txt");

        
        Random random = new Random();
        secretWord = words[random.Next(0, words.Length)].ToLower();
        guessedLetters = new char[secretWord.Length];
       
        Array.Fill(guessedLetters, '_');
        incorrectGuesses = new StringBuilder();
    }

    public void PrintHangman()
    {
        switch (incorrectAttempts)
        {
            case 0:
                Console.WriteLine("__________");
                Console.WriteLine("|        |");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|_________");
                break;
            case 1:
                Console.WriteLine("__________");
                Console.WriteLine("|        |");
                Console.WriteLine("|        O");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|_________");
                break;
            case 2:
                Console.WriteLine("__________");
                Console.WriteLine("|        |");
                Console.WriteLine("|        O");
                Console.WriteLine("|        |");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|_________");
                break;
            case 3:
                Console.WriteLine("__________");
                Console.WriteLine("|        |");
                Console.WriteLine("|        O");
                Console.WriteLine("|       /|");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|_________");
                break;
            case 4:
                Console.WriteLine("__________");
                Console.WriteLine("|        |");
                Console.WriteLine("|        O");
                Console.WriteLine("|       /|\\");
                Console.WriteLine("|");
                Console.WriteLine("|");
                Console.WriteLine("|_________");
                break;
            case 5:
                Console.WriteLine("__________");
                Console.WriteLine("|        |");
                Console.WriteLine("|        O");
                Console.WriteLine("|       /|\\");
                Console.WriteLine("|       /");
                Console.WriteLine("|");
                Console.WriteLine("|_________");
                break;
            case 6:
                Console.WriteLine("__________");
                Console.WriteLine("|        |");
                Console.WriteLine("|        O");
                Console.WriteLine("|       /|\\");
                Console.WriteLine("|       / \\");
                Console.WriteLine("|");
                Console.WriteLine("|_________");
                break;
        }
    }

    public void Play()
    {
        Console.WriteLine("Welcome to Hangman!");
        Console.WriteLine("Guess the word:");

        while (remainingGuesses > 0)
        {
            Console.WriteLine("Word: " + string.Join(" ", guessedLetters));
            Console.WriteLine("Incorrect guesses: " + incorrectGuesses);
            Console.WriteLine($"Guesses remaining: {remainingGuesses}");

            PrintHangman(); 

            string guess = Console.ReadLine().ToLower();

            if (guess.Length == 1) 
            {
                if (secretWord.Contains(guess))
                {
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == guess[0])
                        {
                            guessedLetters[i] = guess[0];
                        }
                    }
                }
                else
                {
                    if (!incorrectGuesses.ToString().Contains(guess))
                    {
                        incorrectGuesses.Append(guess + " ");
                        remainingGuesses--;
                        incorrectAttempts++;
                    }
                }
            }
            else 
            {
                if (guess == secretWord)
                {
                    Console.WriteLine($"Congratulations! You've guessed the word: {secretWord}");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect guess!");
                    remainingGuesses--;
                }
            }

            if (string.Join("", guessedLetters) == secretWord)
            {
                Console.WriteLine($"Congratulations! You've guessed the word: {secretWord}");
                return;
            }
        }

        Console.WriteLine("Sorry, you've run out of guesses. The word was: " + secretWord);
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            HangmanGame game = new HangmanGame();
            game.Play();

            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgainInput = Console.ReadLine().ToLower();

            if (playAgainInput != "yes")
            {
                playAgain = false;
            }
        }

        Console.WriteLine("Thanks for playing Hangman!");
    }
}


