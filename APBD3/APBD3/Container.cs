namespace APBD3;

public class Container
{
    private static int idCounter = 1;
    private static readonly char symbol = 'A';
    protected string serialNumber;
    protected string? LoadName;
    protected double loadWeight;
    protected double maxLoadWeight;
    protected int height;
    protected int containerWeight;
    protected int depth;

    public Container(int containerWeight, int maxLoadWeight, int height, int depth)
    {
        this.serialNumber = "KON-" + symbol + "-" + idCounter;
        this.containerWeight = containerWeight;
        this.height = height;
        this.depth = depth;
        this.maxLoadWeight = maxLoadWeight;
        Container.idCounter++;
    }


    public virtual void fillContainer(String LoadName, int loadWeight)
    {
        if (loadWeight > maxLoadWeight) throw new OverflowException("Load weight cannot be greater than max load weight!");
        else if (this.LoadName == null || this.LoadName == LoadName)
        {
            this.LoadName = LoadName;
            this.loadWeight += loadWeight;
        }
        else if (LoadName != this.LoadName) throw new ArgumentException("Only one load can be stored at a time!");
    }
    
    public virtual void emptyContainer()
    {
        this.LoadName = null;
        this.loadWeight = 0;
    }

    public override string ToString()
    {
        return $"Serial Number: {serialNumber}, " +
               $"Load Name: {LoadName ?? "None"}, " +
               $"Load Weight: {loadWeight}, " +
               $"Container Weight: {containerWeight}, " +
               $"height: {height}, " +
               $"depth: {depth}, " +
               $"Max Load: {maxLoadWeight}";
    }

}