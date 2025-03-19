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
        Console.BackgroundColor = ConsoleColor.Red;
        this.serialNumber = "KON-G-" + idCounter;
        Console.ResetColor();
    }

    public void sendNotification(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(this.serialNumber + " Hazard notifier: " + message);
        Console.ResetColor();
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
        // nie rozumiem kiedy mamy informowac o niebezpiecznym zdarzeniu w tym przypadku (informowanie o przekroczeniu maksymalnej ladownosci
        // znajduje sie juz w klasie Container), dlatego zrobie to losowo:
        // -raz na 50 przypadkow wydarzy sie jakies niebezpieczne zdarzenie i wywola sie metoda z interfejsu IHazardNotifier
        // pls forgive me
        
        Random random = new Random();
        int rnd = random.Next(1, 51);
        if (rnd == 1) sendNotification("An accident happened during emptying of the container!");
        else this.loadWeight = (int) 0.05 * loadWeight;
    }

    public override string ToString()
    {
        return base.ToString() + $", Pressure: {pressure}";
    }
}