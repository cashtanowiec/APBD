namespace APBD3;

public class LiquidContainer : Container, IHazardNotifier
{
    private static int idCounter = 1;
    private static readonly char symbol = 'L';

    public LiquidContainer(int containerWeight, int maxLoadWeight, int height, int depth) : base(containerWeight, maxLoadWeight, height, depth)
    {
        this.serialNumber = "KON-" + symbol + "-" + idCounter;
        LiquidContainer.idCounter++;
    }
    
    public void sendNotification(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(this.serialNumber + " Hazard notifier: " + message);
        Console.BackgroundColor = ConsoleColor.White;
    }


    public override void fillContainer(String loadName, int loadWeight)
    {
        throw new InvalidOperationException("This method is not available for LiquidContainer. Please use method with argument bool isDangerous.");
    }

    public void fillContainer(String loadName, int loadWeight, bool isDangerous)
    {
        if (isDangerous && loadWeight > 0.5 * maxLoadWeight)
        {
            this.sendNotification("Trying to load too much dangerous materials!");
        }
        else if (!isDangerous && loadWeight > 0.9 * maxLoadWeight)
        {
            this.sendNotification("Trying to load too much non-dangerous materials!");
        }
        
        base.fillContainer(loadName, loadWeight);
    }
    
}