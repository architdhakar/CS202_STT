using System;
using System.Collections; 
class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Running Snippet 1 (Level 0 - a, b, c, d) ---");
        RunLevel01();
        
        Console.WriteLine("\n\n--- Running Snippet 2 (Level 0 - age, k, split) ---");
        RunLevel02();

        Console.WriteLine("\n\n--- Running Snippet 3 (Level 0 - nums array) ---");
        RunLevel03();

        Console.WriteLine("\n\n--- Running Snippet 4 (Level 1 - age, k, split) ---");
        RunLevel11();

        Console.WriteLine("\n\n--- Running Snippet 5 (Level 1 - f, loops) ---");
        RunLevel12();

        Console.WriteLine("\n\n--- Running Snippet 6 (Level 1 - A, B, delegate) ---");
        RunLevel13();

        Console.WriteLine("\n\n--- Running Snippet 7 (Level 2 - Institute, IITGN) ---");
        RunLevel21();
        
        Console.WriteLine("\n\n--- Running Snippet 8 (Level 2 - mydel delegate) ---");
        RunLevel22();

        Console.WriteLine("\n\n--- Running Snippet 9 (Level 2 - ArrayList) ---");
        RunLevel23();

        Console.WriteLine("\n\nAll snippets finished. Press Enter to exit.");
        Console.ReadLine();
    }

    public static void RunLevel01()
    {
        int a = 3;
        int b = a++;
        Console.WriteLine($"a is {+a++}, b is {-++b}");
        int c = 3;
        int d = ++c;
        Console.WriteLine($"c is {-c--}, d is {~d}");
    }
    public static void RunLevel02()
    {
        Level02Program.Run();
    }
    public static void RunLevel03()
    {
        Level03Program.Run();
    }

    public static void RunLevel11()
    {
        Console.WriteLine("(This is a duplicate of Snippet 2)");
        Level11Program.Run();
    }
    public static void RunLevel12()
    {
        Level12Program.Run(null); 
    }
    public static void RunLevel13()
    {
        Level13Program.Run(null); 
    }

    public static void RunLevel21()
    {
        Level21Program.Run(null); 
    }
    public static void RunLevel22()
    {
        Level22Program.Run(null); 
    }
    public static void RunLevel23()
    {
        Level23Program.Run(null); 
    }
}

class Level02Program
{
    int age;
    Level02Program() => age = age == 0 ? age + 1 : age - 1;
    public static void Run() 
    {
        int k = "010%".Replace('0', '%').Length;
        Console.Write("[" + (k << ++new Level02Program().age).ToString() + "]");
        Console.Write("[" + "010%".Split('1')[1][0] + "]");
        Console.Write("[" + "010%".Split('0')[1][0] + "]");
        Console.Write("[" + int.Parse(Convert.ToString("123".ToCharArray()[~-1])) + "]");
    }
}

class Level03Program
{
    public static void Run()
    {
        int[] nums = { 0, 1, 0, 3, 12 };
        int pos = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                int temp = nums[pos];
                nums[pos] = nums[i];
                nums[i] = temp;
                pos++;
            }
        }
        Console.WriteLine(string.Join(", ", nums));
    }
}

class Level11Program
{
    int age;
    Level11Program() => age = age == 0 ? age + 1 : age - 1;
    public static void Run() 
    {
        int k = "010%".Replace('0', '%').Length;
        Console.Write("[" + (k << ++new Level11Program().age).ToString() + "]");
        Console.Write("[" + "010%".Split('1')[1][0] + "]");
        Console.Write("[" + "010%".Split('0')[1][0] + "]");
        Console.Write("[" + int.Parse(Convert.ToString("123".ToCharArray()[~-1])) + "]");
    }
}

class Level12Program
{
    int f;
    public static void Run(string[] args) 
    {
        Console.WriteLine("run 1");
        Level12Program p = new Level12Program(new int() + "0".Length);
        for (int i = 0, _ = i; i < 5 && ++p.f >= 0; i++, Console.WriteLine(p.f++)) ;
        {
            for (; p.f == 0;) ;
            {
                Console.WriteLine(p.f);
            }
        }
        Console.WriteLine("\nrun 2");
        p = new Level12Program(p.f);
        Console.WriteLine(p.f);
        Console.WriteLine("\nrun 3");
        p = new Level12Program();
        Console.WriteLine(p.f);
    }
    Level12Program() => f = 0;
    Level12Program(int x) => f = x;
}

public class A
{
    public virtual void f1()
    {
        Console.WriteLine("f1");
    }
}
public class B : A
{
    public override void f1() => Console.WriteLine("f2");
}
class Level13Program
{
    static int i = 0;
    public event funcPtr handler;
    public delegate void funcPtr();
    public void destroy()
    {
        if (i == 6)
            return;
        else
        {
            Console.WriteLine(i++);
            destroy();
        }
    }
    public static void Run(string[] args) 
    {
        Level13Program p = new Level13Program();
        p.handler += new funcPtr((new A()).f1);
        p.handler += new funcPtr((new B()).f1);
        p.handler(); 
        
        p.handler -= new funcPtr((new B()).f1); 
        p.handler -= new funcPtr((new A()).f1); 
        p?.destroy(); 
        
        p = null;
        i = -6;
        p?.destroy(); 
        (new Level13Program())?.destroy();
    }
}

public class Institute
{
    internal int i = 7;
    public Institute()
    {
        Console.Write("1");
    }
    public virtual void info()
    {
        Console.Write("2");
    }
}
public class IITGN : Institute
{
    public int i = 8;
    public IITGN()
    {
        Console.Write("3");
    }
    public IITGN(int i)
    {
        Console.Write("4");
    }
    public override void info()
    {
        Console.Write("5");
    }
}
class Level21Program
{
    public static void Run(string[] args) 
    {
        Console.Write("6");
        Institute ins1 = new Institute();
        ins1.info();
        IITGN ab101 = new IITGN(3);
        ab101 = new IITGN();
        ab101.info();
        Console.WriteLine();
        Console.WriteLine(ab101.i);
        Console.WriteLine(~(((Institute)ab101).i));
    }
}

public class Level22Program
{
    public delegate void mydel();
    public void fun1()
    {
        Console.WriteLine("fun1()");
    }
    public void fun2()
    {
        Console.WriteLine("fun2()");
    }
    public static void Run(string[] args) 
    {
        Level22Program p = new Level22Program();
        mydel obj1 = new mydel(p.fun1); 
        obj1 += new mydel(p.fun2);
        Console.WriteLine("run 1");
        obj1();
        
        mydel obj2 = new mydel(p.fun2);
        obj2 += new mydel(p.fun1);
        Console.WriteLine("run 2");
        obj2();
        
        obj2 -= p.fun2; 
        Console.WriteLine("run 3");
        obj2();
    }
}

public class Level23Program
{
    int x;
    public static void Run(string[] args) 
    {
        ArrayList L = new ArrayList();
        L.Add(new Level23Program());
        L.Add(new Level23Program());
        for (int i = 0; i < L.Count; i++)
            Console.WriteLine(++((Level23Program)L[i]).x);
        
        L[0] = L[1];
        ((Level23Program)L[0]).x = 202;
        for (int i = 0; i < L.Count; i++)
            Console.WriteLine(((Level23Program)L[i]).x);
        
        ((Level23Program)L[0]).x = 111;
        L.RemoveAt(0);
        Console.WriteLine(L.Count);
        Console.WriteLine(((Level23Program)L[0]).x);
    }
}