using System;

// Calculator class
public class Calculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        // Check for division by zero to avoid errors
        if (b == 0)
        {
            Console.WriteLine("Error: Cannot divide by zero.");
            return 0;
        }
        return a / b;
    }
}


public class CalculatorApp
{
    public static void Main(string[] args)
    {
        Calculator myCalculator = new Calculator();

        Console.WriteLine("Enter the first number:");
        
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double sum = myCalculator.Add(num1, num2);
        double difference = myCalculator.Subtract(num1, num2);
        double product = myCalculator.Multiply(num1, num2);
        double quotient = myCalculator.Divide(num1, num2);

        
        Console.WriteLine($"\n--- Results ---");
        Console.WriteLine($"Addition: {num1} + {num2} = {sum}");
        Console.WriteLine($"Subtraction: {num1} - {num2} = {difference}");
        Console.WriteLine($"Multiplication: {num1} * {num2} = {product}");
        Console.WriteLine($"Division: {num1} / {num2} = {quotient}");

        
        if (sum % 2 == 0)
        {
            Console.WriteLine($"The sum ({sum}) is an even number.");
        }
        else
        {
            Console.WriteLine($"The sum ({sum}) is an odd number.");
        }
    }
}