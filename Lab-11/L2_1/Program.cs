using System;
class NotifyEventArgs : EventArgs
{
    public string Message { get; }
    public NotifyEventArgs(string msg) => Message = msg;
}
class Notifier
{
    public event EventHandler<NotifyEventArgs> OnNotify;
    public void Trigger(string msg)
    {
        Console.Write("[Start]");
        OnNotify?.Invoke(this, new NotifyEventArgs(msg));
        Console.Write("[End]");
    }
}
class Program
{
    static void Main()
    {
        Notifier n = new Notifier();
        n.OnNotify += (s, e) =>
        {
        Console.Write("{" + e.Message + "}");
        };
        n.OnNotify += (s, e) =>
        {
        Console.Write("(Nested)");
        if (e.Message == "Ping")
        ((Notifier)s).Trigger("Pong");
        };
        n.Trigger("Ping");
    }
}

/*
[Start]{Ping}(Nested)[Start]{Pong}(Nested)[End][End]

This demonstrates a recursive event.

n.Trigger("Ping"); is called.

Trigger("Ping") prints "[Start]".

OnNotify is invoked with "Ping".

Subscriber 1 runs, printing "(Ping)".

Subscriber 2 runs, printing "(Nested)".

The if condition e.Message == "Ping" is true.

((Notifier)s).Trigger("Pong"); is called recursively from within the event handler.

Trigger("Pong") prints "[Start]".

OnNotify is invoked with "Pong".

Subscriber 1 runs, printing "(Pong)".

Subscriber 2 runs, printing "(Nested)".

The if condition e.Message == "Ping" is false.

Trigger("Pong") finishes and prints "[End]".

Execution returns to Subscriber 2 of the original "Ping" call, which is now finished.

The original Trigger("Ping") call resumes (after OnNotify has fully completed) and prints its "[End]".
*/