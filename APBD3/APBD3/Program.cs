namespace APBD3;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== CONTAINER SHIPPING SYSTEM TEST ===\n");
        
        try
        {
            // 1. Create different types of containers
            Console.WriteLine("1. Creating containers...");
            LiquidContainer liquidContainer1 = new LiquidContainer(300, 1000, 250, 200);
            LiquidContainer liquidContainer2 = new LiquidContainer(300, 1000, 250, 200);
            GasContainer gasContainer1 = new GasContainer(500, 800, 300, 250);
            CoolingContainer coolingContainer1 = new CoolingContainer(400, 1200, 280, 240);
            
            Console.WriteLine($"Created: {liquidContainer1}");
            Console.WriteLine($"Created: {liquidContainer2}");
            Console.WriteLine($"Created: {gasContainer1}");
            Console.WriteLine($"Created: {coolingContainer1}");
            
            // 2. Create ships
            Console.WriteLine("\n2. Creating ships...");
            Ship ship1 = new Ship(20, 10, 20000);
            Ship ship2 = new Ship(15, 5, 10000);
            Console.WriteLine("Created Ship 1 and Ship 2");
            
            // 3. Test loading containers
            Console.WriteLine("\n3. Testing container loading...");
            Console.WriteLine("Loading liquid container with non-dangerous cargo (milk)...");
            liquidContainer1.fillContainer("Milk", 800, false);
            Console.WriteLine($"Updated: {liquidContainer1}");
            
            Console.WriteLine("\nLoading liquid container with dangerous cargo (fuel)...");
            try
            {
                liquidContainer2.fillContainer("Fuel", 300, true);
                Console.WriteLine($"Updated: {liquidContainer2}");

                Console.WriteLine("\nTrying to overload dangerous cargo...");
                liquidContainer2.fillContainer("Fuel", 300, true);
                Console.WriteLine($"Failed to update: {liquidContainer2}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            Console.WriteLine("\nLoading gas container...");
            gasContainer1.fillContainer("Helium", 500, 1000);
            Console.WriteLine($"Updated: {gasContainer1}");
            
            try
            {
                Console.WriteLine("\nLoading cooling container...");
                coolingContainer1.fillContainer("Bananas", 900, -5);
                Console.WriteLine($"Updated: {coolingContainer1}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading cooling container: {e.Message}");
                // Try with a valid product from temperatures.txt if the file exists
                coolingContainer1.fillContainer("Oranges", 900, 2);
                Console.WriteLine($"Loaded with alternative product: {coolingContainer1}");
            }
            
            // 4. Test loading containers onto ships
            Console.WriteLine("\n4. Loading containers onto Ship 1...");
            ship1.addContainer(liquidContainer1);
            ship1.addContainer(gasContainer1);
            ship1.addContainer(coolingContainer1);
            Console.WriteLine("Added 3 containers to Ship 1");
            
            // 5. Test ship information printing
            Console.WriteLine("\n5. Ship 1 information:");
            Console.WriteLine(ship1);
            
            // 6. Test container removal
            Console.WriteLine("\n6. Removing gas container from Ship 1...");
            ship1.removeContainer(gasContainer1.getSerialNumber());
            Console.WriteLine("Gas container removed. Updated Ship 1:");
            Console.WriteLine(ship1);
            
            // 7. Test adding container to second ship
            Console.WriteLine("\n7. Adding liquid container 2 to Ship 2...");
            ship2.addContainer(liquidContainer2);
            Console.WriteLine("Added liquid container 2 to Ship 2");
            Console.WriteLine(ship2);
            
            // 8. Test transferring container between ships
            Console.WriteLine("\n8. Transferring cooling container from Ship 1 to Ship 2...");
            Ship.moveContainerBetweenTwoShips(ship1, ship2, coolingContainer1.getSerialNumber());
            Console.WriteLine("Container transferred. Updated ships:");
            Console.WriteLine("Ship 1:");
            Console.WriteLine(ship1);
            Console.WriteLine("Ship 2:");
            Console.WriteLine(ship2);
            
            // 9. Test container replacement
            Console.WriteLine("\n9. Creating new container and replacing on Ship 1...");
            GasContainer gasContainer2 = new GasContainer(400, 700, 280, 230);
            gasContainer2.fillContainer("Nitrogen", 400, 10);
            ship1.replaceContainerWithAnother(liquidContainer1.getSerialNumber(), gasContainer2);
            Console.WriteLine("Container replaced. Updated Ship 1:");
            Console.WriteLine(ship1);
            
            // 10. Test emptying containers
            Console.WriteLine("\n10. Emptying gas container...");
            gasContainer2.emptyContainer();
            Console.WriteLine($"Emptied: {gasContainer2}");
            
            // 11. Test adding multiple containers
            Console.WriteLine("\n11. Adding multiple containers at once...");
            List<Container> multipleContainers = new List<Container>();
            LiquidContainer liquidContainer3 = new LiquidContainer(300, 1000, 250, 200);
            liquidContainer3.fillContainer("Water", 700, false);
            CoolingContainer coolingContainer2 = new CoolingContainer(400, 1000, 280, 240);
            coolingContainer2.fillContainer("Fish", 800, 1);
            try
            {
                multipleContainers.Add(liquidContainer3);
                multipleContainers.Add(coolingContainer2);
                ship1.addContainerList(multipleContainers);
                Console.WriteLine("Added multiple containers. Updated Ship 1:");
                Console.WriteLine(ship1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            
            // 12. Test exception handling for overfill
            Console.WriteLine("\n12. Testing overfill exception...");
            try
            {
                LiquidContainer liquidContainer4 = new LiquidContainer(300, 500, 250, 200);
                liquidContainer4.fillContainer("Oil", 600, false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Caught expected exception: {e.Message}");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
        
        Console.WriteLine("\n=== TEST COMPLETE ===");
    }
}