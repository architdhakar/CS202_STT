using System;
class Program
{
    public static void Main(string[] args)
    {
        int a = 0;
        Console.WriteLine(a++);
    }
}

// output is 0 because of post-increment operator
/*
Reasoning: The code uses the post-increment operator (a++). 
This operator first returns the current value of the variable a for 
the Console.WriteLine function and then increments a by 1. 
So, 0 is printed to the console, and afterward, the value of a becomes 1.


*/