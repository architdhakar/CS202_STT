using System;
class LimitEventArgs : EventArgs
{
    public int CurrentValue { get; }
    public LimitEventArgs(int val) => CurrentValue = val;
}
class Counter
{
    public event EventHandler<LimitEventArgs> LimitReached;
    public event EventHandler<LimitEventArgs> MilestoneReached;
    private int value = 0;
    public void Increment()
    {
        value++;
        Console.Write(">" + value);
        // Fire Milestone event every 2nd increment
        if (value % 2 == 0)
        MilestoneReached?.Invoke(this, new LimitEventArgs(value));
        // Fire Limit event every 3rd increment
        if (value % 3 == 0)
        LimitReached?.Invoke(this, new LimitEventArgs(value));
    }
}
class Program
{
    static void Main()
    {
        Counter c = new Counter();
        // Subscribers for LimitReached
        c.LimitReached += (s, e) => Console.Write("[L" + e.CurrentValue + "]");
        c.LimitReached += (s, e) => Console.Write("(Reset)");
        // Subscribers for MilestoneReached
        c.MilestoneReached += (s, e) =>
        {
            Console.Write("[M" + e.CurrentValue + "]");
            if (e.CurrentValue == 4)
            Console.Write("{Alert}");
        };
        for (int i = 0; i < 6; i++)
        c.Increment();
    }
}

/*
>1>2[M2]>3[L3](Reset)>4[M4]{Alert}>5>6[M6][L6](Reset)

Reasoning: The code iterates a loop 6 times (from i=0 to i=5), calling c.Increment() each time.

Loop 1 (i=0): value becomes 1. Prints ">1". No events fire.

Loop 2 (i=1): value becomes 2. Prints ">2". value % 2 == 0 is true. MilestoneReached event fires. Its subscriber prints "[M2]".



Loop 3 (i=2): value becomes 3. Prints ">3". value % 3 == 0 is true. LimitReached event fires. Its two subscribers run in order, printing "[L3]" and "(Reset)".




Loop 4 (i=3): value becomes 4. Prints ">4". value % 2 == 0 is true. MilestoneReached event fires. Its subscriber prints "[M4]". The if (e.CurrentValue == 4) condition is true , so it also prints "{Alert}".





Loop 5 (i=4): value becomes 5. Prints ">5". No events fire.

Loop 6 (i=5): value becomes 6. Prints ">6".

value % 2 == 0 is true. MilestoneReached event fires, printing "[M6]".


value % 3 == 0 is true. LimitReached event fires, printing "[L6]" and "(Reset)"
*/