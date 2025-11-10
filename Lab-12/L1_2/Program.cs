using System;
delegate void Operation();
class Program
{
    static void Main()
    {
        Operation ops = null;
        ops += Step1;
        ops += Step2;
        ops += Step3;
        try
        {
            ops();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught: " + ex.Message);
        }
        Console.WriteLine("End of Main");
    }
    static void Step1()
    {
        Console.WriteLine("Step 1");
    }
    static void Step2()
    {
        Console.WriteLine("Step 2");
        throw new InvalidOperationException("Step 2 failed!");
    }
    static void Step3()
    {
        Console.WriteLine("Step 3");
    }
}

/*
Step 1
Step 2
Caught: Step 2 failed!
End of Main
*/