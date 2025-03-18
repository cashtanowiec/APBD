namespace APBD3;

public class Container
{
    private static int idCounter = 1;
    private static readonly char symbol = 'A';
    protected string serialNumber;
    private string? loadName;
    private int? loadWeight;
    private int height;
    private int containerWeight;
    private int depth;
    private int maxLoad;

    public Container(int containerWeight, int maxLoad, int height, int depth)
    {
        this.serialNumber = "KON-" + symbol + "-" + idCounter;
        this.containerWeight = containerWeight;
        this.height = height;
        this.depth = depth;
        this.maxLoad = maxLoad;
        Container.idCounter++;
    }


    public virtual void fillContainer(String loadName, int loadWeight)
    {
        if (loadWeight > maxLoad) throw new OverflowException("Load weight cannot be greater than max load weight!");
        else if (this.loadName == null)
        {
            this.loadName = loadName;
            this.loadWeight = loadWeight;
        }
        else if (loadName != this.loadName) throw new ArgumentException("Only one load can be stored at a time!");
        else if (loadName == this.loadName) this.loadWeight += loadWeight;

    }
    
    public virtual void emptyContainer()
    {
        this.loadName = null;
        this.loadWeight = null;
    }

    public override string ToString()
    {
        return $"Serial Number: {serialNumber}, " +
               $"Load Name: {loadName ?? "None"}, " +
               $"Load Weight: {loadWeight ?? 0}, " +
               $"Container Weight: {containerWeight}, " +
               $"Height: {height}, " +
               $"Depth: {depth}, " +
               $"Max Load: {maxLoad}";
    }

}