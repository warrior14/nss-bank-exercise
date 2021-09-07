using System.Collections.Generic;

namespace Bank
{
    public class BankAccount
    {
        private static int _accountIncremeter = 1;
        public BankAccount()
        {
            AccountNumber = _accountIncremeter = 1;
        }
        public Person Owner { get; set; }
        public int AccountNumber { get; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public decimal Balance 
        {
            get 
            {
                decimal balance = 0.0M;
                foreach (Transaction trans in Transactions)
                {
                    balance += trans.Account;
                }
                return balance;
            }
        }
    }
}