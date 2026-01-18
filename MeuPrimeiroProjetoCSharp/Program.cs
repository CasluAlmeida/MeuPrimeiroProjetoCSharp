namespace MeuPrimeiroProjetoCSharp;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");

        // Console.WriteLine("Digite seu nome:");
        // var name = Console.ReadLine();

        // Console.WriteLine("Digite sua idade:");
        // int idade = Convert.ToInt32(Console.ReadLine());

        // string[] names = { "Ana", "Beatriz", "Carlos", "Daniel", "Eduardo" };

        // if (string.Equals(names[0], "aNa", StringComparison.OrdinalIgnoreCase))
        // {
        //     Console.WriteLine("O primeiro nome é Ana");
        // }
        // else
        // {
        //     Console.WriteLine("O primeiro nome não é Ana");
        // }

        // string primeiroName = string.Equals(names[0], "aNa", StringComparison.OrdinalIgnoreCase)
        //     ? "O primeiro nome é Ana"
        //     : "O primeiro nome não é Ana";
        //
        // Console.WriteLine(primeiroName);

        // string name = "Beatriz";

        // Console.WriteLine(name.Length);
        // Console.WriteLine(name.EndsWith("iz"));

        ILogger logger = new ConsoleLogger();

        try
        {
            var account1 = CreateAccount(" ", 0, logger);
            var account2 = CreateAccount("Beatriz", 1000, logger);

            ShowAccountCreated(account1);
            ShowAccountCreated(account2);

            account1.Deposit(500);
            ShowBalance(account1);

            account2.Withdraw(100);
            ShowBalance(account2);
        }
        catch (Exception ex)
        {
            logger.Log($"Erro na execução da aplicação: {ex.Message}");
        }
    }

    private static BankAccount CreateAccount(string name, decimal balance, ILogger logger)
    {
        return new BankAccount(name, balance, logger);
    }

    private static void ShowAccountCreated(BankAccount account)
    {
        Console.WriteLine(
            $"A conta da {account.Name} foi criada com sucesso! Saldo inicial: R${account.Balance}");
    }

    private static void ShowBalance(BankAccount account)
    {
        Console.WriteLine(
            $"{account.Name}, o saldo atualizado da sua conta é R${account.Balance}");
    }
}