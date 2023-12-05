using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab13
{
    public enum AccountType
    {
        Current,
        Saving
    }
    public class Account
    {
        public int nextAccountNumber;
        public int AccountNumber { get; }
        public decimal Balance;
        public AccountType Accounttype { get; }
        public string AccountHolder { get; set; }
        private Queue<BankTransaction> Transactions = new Queue<BankTransaction>();

        internal Account()
        {
            AccountNumber = GetNextAccountNumber();
        }

        public int GetNextAccountNumber()
        {
            return ++nextAccountNumber;
        }


        internal Account(decimal balance)
        {
            AccountNumber = GetNextAccountNumber();
            Balance = balance;
        }

        internal Account(AccountType accounttype)
        {
            AccountNumber = GetNextAccountNumber();
            Accounttype = accounttype;
        }

        internal Account(decimal balance, AccountType accounttype)
        {
            AccountNumber = GetNextAccountNumber();
            Balance = balance;
            Accounttype = accounttype;
        }

        public decimal TakeoffAccount(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(DateTime.Now, -amount);
            if (amount <= Balance && amount > 0)
            {
                Balance -= amount;
                Transactions.Enqueue(transaction);
                return Balance;

            }
            else
            {
                return -1;
            }
        }

        public void PutonAccount(decimal amount)
        {
            BankTransaction transaction = new BankTransaction(DateTime.Now, amount);
            if (amount < 0)
            {
                Console.WriteLine("Неправильно введено значение!");
            }
            else
            {
                Balance += amount;
                Transactions.Enqueue(transaction);
                Console.WriteLine($"Новый баланс: {Balance}");
            }
        }

        public void PrintNewBalance()
        {
            Balance = 15000;
            Console.WriteLine("Снять или пополнить?(после ввода нажмите enter)");
            string str = Console.ReadLine();
            str = str.ToLower();
            if (str == "снять")
            {
                Console.WriteLine("Введите сумму для снятия(после ввода нажмите enter):");
                decimal amount = decimal.Parse(Console.ReadLine());
                decimal newBalance = TakeoffAccount(amount);
                if (newBalance == -1)
                {
                    Console.WriteLine("Недостаточно средств на счете или неправильно введено значение для снятие!");
                }
                else
                {
                    Console.WriteLine($"Новый баланс: {newBalance}");
                    // Получаем время транзакции с помощью метода Peek
                    // Первый элемент в очереди транзакций
                    DateTime transactionTime = Transactions.Peek().DateTime;
                    // Получаем сумму транзакции с помощью метода Peek
                    decimal transactionSum = Transactions.Peek().Sum;
                    Console.WriteLine($"Время транзакции: {transactionTime}");
                    Console.WriteLine($"Сумма транзакции: {transactionSum}");
                    Dispose();

                }
            }
            else if (str == "пополнить")
            {
                Console.WriteLine("Введите сумму для пополнения(после ввода нажмите enter):");
                decimal amount = decimal.Parse(Console.ReadLine());
                PutonAccount(amount);
                DateTime transactionTime = Transactions.Peek().DateTime;
                decimal transactionSum = Transactions.Peek().Sum;
                Console.WriteLine($"Время транзакции: {transactionTime}");
                Console.WriteLine($"Сумма транзакции: {transactionSum}");
                Dispose();
            }
        }

        public void Print()
        {
            Console.WriteLine($"Номер: {AccountNumber}");
            Console.WriteLine($"Баланс: {Balance}");
            Console.WriteLine($"Тип счета: {Accounttype}");
            if (AccountHolder != null)
            {
                Console.WriteLine($"Держатель счета: {AccountHolder}");
            }
        }
        public void TransferMoney(Account account1, decimal amount)
        {
            decimal newBalance = account1.TakeoffAccount(amount);

            if (newBalance != -1)
            {
                Balance += amount;
                Console.WriteLine($"Новый баланс на счету {AccountNumber}: {Balance}");
                Console.WriteLine($"Новый баланс на счету {account1.AccountNumber}: {newBalance}");
                DateTime transactionTime = account1.Transactions.Peek().DateTime;
                decimal transactionSum = account1.Transactions.Peek().Sum;
                Console.WriteLine($"Время транзакции: {transactionTime}");
                Console.WriteLine($"Сумма транзакции: {transactionSum}");
                account1.Dispose();
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете или неправильно введено значение для перевода!");
            }
        }
        public void Dispose()
        {
            if (Transactions.Count > 0)
            {
                using (StreamWriter writer = new StreamWriter("Transactions.txt", true))
                {
                    foreach (BankTransaction transaction in Transactions)
                    {
                        writer.WriteLine($"Дата: {transaction.DateTime}, Сумма: {transaction.Sum}");
                    }
                }
            }
            GC.SuppressFinalize(this);
        }
        public override bool Equals(object obj)
        {
            Account account = obj as Account;
            if (account == null)
            {
                return false;
            }
            return AccountNumber == account.AccountNumber && Balance == account.Balance && Accounttype == account.Accounttype;
        }
        public override int GetHashCode()
        {
            return AccountNumber.GetHashCode() ^ Balance.GetHashCode() ^ Accounttype.GetHashCode();
        }
        public static bool operator ==(Account account1, Account account2)
        {
            if (object.ReferenceEquals(account1, account2))
            {
                return true;
            }

            if (object.ReferenceEquals(account1, null) || object.ReferenceEquals(account2, null))
            {
                return false;
            }

            return account1.Equals(account2);
        }
        public static bool operator !=(Account account1, Account account2)
        {
            return !(account1 == account2);
        }
        public override string ToString()
        {
            return $"Номер: {AccountNumber}, Баланс: {Balance}, Тип счета: {Accounttype}";
        }
        public BankTransaction this[int index]
        {
            get
            {
                if (index >= 0 && index < Transactions.Count)
                {
                    return Transactions.ElementAt(index);
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона");
                }
            }
        }
    }
}
