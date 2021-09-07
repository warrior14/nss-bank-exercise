using System.Collections.Generic;
using System;


namespace Bank 
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = bankName = args[0];
            try
            {
                string bankName = args[0];
                bank.Name = bankName;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please add a bank name!");
                return;
            }

            while (true) 
            {
                Console.Clear();
                Console.WriteLine($"{bank.Name} Please select an option!");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1 ~ Add an account.");
                Console.WriteLine("2 ~ Print Mailing Labels");
                Console.WriteLine("3 ~ List All Accounts");
                Console.WriteLine("4 ~ List a single account details");
                Console.WriteLine("5 ~ Create a transaction");
                Console.WriteLine("6: Exit Bank");
                Console.Write("Your choice: ");
                var choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1: 
                        bank.AddAccount();
                        break;
                    case 2: 
                        bank.PrintMailingLabels();
                        break;
                    case 3:
                        bank.ListAllAccounts();
                        break;
                    case 4:
                        bank.ListAccount();
                        break;
                    case 5: 
                        bank.AddTranscription();
                    case 6: 
                        Console.WriteLine("Thank you, come again!");
                        break;
                    default:
                        Console.WriteLine("Please select one of the options!");
                        break;
                }
                if (choice == 6)
                {
                    break;
                }
            }
        }
    }
}