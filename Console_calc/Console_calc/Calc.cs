using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_calc
{
    public class Calc
    {
        public decimal Addition(decimal num1, decimal num2)
        {
            return num1 + num2;
        }

        public decimal Addition(params decimal[] numbers)
        {
            decimal sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        public decimal Subtraction(decimal num1, decimal num2)
        {
            return num1 - num2;
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

        public decimal Multiplication(decimal num1, decimal num2)
        {
            return num1 * num2;
        }

        public decimal Division(decimal num1, decimal num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return num1 / num2;
        }
    }
}
