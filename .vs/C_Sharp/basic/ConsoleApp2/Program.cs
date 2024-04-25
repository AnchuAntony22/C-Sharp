using System;

class Program
{
    static void Main()
    {
        bool exit = false;
        int choice = 0;
        bool validInput = false;
        while (!exit)
        {
            Console.WriteLine("\nBasic Calculator");
            Console.WriteLine("----------------");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();
            choice = Convert.ToInt32(input);

            if (choice >= 1 && choice <= 5)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
            }

            switch (choice)
            {
                case 1:
                    Addition();
                    break;
                case 2:
                    Subtraction();
                    break;
                case 3:
                    Multiplication();
                    break;
                case 4:
                    Division();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    void Addition()
    {
        double num1, num2;
        Console.Write("Enter the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        double result = num1 + num2;
        Console.WriteLine($"Result: {result}");
    }

    void Subtraction()
    {
        double num1, num2;
        Console.Write("Enter the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        double result = num1 - num2;
        Console.WriteLine($"Result: {result}");
    }

    void Multiplication()
    {
        double num1, num2;
        Console.Write("Enter the first number: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second number: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        double result = num1 * num2;
        Console.WriteLine($"Result: {result}");
    }

    void Division()
    {
        double num1, num2;
        Console.Write("Enter the dividend: ");
        num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the divisor: ");
        num2 = Convert.ToDouble(Console.ReadLine());

        if (num2 == 0)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
        }
        else
        {
            double result = num1 / num2;
            Console.WriteLine($"Result: {result}");
        }
    }
}


