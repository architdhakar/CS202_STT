using System;
class TemperatureEventArgs : EventArgs
{
    public int OldTemperature { get; }
    public int NewTemperature { get; }
    public TemperatureEventArgs(int oldTemp, int newTemp)
    {
        OldTemperature = oldTemp;
        NewTemperature = newTemp;
    }
}
class TemperatureSensor
{
    public event EventHandler<TemperatureEventArgs> TemperatureChanged;
    private int temperature = 25;
    public void UpdateTemperature(int newTemp)
    {
        int oldTemp = temperature;
        temperature = newTemp;
        if (Math.Abs(newTemp - oldTemp) > 5)
        {
            TemperatureChanged?.Invoke(this, new TemperatureEventArgs(oldTemp, newTemp));
        }
    }
}
class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        sensor.TemperatureChanged += (s, e) =>
        Console.WriteLine($"Temperature changed from {e.OldTemperature}°C to {e.NewTemperature}°C");
        sensor.TemperatureChanged += (s, e) =>
        {
            if (Math.Abs(e.NewTemperature - e.OldTemperature) > 10)
                Console.WriteLine(" Warning: Sudden change detected!");
        };
        sensor.UpdateTemperature(28);
        sensor.UpdateTemperature(30);
        sensor.UpdateTemperature(46);
        sensor.UpdateTemperature(52);
    }
}
/*
emperature changed from 30°C to 46°C
 Warning: Sudden change detected!
Temperature changed from 46°C to 52°C
The TemperatureChanged event only fires if the absolute difference between the new and old temperature is greater than 5. The sensor's temperature starts at 25.


sensor.UpdateTemperature(28); 

old=25, new=28. Abs(28 - 25) is 3.

3 > 5 is false. The event does not fire.

sensor.UpdateTemperature(30); 

old=28, new=30. Abs(30 - 28) is 2.

2 > 5 is false. The event does not fire.

sensor.UpdateTemperature(46); 

old=30, new=46. Abs(46 - 30) is 16.

16 > 5 is true. The event fires.

Subscriber 1 prints: "Temperature changed from 30°C to 46°C".

Subscriber 2 checks if Abs(46 - 30) > 10. 16 > 10 is true. It prints: " Warning: Sudden change detected!".


sensor.UpdateTemperature(52); 

old=46, new=52. Abs(52 - 46) is 6.

6 > 5 is true. The event fires.

Subscriber 1 prints: "Temperature changed from 46°C to 52°C".

Subscriber 2 checks if Abs(52 - 46) > 10. 6 > 10 is false. It prints nothing.
*/