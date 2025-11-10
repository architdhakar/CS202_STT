using System;
delegate int Calc(int x, int y);
class Program
{
    static int Add(int a, int b) { Console.Write("A"); return a + b; }
    static int Mul(int a, int b) { Console.Write("M"); return a * b; }
    static int Sub(int a, int b) { Console.Write("S"); return a - b; }
    static void Main()
    {
        Calc c = Add;
        c += Mul;
        c += Sub;
        c -= Add;
        int res = c(2, 3);
        Console.Write(":" + res);
    }
}

/*
MS:-1
A multicast delegate c of type Calc is initialized.


c = Add; The delegate's invocation list contains Add.

c += Mul; The list now contains Add, then Mul.

c += Sub; The list now contains Add, Mul, then Sub.

c -= Add; The Add method is removed from the list. The list now contains Mul, then Sub.

int res = c(2, 3); The delegate is invoked.

Mul(2, 3) is called first. It prints "M"  and returns 6.

Sub(2, 3) is called second. It prints "S"  and returns -1.

When a multicast delegate has a return value (like int), the value of res is the return value of the last method in the invocation list. Therefore, res is set to -1.

Console.Write(":" + res); This prints ":-1"
*/