namespace ResolucaoDepencia;

public class FileLogger : ICustomLogger
{
    public string Write(string data)
    {
        return $"FileLogger: { data }";
    }
}