using System;
class Program
{
    public void Main(string[] args)
    {
        int a = 0;
        Console.WriteLine(a++);
    }
}

// output is : CSC : error CS5001: Program does not contain a static 'Main' 
//method suitable for an entry point [/workspaces/CS202_STT/lab-9/c2_0/c2_0.csproj]
//The build failed. Fix the build errors and run again.
/*
Reasoning: The .NET runtime looks for a specific method signature to start a program: a static method named Main. 
In this code, the Main method is an instance method (it is not declared as static).
The compiler will fail because it cannot find the required static entry point, resulting in an error similar to: 
Program does not contain a static 'Main' method suitable for an entry point.
*/