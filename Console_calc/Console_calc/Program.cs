
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

                    Console.WriteLine("Enter two numbers separated by space:");
                    string[] mulInput = Console.ReadLine().Split(' ');
                    decimal mulNum1, mulNum2;
                    if (mulInput.Length != 2)
                    {
                        Console.WriteLine("Invalid input. Please enter two decimal numbers separated by space.");
                        continue;
                    }

                    try
                    {
                        mulNum1 = decimal.Parse(mulInput[0]);
                        mulNum2 = decimal.Parse(mulInput[1]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter two valid decimal numbers separated by space.");
                        continue;
                    }

                    Console.WriteLine($"Result: {calculator.Multiplication(mulNum1, mulNum2)}");
                    break;

                case 4:

                    Console.WriteLine("Enter two numbers separated by space:");
                    string[] divInput = Console.ReadLine().Split(' ');
                    decimal divNum1, divNum2;

                    if (divInput.Length != 2)
                    {
                        Console.WriteLine("Invalid input. Please enter two decimal numbers separated by space.");
                        continue;
                    }

                    try
                    {
                        divNum1 = decimal.Parse(divInput[0]);
                        divNum2 = decimal.Parse(divInput[1]);

                        if (divNum2 == 0)
                        {
                            Console.WriteLine("Invalid input. Cannot divide by zero.");
                            continue;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter two valid decimal numbers separated by space.");
                        continue;
                    }

                    Console.WriteLine($"Result: {calculator.Division(divNum1, divNum2)}");
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