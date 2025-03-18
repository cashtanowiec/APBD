namespace APBD3;

public class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        int rnd = random.Next(1, 50);
        Console.WriteLine(rnd);
        
        Container container1 = new Container(100, 100, 100, 100);
        Container container2 = new Container(100, 100, 100, 100);
        LiquidContainer liquidContainer1 = new LiquidContainer(1000, 800, 400, 400);
        LiquidContainer liquidContainer2 = new LiquidContainer(1000, 800, 400, 400);
        Console.WriteLine(container1);
        Console.WriteLine(container2);
        Console.WriteLine(liquidContainer1);
        Console.WriteLine(liquidContainer2);
        
        liquidContainer1.fillContainer("TEST", 401, true);
    }
}