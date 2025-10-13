using System;
public class Program
{
    static void Main()
    {
        try
        {
            int i=int.MaxValue;
            Console.WriteLine(-(i+1)-i);
            for(i=0; i<=int.MaxValue;i++); //note semicolon here
            Console.WriteLine("Program ended!");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

/*
Output is:
1
infinite loop because of overflow in for loop
int.MaxValue + 1 overflows and wraps around to int.MinValue.

The expression becomes -(int.MinValue) - int.MaxValue.

Let M = int.MaxValue. In two's complement, int.MinValue = -M - 1.

Substituting this gives: -(-M - 1) - M which simplifies to (M + 1) - M, which equals 1. So, 1 is printed.
In the next iteration, i++ is executed. As seen before, int.MaxValue + 1 overflows and wraps around to int.MinValue.

The condition is now checked for i = int.MinValue. Since int.MinValue is less than int.MaxValue, the condition is true, and the loop continues.

This creates an infinite loop. The program will never exit this loop to print "Program ended!". It will consume CPU but will not crash immediately.
*/