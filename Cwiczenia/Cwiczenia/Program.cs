using System.Linq;
static double calculateAverageOfIntArray(int[] array)
{
    return array.Average();
}

static double calculateDoubleAverageOfDoubleArray(double[] array)
{
    return array.Average();
}

static double getMaximumElement(int[] array)
{
    return array.Max();
}


// this is a comment
Console.WriteLine(calculateAverageOfIntArray([3, 2, 3]));
Console.WriteLine(calculateDoubleAverageOfDoubleArray([3.5, 2.2, 3.1]));
Console.WriteLine(getMaximumElement([3, 2, 15]));