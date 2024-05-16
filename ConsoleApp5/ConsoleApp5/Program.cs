using System;

class Program
{
    static void Main()
    {
        decimal[] numbers2 = new decimal[] { 1.5m, 2.3m, 5.3m, 5.6m };

        Console.WriteLine("Array elements to perform subtraction");

        foreach (decimal item in numbers2)
        {
            Console.Write(item + " , ");
        }
        Console.WriteLine();

        
        Program obj1 = new Program();
        
        decimal diff2 = obj1.Subtraction(numbers2);

        Console.WriteLine("Array Elements difference:" + diff2);
    }

    
    public decimal Subtraction(decimal[] array)
    {
        if (array.Length == 0)
            return 0;

        decimal diff = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            diff -= array[i];
        }
        return diff;
    }
}
