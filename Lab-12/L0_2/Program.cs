using System;
delegate void Notify(string msg);
class Program
{
    static void Main()
    {
        Notify handler = null;
        handler += (m) => Console.WriteLine("A: " + m);
        handler += (m) => Console.WriteLine("B: " + m.ToUpper());
        handler("hello");
        handler -= (m) => Console.WriteLine("A: " + m);
        handler("world");
    }
}

/*
A: hello
B: HELLO
A: world
B: WORLD
*/