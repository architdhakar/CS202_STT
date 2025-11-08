using System;
using System.Threading;

public class ProgramClass
{
    private int data;
    private static int count = 0;

    public ProgramClass()
    {
        Interlocked.Increment(ref count);
        Console.WriteLine($"Constructor Called | Active Objects: {count}");
    }

    ~ProgramClass()
    {
        Interlocked.Decrement(ref count);
        Console.WriteLine($"Object Destroyed | Active Objects: {count}");
    }

    public void set_data(int x) => data = x;
    public void show_data() => Console.WriteLine($"Data = {data}");
}
public class Task1
{
    private static void CreateAndUseObjects()
    {
        Console.WriteLine("--- Entering object scope ---");
        var p1 = new ProgramClass();
        var p2 = new ProgramClass();
        var p3 = new ProgramClass();

        Console.WriteLine("\n--- Setting data ---");
        p1.set_data(10);
        p2.set_data(20);
        p3.set_data(30);

        Console.WriteLine("\n--- Showing data ---");
        p1.show_data();
        p2.show_data();
        p3.show_data();

        Console.WriteLine("--- Exiting object scope ---");
    }

    public static void Run()
    {
        Console.WriteLine("--- Task 1: Constructors and Destructors ---");
        CreateAndUseObjects(); 
    }
}