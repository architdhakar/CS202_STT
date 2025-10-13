using System;
using System.Collections.Generic; // Required for List<T>

public class LoopsAndFunctionsApp
{
    // A static function to calculate factorial.
    // It's static so we can call it without creating an object of the class.
    public static long CalculateFactorial(int number)
    {
        if (number < 0) return -1; // Factorial is not defined for negative numbers
        if (number == 0) return 1;

        long result = 1;
        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }
        return result;
    }

    public static void Main(string[] args)
    {
        // 1. Using a 'for' loop
        Console.WriteLine("--- Using a 'for' loop to print 1 to 10 ---");
        for (int i = 1; i <= 10; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // 2. Using a 'foreach' loop
        Console.WriteLine("--- Using a 'foreach' loop to print 1 to 10 ---");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine("\n");

        // 3. Using a 'do-while' loop
        Console.WriteLine("--- Using a 'do-while' loop ---");
        string userInput;
        do
        {
            Console.WriteLine("Enter any text to continue, or type 'exit' to quit:");
            userInput = Console.ReadLine();
            Console.WriteLine($"You entered: {userInput}");
        } while (userInput.ToLower() != "exit");
        Console.WriteLine();

        // 4. Calling the factorial function
        Console.WriteLine("--- Calculating a Factorial ---");
        Console.Write("Enter a non-negative number: ");
        int factorialInput = Convert.ToInt32(Console.ReadLine());
        long factorialResult = CalculateFactorial(factorialInput);
        
        if(factorialResult == -1)
        {
            Console.WriteLine("Cannot calculate factorial for a negative number.");
        }
        else
        {
            Console.WriteLine($"The factorial of {factorialInput} is {factorialResult}.");
        }
    }
}