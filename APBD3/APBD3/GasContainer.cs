namespace APBD3;

public class GasContainer : Container, IHazardNotifier
{
    private static int idCounter = 1;
    private int pressure = 0;
    
    public GasContainer(int containerWeight, int maxLoadWeight, int height, int depth) : base(containerWeight, maxLoadWeight, height, depth)
    {
        GasContainer.idCounter++;
    }
    
    protected override void setSerialNumber()
    {
        this.serialNumber = "KON-G-" + idCounter;
    }

    public void sendNotification(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write(this.serialNumber + " Hazard notifier: " + message);
        Console.ResetColor();
        Console.WriteLine();
    }

    public override void fillContainer(string loadName, int loadWeight)
    {
        throw new InvalidOperationException("This method is not available for GasContainer. Please use the same method with an argument 'int pressure'.");
    }

    public void fillContainer(String LoadName, int LoadWeight, int pressure)
    {
        this.pressure = pressure;
        base.fillContainer(LoadName, LoadWeight);
    }
    
    public override void emptyContainer()
    {
        this.loadWeight = 0.05 * loadWeight;
    }

    public override string ToString()
    {
        return base.ToString() + $", Pressure: {pressure}";
    }
}