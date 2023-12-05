using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab13
{
    internal class AccountFactory
    {
        Hashtable accounts = new Hashtable();
        public int CreateAccount()
        {
            Account account = new Account();
            accounts.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }
        public int CreateAccount(decimal balance)
        {
            Account account = new Account(balance);
            accounts.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }

        public int CreateAccount(AccountType accounttype)
        {
            Account account = new Account(accounttype);
            accounts.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }

        public int CreateAccount(decimal balance, AccountType accounttype)
        {
            Account account = new Account(balance, accounttype);
            accounts.Add(account.AccountNumber, account);
            return account.AccountNumber;
        }
        public void CloseAccount(int accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts.Remove(accountNumber);
            }
        }
    }
}
