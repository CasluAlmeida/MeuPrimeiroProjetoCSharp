namespace MeuPrimeiroProjetoCSharp;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("O caminho do arquivo de log não pode ser vazio.", nameof(filePath));

        _filePath = filePath;

        // Garante que o diretório existe antes de gravar
        var directory = Path.GetDirectoryName(Path.GetFullPath(_filePath));
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);
    }

    public void Log(string message)
    {
        try
        {
            var entry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
            File.AppendAllText(_filePath, entry);
        }
        catch (IOException ex)
        {
            Console.Error.WriteLine($"[FileLogger] Falha ao gravar no arquivo '{_filePath}': {ex.Message}");
        }
    }
}