using System;
public class Vehicle
{
    protected int speed;
    protected int fuel;

    public Vehicle(int speed, int fuel)
    {
        this.speed = speed;
        this.fuel = fuel;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Vehicle Info: Speed: {speed}, Fuel: {fuel}");
    }

    public virtual void Drive()
    {
        fuel -= 5;
        Console.WriteLine("Vehicle is moving...");
    }
}
public class Car : Vehicle
{
    private int passengers;

    public Car(int speed, int fuel, int passengers) : base(speed, fuel)
    {
        this.passengers = passengers;
    }

    public override void Drive()
    {
        fuel -= 10;
        Console.WriteLine($"Car is moving with {passengers} passenger(s)");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Car Info: Speed: {speed}, Fuel: {fuel}, Passengers: {passengers}");
    }
}
public class Truck : Vehicle
{
    private int cargoWeight;

    public Truck(int speed, int fuel, int cargoWeight) : base(speed, fuel)
    {
        this.cargoWeight = cargoWeight;
    }

    public override void Drive()
    {
        fuel -= 15;
        Console.WriteLine($"Truck is moving with {cargoWeight}kg of cargo");
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Truck Info: Speed: {speed}, Fuel: {fuel}, Cargo: {cargoWeight}kg");
    }
}
public class Task2
{
    public static void Run()
    {
        Console.WriteLine("\n\n--- Task 2: Inheritance and Polymorphism ---");

        Vehicle[] vehicles = new Vehicle[3];
        vehicles[0] = new Vehicle(60, 90);
        vehicles[1] = new Car(120, 75, 2);
        vehicles[2] = new Truck(65, 160, 5000);

        foreach (Vehicle v in vehicles)
        {
            v.Drive();
            v.ShowInfo();
            Console.WriteLine(); 
        }
    }
}