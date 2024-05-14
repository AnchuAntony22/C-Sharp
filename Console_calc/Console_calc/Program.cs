
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
                    decimal[] addNumbers = new decimal[addInput.Length];
                    for (int i = 0; i < addInput.Length; i++)
                    {
                        if (!decimal.TryParse(addInput[i], out addNumbers[i]))
                        {
                            Console.WriteLine("Invalid input. Please enter decimal numbers separated by space.");
                            continue;
                        }
                    }
                    Console.WriteLine($"Result: {calculator.Addition(addNumbers)}");
                    break;
                case 2:
                    Console.WriteLine("Enter numbers separated by space:");
                    string[] subInput = Console.ReadLine().Split(' ');
                    decimal[] subNumbers = new decimal[subInput.Length];
                    for (int i = 0; i < subInput.Length; i++)
                    {
                        if (!decimal.TryParse(subInput[i], out subNumbers[i]))
                        {
                            Console.WriteLine("Invalid input. Please enter decimal numbers separated by space.");
                            continue;
                        }
                    }
                    Console.WriteLine($"Result: {calculator.Subtraction(subNumbers)}");
                    break;


                case 3:
                    Console.WriteLine("Enter numbers separated by space:");
                    string[] mulInput = Console.ReadLine().Split(' ');
                    decimal[] mulNumbers = new decimal[mulInput.Length];
                    for (int i = 0; i < mulInput.Length; i++)
                    {
                        if (!decimal.TryParse(mulInput[i], out mulNumbers[i]))
                        {
                            Console.WriteLine("Invalid input. Please enter decimal numbers separated by space.");
                            continue;
                        }
                    }
                    Console.WriteLine($"Result: {calculator.Multiplication(mulNumbers)}");
                    break;

                case 4:
                    Console.WriteLine("Enter numbers separated by space:");
                    string[] divInput = Console.ReadLine().Split(' ');
                    decimal[] divNumbers = new decimal[divInput.Length];
                    for (int i = 0; i < divInput.Length; i++)
                    {
                        if (!decimal.TryParse(divInput[i], out divNumbers[i]))
                        {
                            Console.WriteLine("Invalid input. Please enter decimal numbers separated by space.");
                            continue;
                        }
                    }
                    try
                    {
                        Console.WriteLine($"Result: {calculator.Division(divNumbers[0], divNumbers.Skip(1).ToArray())}");
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Cannot divide by zero.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }

    }
}