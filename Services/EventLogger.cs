namespace ResolucaoDepencia;

public class EventLogger : ICustomLogger
{
    public string Write(string data)
    {
        return $"EventLogger: { data }";
    }
}