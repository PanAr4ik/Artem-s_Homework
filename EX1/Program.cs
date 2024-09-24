namespace EX1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount user1 = new BankAccount(80808008, "Igor", 3000000);
            Console.WriteLine("Balance" + Convert.ToString(user1.GetBalance()));
            user1.Deposit(150000);
            Console.WriteLine("Balance" + user1.GetBalance());
            user1.Withdraw(100);
            Console.WriteLine("Balance" + Convert.ToString(user1.GetBalance()));
        }
    }

    public class BankAccount
    {
    private int _accountNumber;
    private string _owner;
    public decimal _balance;

    public BankAccount(int accountNumber, string owner, decimal balance)
    {
        this._accountNumber = accountNumber;
        this._owner = owner;
        this._balance = balance;
    }

    // Метод для проверки баланса
    public decimal GetBalance()
    {
        return _balance;
    }

    // Метод для пополнения счета
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine("Счет пополнен на сумму: " + amount);
        }
        else
            Console.WriteLine("Сумма пополнения должна быть положительной.");
    }

    // Метод для снятия средств
    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
            Console.WriteLine("Со счета снято: " + amount);
        }
        else
            Console.WriteLine("Недостаточно средств на счете или сумма снятия некорректна.");
    }
    }


}
