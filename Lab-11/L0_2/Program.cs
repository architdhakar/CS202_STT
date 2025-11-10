using System;
delegate void ActionHandler(ref int x);
class Program
{
    static void Inc(ref int a) { a += 2; Console.Write("I" + a + " "); }
    static void Dec(ref int a) { a--; Console.Write("D" + a + " "); }
    static void Main()
    {
        int val = 3;
        ActionHandler act = Inc;
        act += Dec;
        act(ref val);
        Console.Write("F" + val);
    }
}

/*
I5 D4 F4
int val = 3; A variable val is initialized to 3.

ActionHandler act = Inc; The delegate act points to the Inc method.

act += Dec; The Dec method is added. The invocation list is Inc, then Dec.

act(ref val); The delegate is invoked, passing val by reference.


Inc(ref val) is called. val (which is 3) is incremented by 2, becoming 5. The code prints "I" + 5 + " ", resulting in "I5 ".

Dec(ref val) is called. Because val was passed by reference, this method receives the modified value of 5. val is decremented by 1, becoming 4. The code prints "D" + 4 + " ", resulting in "D4 ".

Console.Write("F" + val); The val variable in Main has been modified by the delegate calls (since it was passed by reference) and is now 4. This prints "F4"
*/
