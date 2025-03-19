namespace APBD3;

public class CoolingContainer : Container
{
    private static int idCounter = 1;
    private int temperature;
    private static Dictionary<string, double> productTemperaturePair = new Dictionary<string, double>();
    public CoolingContainer(int containerWeight, int maxLoadWeight, int height, int depth) : base(containerWeight, maxLoadWeight, height, depth)
    {
        CoolingContainer.idCounter++;
    }

    static CoolingContainer()
    {
        string[] lines = File.ReadAllLines("temperatures.txt");
        foreach (string line in lines)
        {
            string[] keyValuePair = line.Split(" = ");
            productTemperaturePair.Add(keyValuePair[0], Convert.ToDouble(keyValuePair[1]));
        }
    }
    
    protected override void setSerialNumber()
    {
        this.serialNumber = "KON-C-" + idCounter;
    }

    public override void fillContainer(string loadName, int loadWeight)
    {
        throw new InvalidOperationException("This method is not available for CoolingContainer. Please use the same method with an argument 'int temperature'.");
    }

    public void fillContainer(string LoadName, int LoadWeight, int temperature)
    {
        if (!productTemperaturePair.ContainsKey(LoadName))
            throw new ArgumentException("Such product doesn't exist in the table!");
        if (temperature > productTemperaturePair[LoadName])
            throw new ArgumentException("The storage temperature is higher than allowed storage temperature for this product!");

        this.temperature = temperature;
        base.fillContainer(LoadName, LoadWeight);
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Temperature: {temperature}";
    }
}