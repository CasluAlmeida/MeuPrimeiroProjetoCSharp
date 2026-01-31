namespace MeuPrimeiroProjetoCSharp;

public class FileLogger : ILogger
{
    private readonly string _file;

    public FileLogger(string file)
    {
        _file = file;
    }

    public void Log(string message)
    {
        File.AppendAllText(_file, $"{message}{Environment.NewLine}");
    }
}