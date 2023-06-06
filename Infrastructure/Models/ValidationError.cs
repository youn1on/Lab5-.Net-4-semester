namespace Infrastructure.Models;

public struct ValidationError
{
    public string Reason;

    public ValidationError(string reason)
    {
        Reason = reason;
    }

    public override string ToString()
    {
        return "Error: " + Reason;
    }
}