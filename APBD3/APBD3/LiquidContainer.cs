namespace APBD3;

public class LiquidContainer : Container, IHazardNotifier
{
    private static int idCounter = 1;
    public LiquidContainer(int containerWeight, int maxLoadWeight, int height, int depth) : base(containerWeight, maxLoadWeight, height, depth)
    {
        LiquidContainer.idCounter++;
    }

    protected override void setSerialNumber()
    {
        this.serialNumber = "KON-L-" + idCounter;
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
        throw new InvalidOperationException("This method is not available for LiquidContainer. Please use the same method with an argument 'bool isDangerous'.");
    }

    public void fillContainer(string LoadName, int LoadWeight, bool isDangerous)
    {
        if (isDangerous && LoadWeight + this.loadWeight > 0.5 * this.maxLoadWeight)
        {
            this.sendNotification("Trying to load too much dangerous materials!");
        }
        else if (!isDangerous && LoadWeight + this.loadWeight > 0.9 * this.maxLoadWeight)
        {
            this.sendNotification("Trying to load too much non-dangerous materials!");
        }
        else base.fillContainer(LoadName, LoadWeight);
    }
}