namespace ResolucaoDepencia;

public class DatabaseLogger : ICustomLogger
{
    public string Write(string data)
    {
        return $"DatabaseLogger: { data }";
    }
}