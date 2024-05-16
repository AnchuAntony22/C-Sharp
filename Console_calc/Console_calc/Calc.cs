using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_calc
{
    public class Calc
    {
        public decimal Addition(params decimal[] numbers)
        {
            decimal sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        public decimal Subtraction(params decimal[] numbers)
        {
            decimal result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }
            return result;
        }
        public decimal Multiplication(params decimal[] numbers)
        {
            if (numbers.Length == 0)
            {
               
                throw new ArgumentException("At least one number must be provided.");
            }

            decimal result = 1; 

            foreach (decimal num in numbers)
            {
                result *= num; 
            }

            return result;
        }


        public decimal Division(params decimal[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentException("At least two numbers must be provided for division.");
            }

            decimal result = numbers[0]; 

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                result /= numbers[i]; 
            }

            return result;
        }

    }
}
