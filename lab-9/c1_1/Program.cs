class Program
{
    public static void Main(string[] args)
    {
        int a = 0;
        int b = a++;
        Console.WriteLine(a++.ToString(),++a,-a++);
        Console.WriteLine((a++).ToString() + (-a++).ToString());
        Console.WriteLine(~b);
    }
}

// output is : 1 4-5 -1
/*
Reasoning:

int a = 0; → a is 0.

int b = a++; → The post-increment assigns the current value of a (0) to b, then increments a. After this line, b is 0 and a is 1.

Console.WriteLine(a++.ToString(),++a,-a++); → The arguments are evaluated from left to right before the method is called.

First argument: a++ is evaluated. The current value of a (1) is used, then a is incremented. So, 1.ToString() is passed. Now a is 2.

Second argument: ++a is evaluated. a is incremented first, then the new value is used. So, a becomes 3, and 3 is passed. Now a is 3.

Third argument: -a++ is evaluated. The current value of a (3) is negated to -3 and passed. Then a is incremented. Now a is 4.

Console.WriteLine is called with the format string "1" and two extra arguments (3 and -3). Since the format string "1" has no placeholders like {0}, the extra arguments are ignored. The output is 1.

Console.WriteLine((a++).ToString() + (-a++).ToString()); → a is currently 4.

(a++) uses the current value 4 and then increments a to 5. This part evaluates to the string "4".

(-a++) uses the current value 5, negates it to -5, and then increments a to 6. This part evaluates to the string "-5".

The two strings are concatenated. The output is 4-5.

Console.WriteLine(~b); → b is 0. The bitwise complement operator (~) flips all bits. In two's complement representation, flipping all bits of 0 (000...000) results in 111...111, which represents -1.
*/