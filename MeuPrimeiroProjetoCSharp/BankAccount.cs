namespace MeuPrimeiroProjetoCSharp;

public class BankAccount
{
    private string name;
    private decimal balance;

    public BankAccount(string name, decimal balance)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("O nome do titular da conta não pode ser vazio.", nameof(name));
        }
        if(balance < 0)
        {
            throw new ArgumentException("O saldo inicial não pode ser negativo.", nameof(balance));
        }
        this.name = name;
        this.balance = balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("O valor de depósito deve ser maior que zero.", nameof(amount));
        }

        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("O valor de saque deve ser maior que zero.", nameof(amount));
        }

        if (amount > balance)
        {
            throw new ArgumentException("O valor do saque é superior ao limite da conta.", nameof(amount));
        }
            
        balance -= amount;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public String GetName()
    {
        return name;
    }
}