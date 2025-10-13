using System;
public class Program
{
    static void Main(string[] args)
    {
        Main(["CS202"]);
    }
}

/*
Output is : 
The program will crash and print a System.StackOverflowException.
There is no condition to stop the recursion. The Main method will call itself again and again, indefinitely.
*/