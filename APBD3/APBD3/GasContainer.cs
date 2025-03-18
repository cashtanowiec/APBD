namespace APBD3;

public class GasContainer : Container, IHazardNotifier
{
    private static int idCounter = 1;
    private static readonly char symbol = 'G';
    private int atmosphere = 0;
    
    public GasContainer(int containerWeight, int maxLoadWeight, int height, int depth) : base(containerWeight, maxLoadWeight, height, depth)
    {
        this.serialNumber = "KON-" + symbol + "-" + idCounter;
        GasContainer.idCounter++;
    }

    public void sendNotification(string message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(this.serialNumber + " Hazard notifier: " + message);
        Console.BackgroundColor = ConsoleColor.White;
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
    
    
}