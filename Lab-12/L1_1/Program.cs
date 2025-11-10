// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
using System;
class Program
{
    static string txtAge;
    static DateTime selectedDate;
    static int parsedAge;
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine(txtAge == null ? "txtAge is null" : txtAge);

            Console.WriteLine(selectedDate == default(DateTime)
            ? "selectedDate is default"
            : selectedDate.ToString());
            if (string.IsNullOrEmpty(txtAge))
            {
                Console.WriteLine("txtAge is null or empty, cannot parse");
            }
            else
            {
                parsedAge = int.Parse(txtAge);
                Console.WriteLine($"Parsed Age: {parsedAge}");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Format Exception Caught");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("ArgumentNull Exception Caught");
        }
        finally
        {
            Console.WriteLine("Finally block executed");
        }
    }
}

/*
/workspaces/CS202_STT/Lab-12/L1_1/Program.cs(3,1): error CS1529: A using clause must precede all other elements defined in the namespace except extern alias declarations [/workspaces/CS202_STT/Lab-12/L1_1/L1_1.csproj]

The build failed. Fix the build errors and run again.
*/