namespace APBD3;

public class Container
{
    private static int idCounter = 1;
    protected string serialNumber;
    protected string? loadName;
    protected double loadWeight;
    protected double maxLoadWeight;
    protected int height;
    protected int containerWeight;
    protected int depth;

    public Container(int containerWeight, int maxLoadWeight, int height, int depth)
    {
        setSerialNumber();
        this.loadName = null;
        this.loadWeight = 0;
        this.containerWeight = containerWeight;
        this.height = height;
        this.depth = depth;
        this.maxLoadWeight = maxLoadWeight;
        Container.idCounter++;
    }

    protected virtual void setSerialNumber()
    {
        this.serialNumber = "KON-A-" + idCounter;
    }

    public string getSerialNumber()
    {
        return serialNumber;
    }

    public double getTotalWeight()
    {
        return loadWeight + containerWeight;
    }


    public virtual void fillContainer(string LoadName, int LoadWeight)
    {
        if (LoadWeight + this.loadWeight > maxLoadWeight) throw new OverfillException("Load weight cannot be greater than max load weight!");
        if (this.loadName == null || this.loadName == LoadName)
        {
            this.loadName = LoadName;
            this.loadWeight += LoadWeight;
        }
        else if (LoadName != this.loadName) throw new ArgumentException("Only one load can be stored at a time!");
    }
    
    public virtual void emptyContainer()
    {
        this.loadName = null;
        this.loadWeight = 0;
    }

    public override string ToString()
    {
        return $"Serial Number: {serialNumber}, " +
               $"Load Name: {loadName ?? "None"}, " +
               $"Load Weight: {loadWeight}, " +
               $"Container Weight: {containerWeight}, " +
               $"height: {height}, " +
               $"depth: {depth}, " +
               $"Max Load: {maxLoadWeight}";
    }

}