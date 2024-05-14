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
            decimal result = 1;
            foreach (var num in numbers)
            {
                result *= num;
            }
            return result;
        }

        public decimal Division(decimal num1, params decimal[] numbers)
        {
            foreach (var num in numbers)
            {
                if (num == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                num1 /= num;
            }
            return num1;
        }
    }
}
