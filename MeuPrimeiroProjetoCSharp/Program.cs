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

        // string name = "Beatriz";

        // Console.WriteLine(name.Length);
        // Console.WriteLine(name.EndsWith("iz"));

        BankAccount account1 = new BankAccount("Ana", 0);
        BankAccount account2 = new BankAccount("Beatriz", 1000);

        // Console.WriteLine("Contas criadas com sucesso!");

        account1.Deposit(500);

        Console.WriteLine(
            $"A conta da cliente {account1.GetName()} foi criada com sucesso! E possui o seguinte saldo: R${account1.GetBalance()}");
        Console.WriteLine(
            $"A conta da cliente {account2.GetName()} foi criada com sucesso! E possui o seguinte saldo: R${account2.GetBalance()}");
    }
}