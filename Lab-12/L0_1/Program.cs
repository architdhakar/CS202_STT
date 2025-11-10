public delegate void AuthCallback(bool validUser);
public static AuthCallback loginCallback = Login;
public static void Login()
{
    Console.WriteLine("Valid user!");
}
public static void Main(string[] args)
{
    loginCallback(true);
}

/*
/workspaces/CS202_STT/Lab-12/L0_1/Program.cs(3,1): error CS8803: Top-level statements must precede namespace and type declarations. [/workspaces/CS202_STT/Lab-12/L0_1/L0_1.csproj]
/workspaces/CS202_STT/Lab-12/L0_1/Program.cs(3,1): error CS0106: The modifier 'public' is not valid for this item [/workspaces/CS202_STT/Lab-12/L0_1/L0_1.csproj]
/workspaces/CS202_STT/Lab-12/L0_1/Program.cs(7,1): error CS0106: The modifier 'public' is not valid for this item [/workspaces/CS202_STT/Lab-12/L0_1/L0_1.csproj]

The build failed. Fix the build errors and run again.
*/
