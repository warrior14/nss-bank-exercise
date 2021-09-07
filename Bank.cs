using System.Collections.Generic;
using System;

namespace BankConsole
{
    public class Bank
    {
        public string Name { get; set; }
        public List<BankAccount> Accounts { get; set; } = new List<BankAccount>();

        public void AddAccount()
        {
            var firstName = Prompt("First Name");
            var lastName = Prompt("Last Name");
            var street = Prompt("Street");
            var apt = Prompt("Apt");
            var city = Prompt("City");
            var state = Prompt("State");
            var zip = Prompt("Zip");
            var initialDeposit = Decimal.Parse(Prompt("Initial deposit"));
            var newAccount = new BankAccount 
            {
              Owner = new Person
              {
                  FirstName = firstName,
                  LastName = lastName,
                  Address = new Address
                  {
                      Street = street,
                      Apt = apt,
                      City = city,
                      State = state,
                      Zip = zip
                  }
              }
            }
            newAccount.Transactions.Add(new Transaction
            {
                Description = "Initial Deposit",
                Amount = initialDeposit
            });
            Accounts.Add(newAccount);
            Console.WriteLine($"Account number {newAccount.AccountNumber} for {newAccount.Owner.FullName} added!");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        public void ListAccount()
        {
            Console.Write("Input account number or name: ");
            var input = Console.ReadLine();
            try 
            {
                var intResponse = int.Parse(input);
                ListSingeAccount(intResponse);
            }
            catch
            {
                ListSingleAccount(input);
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        public void AddTransaction()
        {
            var payeeAcct = Prompt("Payee Account Number");
            var payorAcct = Prompt("Payor Account Number");
            var description = Prompt("Description");
            var amount = Decimal.Parse(Prompt("Amount"));

            var payee = Accounts.Find(acct => acct.AccountNumber == int.Parse(payeeAcct));
            var payor = Accounts.Find(acct => acct.AccountNumber == int.Parse(PayorAcct));

            if (amount > payor.Balance)
            {
                Console.WriteLine("You don't have the funds.");
            }
            else 
            {
                var payeeTrans = new Transaction
                {
                    Description = description,
                    Amount = -amount
                };
                payor.Transactions.Add(payorTrans);


                Console.WriteLine($"{payor.Owner.FullName} paid {payee.Owner.FullName}");
                Console.WriteLine($"{amount} for {description} ");
                Console.WriteLine("New Balance");
                Console.WriteLine("----------------");
                ListSingleAccount(payee.AccountNumber);
                ListSingleAccount(payor.AccountNumber);
            }
            Console.Write("Pres any key to continue!");
            Console.ReadLine();
        }


        public void PrintMailingLabels()
        {
            foreach (BankAccount acct in Accounts)
            {
                Console.WriteLine(acct.Owner.AddressWithName);
                Console.WriteLine();
            }
            Console.Write("Press any key to continue!");
            Console.ReadLine();
        }

        private void ListSingleAccount(int acctNumber)
        {
            var act = Accounts.Find(act => acct.AccountNumber == acctNumber);
            if (acct != null)
            {
                Console.WriteLine($"Name: {acct.Owner.FullName}, Number: {acct.AccountNumber}, Balance: {acct.Balance}");
            }
            else 
            {
                Console.WriteLine("Account Not Found!");
            }
        }

        private string Prompt(string Prompt)
        {
            Console.Write($"{Prompt} ");
            string response = Console.ReadLine();
            Console.WriteLine();
            return response;
        }
    }
}