namespace APBD3;

public class Ship
{
    private List<Container> list = new List<Container>();
    private int maxSpeed;
    private int maxContainerCount;
    private int maxShipWeight;
    public double containersWeight = 0;

    public Ship(int maxSpeed, int maxContainerCount, int maxShipWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainerCount = maxContainerCount;
        this.maxShipWeight = maxShipWeight;
    }

    public void addContainer(Container container)
    {
        if (containersWeight + container.getTotalWeight() > maxShipWeight)
            throw new ArgumentException("The container is too heavy!");
        containersWeight += container.getTotalWeight();
        list.Add(container);
    }

    public void addContainerList(List<Container> containers)
    {
        double total = 0;
        foreach (Container container in containers)
        {
            total += container.getTotalWeight();
        }
        if (total > maxShipWeight)
            throw new ArgumentException("The container is too heavy!");

        containersWeight += total;
        list.AddRange(containers);
    }

    public void removeContainer(String SerialNumber)
    {
        Container findBySerialNumber = list.Find(container => container.getSerialNumber() == SerialNumber);
        containersWeight -= findBySerialNumber.getTotalWeight();
        list.Remove(findBySerialNumber);
    }

    public void removeContainer(int index)
    {
        containersWeight -= list[index].getTotalWeight();
        list.RemoveAt(index);
    }

    public void replaceContainerWithAnother(String SerialNumberToBeReplaced, Container container)
    {
        int index = list.FindIndex(container => container.getSerialNumber() == SerialNumberToBeReplaced);
        if (containersWeight - list[index].getTotalWeight() + container.getTotalWeight() > maxShipWeight)
            throw new ArgumentException("The container is too heavy!");

        containersWeight = containersWeight - list[index].getTotalWeight() + container.getTotalWeight();
        list[index] = container;
    }
    
    public void replaceContainerWithAnother(int index, Container container)
    {
        if (containersWeight - list[index].getTotalWeight() + container.getTotalWeight() > maxShipWeight)
            throw new ArgumentException("The container is too heavy!");

        containersWeight = containersWeight - list[index].getTotalWeight() + container.getTotalWeight();
        list[index] = container;
    }

    public static void moveContainerBetweenTwoShips(Ship shipFrom, Ship shipTo, String SerialNumber)
    {
        Container container = shipFrom.list.Find(container => container.getSerialNumber() == SerialNumber);
        if (shipTo.containersWeight + container.getTotalWeight() > shipTo.maxShipWeight)
            throw new ArgumentException("The container is too heavy!");
        shipFrom.containersWeight -= container.getTotalWeight();
        shipTo.containersWeight += container.getTotalWeight();
        
        shipFrom.removeContainer(container.getSerialNumber());
        shipTo.addContainer(container);
    }
    
    public static void moveContainerBetweenTwoShips(Ship shipFrom, Ship shipTo, int index)
    {
        Container container = shipFrom.list[index];
        if (shipTo.containersWeight + container.getTotalWeight() > shipTo.maxShipWeight)
            throw new ArgumentException("The container is too heavy!");
        
        shipFrom.removeContainer(container.getSerialNumber());
        shipTo.addContainer(container);
    }
    
    public override string ToString()
    {
        string shipInfo = $"Ship Details:\n" +
                          $"Max Speed: {maxSpeed} km/h\n" +
                          $"Max Container Count: {maxContainerCount}\n" +
                          $"Max Container Weight: {maxShipWeight} kg\n";

        if (list.Count > 0)
        {
            shipInfo += "Containers on board:\n";
            foreach (var container in list)
            {
                shipInfo += container.ToString() + "\n"; // Assuming Container has a ToString method
            }
        }
        else
        {
            shipInfo += "No containers on board.\n";
        }

        return shipInfo;
    }
}