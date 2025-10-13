using System; //namespace
class Program //default visibility4 is ‘internal’ if not specified
{
    public static void Main(string[] args)
    {
        int a = 0; //default visibility is ‘private’ (in a class)
        Console.WriteLine(a++);
    }
}