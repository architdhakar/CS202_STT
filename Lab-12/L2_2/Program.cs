using System;
class StepEventArgs : EventArgs
{
    public int Step { get; }
    public StepEventArgs(int s) => Step = s;
}
class Workflow
{
    public event EventHandler<StepEventArgs> StepStarted;
    public event EventHandler<StepEventArgs> StepCompleted;
    public void Run()
    {
        for (int i = 1; i <= 3; i++)
        {
            StepStarted?.Invoke(this, new StepEventArgs(i));
            Console.Write($"[{i}]");
            StepCompleted?.Invoke(this, new StepEventArgs(i));
        }
    }
}
class Program
{
    static void Main()
    {
        Workflow wf = new Workflow();
        wf.StepStarted += (s, e) =>
        {
            Console.Write("<S" + e.Step + ">");
            if (e.Step == 2)
            ((Workflow)s).StepCompleted += (snd, ev)
            => Console.Write("(Dyn" + ev.Step + ")");
        };
        wf.StepCompleted += (s, e) => Console.Write("<C" + e.Step + ">");
        wf.Run();
    }
}

/*
<S1>[1]<C1><S2>[2]<C2>(Dyn2)<S3>[3]<C3>(Dyn3)
*/