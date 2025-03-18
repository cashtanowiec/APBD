namespace APBD3;

public class OverfillException : Exception
{
    public OverfillException() : base() {}
    public OverfillException(string message) : base(message) {}
}