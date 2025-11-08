using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Main method started ---");

        Task1.Run();

        Console.WriteLine("\nForcing Garbage Collection for Task 1...");
        GC.Collect();
        GC.WaitForPendingFinalizers(); 
        GC.Collect(); 

        Task2.Run();

        Console.WriteLine("\nAll tasks finished. Press Enter to exit.");
        Console.ReadLine();
    }
}