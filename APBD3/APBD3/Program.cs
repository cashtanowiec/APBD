namespace APBD3;

public class Program
{
    public static void Main(string[] args)
    {
        Container container1 = new Container(100, 100, 100, 100);
        Container container2 = new Container(100, 100, 100, 100);
        LiquidContainer liquidContainer1 = new LiquidContainer(1000, 800, 400, 400);
        LiquidContainer liquidContainer2 = new LiquidContainer(1000, 800, 400, 400);
        liquidContainer1.fillContainer("Fuel", 500);
        Console.WriteLine(container1);
        Console.WriteLine(container2);
        Console.WriteLine(liquidContainer1);
        Console.WriteLine(liquidContainer2);
    }
}