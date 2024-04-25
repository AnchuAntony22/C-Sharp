// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//string response = Console.ReadLine();
//Console.WriteLine(response);

//int number = 25;
//Console.WriteLine(number);
//if (number == 25)
//{
//    console.writeline(number);
//}
//else
//{
//    console.writeline(number);
//}
Console.WriteLine("Basic Calculator");
Console.WriteLine("--------------------");

// Displaying menu options
Console.WriteLine("1. Addition");
Console.WriteLine("2. Subtraction");
Console.WriteLine("3. Multiplication");
Console.WriteLine("4. Division");
Console.Write("Enter your choice (1-4): ");

// Getting choice from the user
int choice = Convert.ToInt32(Console.ReadLine());

// Getting input numbers
Console.Write("Enter the first number: ");
double num1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter the second number: ");
double num2 = Convert.ToDouble(Console.ReadLine());

// Performing calculation based on choice
switch (choice)
{
    case 1:
        Console.WriteLine($"Result: {num1 + num2}");
        break;
    case 2:
        Console.WriteLine($"Result: {num1 - num2}");
        break;
    case 3:
        Console.WriteLine($"Result: {num1 * num2}");
        break;
    case 4:
        if (num2 != 0)
        {
            Console.WriteLine($"Result: {num1 / num2}");
        }
        else
        {
            Console.WriteLine("Error: Division by zero!");
        }
        break;
    default:
        Console.WriteLine("Invalid choice!");
        break;
}