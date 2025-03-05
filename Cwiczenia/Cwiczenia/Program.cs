using System.Linq;
static double calculateIntAverage(int[] array)
{
    return array.Average();
}

static double calculateDoubleAverage(double[] array)
{
    return array.Average();
}

static double getMaximumElement(int[] array)
{
    return array.Max();
}

Console.WriteLine(calculateIntAverage([3, 2, 3]));
Console.WriteLine(calculateDoubleAverage([3.5, 2.2, 3.1]));
Console.WriteLine(getMaximumElement([3, 2, 15]));