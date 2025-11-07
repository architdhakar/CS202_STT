using System;
Console.WriteLine("int x = 3;");
Console.WriteLine("int y = 2 + ++x;");
int x = 3;
int y = 2 + ++x;
Console.WriteLine($"x = {x} and y = {y}");
Console.WriteLine("x = 3 << 2;");
Console.WriteLine("y = 10 >> 1;");
x = 3 << 2;
y = 10 >> 1;
Console.WriteLine($"x = {x} and y = {y}");
x = ~x;
y = ~y;
Console.WriteLine($"x = {x} and y = {y}");

/*
Output is:
nt x = 3;
int y = 2 + ++x;
x = 4 and y = 6
x = 3 << 2;
y = 10 >> 1;
x = 12 and y = 5
x = -13 and y = -6


Reasoning:

int y = 2 + ++x; → This uses the pre-increment operator (++x). x is first incremented from 3 to 4. Then the addition is performed: y = 2 + 4, making y = 6. This results in x = 4 and y = 6.

x = 3 << 2; → This is the left bitwise shift. The binary representation of 3 is 0011. Shifting left by 2 positions gives 1100, which is decimal 12. So, x becomes 12.

y = 10 >> 1; → This is the right bitwise shift. The binary of 10 is 1010. Shifting right by 1 position gives 0101, which is decimal 5. So, y becomes 5. This results in x = 12 and y = 5.

x = ~x; and y = ~y; → This is the bitwise complement operator. It inverts all bits. The formula for two's complement is ~n = -(n+1).

~12 becomes -(12 + 1), which is -13.

~5 becomes -(5 + 1), which is -6.

This results in x = -13 and y = -6.
*/