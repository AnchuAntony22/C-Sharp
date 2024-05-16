
using Console_calc;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Calculator Program!");

        
        Calc calculator = new Calc();

        while (true)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");

            string choiceStr = Console.ReadLine();
            int choice;
            if (!int.TryParse(choiceStr, out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                continue;
            }

            switch (choice)
            {
                case 1:

                    Console.WriteLine("Enter numbers separated by space:");
                    string[] addInput = Console.ReadLine().Split(' ');
                    List<decimal> addNumbers = new List<decimal>();

                    foreach (string input in addInput)
                    {
                        try
                        {
                            
                            decimal number = decimal.Parse(input);
                            addNumbers.Add(number);
                        }
                        catch (FormatException)
                        {
                          
                            Console.WriteLine("Invalid input. Please enter decimal numbers separated by space.");
                          
                        }
                    }

                    if (addNumbers.Count > 0)
                    {
                        
                        Console.WriteLine($"Result: {calculator.Addition(addNumbers.ToArray())}");
                    }
                    else
                    {
                        Console.WriteLine("No valid numbers provided for addition.");
                    }

                    break;
                case 2:

                    Console.WriteLine("Enter numbers separated by space:");
                    string[] subInput = Console.ReadLine().Split(' ');
                    List<decimal> subNumbers = new List<decimal>();

                    foreach (string input in subInput)
                    {
                        try
                        {
                            decimal number = decimal.Parse(input);
                            subNumbers.Add(number);
                        }
                        catch (FormatException)
                        {
                           
                            Console.WriteLine("Invalid input. Please enter decimal numbers separated by space.");
                           
                        }
                    }

                    if (subNumbers.Count < 2)
                    {
                        Console.WriteLine("Insufficient numbers provided for subtraction.");
                    }
                    else
                    {
                       Console.WriteLine($"Result: {calculator.Subtraction(subNumbers.ToArray())}");
                    }
                    break;
                case 3:

                    Console.WriteLine("Enter numbers separated by space:");
                    string[] mulInput = Console.ReadLine().Split(' ');

                    decimal[] mulNumbers = new decimal[mulInput.Length];
                    try
                    {
                        for (int i = 0; i < mulInput.Length; i++)
                        {
                            mulNumbers[i] = decimal.Parse(mulInput[i]);
                        }

                        Console.WriteLine($"Result: {calculator.Multiplication(mulNumbers)}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter valid decimal numbers separated by space.");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;

                case 4:

                    Console.WriteLine("Enter numbers separated by space:");
                    string[] divInput = Console.ReadLine().Split(' ');

                    decimal[] divNumbers = new decimal[divInput.Length];
                    try
                    {
                        for (int i = 0; i < divInput.Length; i++)
                        {
                            divNumbers[i] = decimal.Parse(divInput[i]);
                        }

                        if (divNumbers.Length < 2)
                        {
                            Console.WriteLine("Invalid input. Please enter at least two decimal numbers separated by space.");
                            return; 
                        }

                        Console.WriteLine($"Result: {calculator.Division(divNumbers)}");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter valid decimal numbers separated by space.");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;

                case 5:

                    Console.WriteLine("Exiting the program");
                    return;
                default:

                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }

    }
}