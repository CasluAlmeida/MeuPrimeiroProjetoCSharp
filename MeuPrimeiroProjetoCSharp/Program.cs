namespace MeuPrimeiroProjetoCSharp;

class Program
{
    static void Main(string[] args)
    {
        var logPath = Path.Combine(AppContext.BaseDirectory, "logs", "app.log");
        ILogger logger = new FileLogger(logPath);

        Console.WriteLine($"Logs gravados em: {logPath}");
        Console.WriteLine();

        try
        {
            var account1 = CreateAccount("Aline", 0, logger);
            var account2 = CreateAccount("Beatriz", 1000, logger);

            ShowAccountCreated(account1, logger);
            ShowAccountCreated(account2, logger);

            account1.Deposit(500);
            ShowBalance(account1, logger);

            account2.Withdraw(100);
            ShowBalance(account2, logger);
        }
        catch (Exception ex)
        {
            logger.Log($"Erro na execução da aplicação: {ex.Message}");
            Console.Error.WriteLine($"Erro: {ex.Message}");
        }
    }

    private static BankAccount CreateAccount(string name, decimal balance, ILogger logger)
    {
        return new BankAccount(name, balance, logger);
    }

    private static void ShowAccountCreated(BankAccount account, ILogger logger)
    {
        var message = $"A conta de {account.Name} foi criada com sucesso! Saldo inicial: R${account.Balance:F2}";
        logger.Log(message);
        Console.WriteLine(message);
    }

    private static void ShowBalance(BankAccount account, ILogger logger)
    {
        var message = $"{account.Name}, o saldo atualizado da sua conta é R${account.Balance:F2}";
        logger.Log(message);
        Console.WriteLine(message);
    }
}