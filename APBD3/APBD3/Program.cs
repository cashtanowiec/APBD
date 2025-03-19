namespace APBD3;

public class Program
{
    public static void Main(string[] args)
    {
        // Container container1 = new Container(100, 100, 100, 100);
        // Container container2 = new Container(100, 100, 100, 100);
        // LiquidContainer liquidContainer1 = new LiquidContainer(1000, 800, 400, 400);
        // LiquidContainer liquidContainer2 = new LiquidContainer(1000, 800, 400, 400);
        // Console.WriteLine(container1);
        // Console.WriteLine(container2);
        // Console.WriteLine(liquidContainer1);
        // Console.WriteLine(liquidContainer2);
        // liquidContainer1.fillContainer("TEST", 401, true);
        // liquidContainer1.fillContainer("TEST", 200);
        // Console.WriteLine(liquidContainer1);


        CoolingContainer coolingContainer = new CoolingContainer(100, 100, 100, 100);
        GasContainer gasContainer = new GasContainer(100, 100, 100, 100);
        LiquidContainer liquidContainer = new LiquidContainer(100, 100, 100, 100);
        Ship ship = new Ship(10, 10, 10000);
        ship.addContainer(coolingContainer);
        ship.addContainer(gasContainer);
        ship.addContainer(liquidContainer);

        Console.WriteLine(coolingContainer);
        Console.WriteLine(gasContainer);
        Console.WriteLine(liquidContainer);
        Console.WriteLine(ship);
        
        
    }
}