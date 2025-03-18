namespace APBD3;

public class LiquidContainer : Container, IHazardNotifier
{
    private static int idCounter = 1;
    private static readonly char symbol = 'L';

    public LiquidContainer(int containerWeight, int maxLoad, int height, int depth) : base(containerWeight, maxLoad, height, depth)
    {
        this.serialNumber = "KON-" + symbol + "-" + idCounter;
        LiquidContainer.idCounter++;
    }
    
    public void sendNotification(string message)
    {
        Console.WriteLine("Dangerous situation has occured: " + message);
    }

    public void fillContainer(String loadName, int loadWeight, bool isDangerous)
    {
        base.fillContainer(loadName, loadWeight);
    }
    
}