using System.Linq;
static double method1(int[] array)
{
    return array.Average();
}

static double method2(double[] array)
{
    return array.Average();
}

static double getMaximumElement(int[] array)
{
    return array.Max();
}


// this is a comment
Console.WriteLine(method1([3, 2, 3]));
Console.WriteLine(method2([3.5, 2.2, 3.1]));
Console.WriteLine(getMaximumElement([3, 2, 15]));