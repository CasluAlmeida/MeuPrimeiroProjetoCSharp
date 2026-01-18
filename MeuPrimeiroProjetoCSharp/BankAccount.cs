namespace MeuPrimeiroProjetoCSharp;

public class BankAccount
{
    public string Name { get; }
    public decimal Balance { get; private set; }

    private readonly ILogger _logger;

    public BankAccount(string name, decimal balance, ILogger logger)
    {
        ValidateName(name);
        ValidateInitialBalance(balance);

        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        Name = name;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        ValidateAmount(amount, "depósito");

        Balance += amount;
        _logger.Log($"Depósito de R${amount} realizado com sucesso para a conta de {Name}.");
    }

    public void Withdraw(decimal amount)
    {
        ValidateAmount(amount, "saque");

        if (amount > Balance)
        {
            _logger.Log($"Tentativa de saque de R${amount} maior que o saldo disponível na conta de {Name}.");
            throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
        }

        Balance -= amount;
        _logger.Log($"Saque de R${amount} realizado com sucesso da conta de {Name}.");
    }

    private static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome do titular da conta não pode ser vazio.", nameof(name));
    }

    private static void ValidateInitialBalance(decimal balance)
    {
        if (balance < 0)
            throw new ArgumentException("O saldo inicial não pode ser negativo.", nameof(balance));
    }

    private static void ValidateAmount(decimal amount, string operation)
    {
        if (amount <= 0)
            throw new ArgumentException(
                $"O valor do {operation} deve ser maior que zero.",
                nameof(amount)
            );
    }
}