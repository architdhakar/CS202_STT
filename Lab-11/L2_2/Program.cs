using System;
class AlertEventArgs : EventArgs
{
    public string Info { get; }
    public AlertEventArgs(string info) => Info = info;
}
class Sensor
{
    public event EventHandler<AlertEventArgs> ThresholdReached;
    public void Check(int value)
    {
        Console.Write("[Check]");
        if (value > 50)
        ThresholdReached?.Invoke(this, new AlertEventArgs("High"));
        Console.Write("[Done]");
    }
}
class Program
{
    static void Main()
    {
        Sensor s = new Sensor();
        s.ThresholdReached += (sender, e) =>
        {
        Console.Write("{" + e.Info + "}");
        if (e.Info == "High")
        ((Sensor)sender).Check(30);
        };
        s.ThresholdReached += (sender, e) =>
        Console.Write("(Alert)");
        s.Check(80);
    }
}

/*
[Check]{High}[Check][Done](Alert)[Done]

This is another recursive call, but with a condition on the event firing.

s.Check(80); is called.

Check(80) prints "[Check]".

value > 50 (80 > 50) is true.

ThresholdReached event is invoked with "High".

Subscriber 1 runs, printing "{High}".

The if condition e.Info == "High" is true.

((Sensor)sender).Check(30); is called recursively.

Check(30) prints "[Check]".

value > 50 (30 > 50) is false. The if block is skipped. The event is not fired.

The Check(30) method finishes.

Execution returns to the ThresholdReached invocation.

Subscriber 2 runs, printing "(Alert)".

The event invocation is complete.

The original Check(80) method resumes and prints "[Done]".
*/