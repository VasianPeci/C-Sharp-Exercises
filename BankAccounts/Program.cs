using System.Linq;
using System.Security.Principal;

namespace BankAccounts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            BankAccount account = null;

            int response = 0;
            bool isValid = false;

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Hello, this is a list of commands to manage your bank accounts!");
            Console.WriteLine("-----------------------------------------------------------------");

            if (accounts.Count == 0)
            {
                AddAccount(isValid, account, accounts);
            }

            do
            {
                Console.WriteLine("\nChoose a command below:");
                Console.WriteLine("1 - Add Account");
                Console.WriteLine("2 - Remove Account");
                Console.WriteLine("3 - Deposit");
                Console.WriteLine("4 - Withdraw");
                Console.WriteLine("5 - Account Balance");
                Console.WriteLine("6 - Exit");

                isValid = int.TryParse(Console.ReadLine(), out response);

                if (!isValid || !(response >= 1 && response <= 6))
                {
                    Console.WriteLine("\nYou must choose a command w numbers 1 to 6!");
                    continue;
                }

                switch (response)
                {
                    case 1:
                        AddAccount(isValid, account, accounts);

                        break;

                    case 2:
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("\nYou have not created any accounts yet!");
                            break;
                        }

                        isValid = false;
                        // Account Number
                        do
                        {
                            Console.WriteLine("\nWrite a 6-character combination of digits and letters for the bank account to be removed:");
                            string accNumber = Console.ReadLine();

                            if (accNumber.ToLower() == "q") break;

                            if (!IsValidInput(accNumber))
                            {
                                Console.WriteLine("\nAccount Number must be valid!");
                                continue;
                            }
                            if (!HasAccount(accNumber, accounts))
                            {
                                Console.WriteLine("\nYou do not own an account with this number. Write another one!");
                                continue;
                            }

                            RemoveAccount(accounts, accNumber);

                            Console.WriteLine("\nAccount successfully removed!");
                            isValid = true;
                        } while (!isValid);

                        break;

                    case 3:
                        int amount;

                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("\nYou have not created any accounts yet!");
                            break;
                        }

                        // Amount
                        Console.WriteLine("\nEnter the amount to deposit:");
                        do
                        {
                            string res = Console.ReadLine();
                            isValid = int.TryParse(res, out amount);

                            if (res.ToLower() == "q") break;

                            if (!isValid || amount <= 0)
                            {
                                Console.WriteLine("\nYou must input an amount larger than 0!");
                                continue;
                            }
                        } while (!isValid);


                        accounts[accounts.Count - 1].deposit(amount);

                        break;

                    case 4:
                        amount = -1;

                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("\nYou have not created any accounts yet!");
                            break;
                        }

                        // Amount
                        Console.WriteLine("\nEnter the amount to withdraw:");
                        do
                        {
                            string res = Console.ReadLine();
                            isValid = int.TryParse(res, out amount);

                            if (res.ToLower() == "q") break;

                            if (!isValid || amount <= 0)
                            {
                                Console.WriteLine("\nYou must input an amount larger than 0!");
                                continue;
                            }
                        } while (!isValid);


                        bool validWithdraw = accounts[accounts.Count - 1].withdraw(amount);

                        if (validWithdraw)
                        {
                            Console.WriteLine("\nWithdraw successful!");
                        } else
                        {
                            Console.WriteLine("\nWithdraw not successful, not enough balance!");
                        }

                        break;

                    case 5:
                        if (accounts.Count == 0)
                        {
                            Console.WriteLine("\nYou have not created any accounts yet!");
                            break;
                        }

                        Console.WriteLine("\nYour account balance is: " + accounts[accounts.Count - 1].balance + " " + accounts[accounts.Count - 1].Currency);

                        break;

                    case 6:
                        Console.WriteLine("\nYou chose to exit the system. Bye!");
                        return;
                }
            } while (!isValid || response != 6);

            return;
        }

        public static bool IsValidInput(string input)
        {
            return input.Length == 6 && !string.IsNullOrEmpty(input) && input.All(char.IsLetterOrDigit);
        }

        public static bool Exists(string input)
        {
            foreach (string accNumber in BankAccount.AccNumbers)
            {
                if (input.ToUpper() == accNumber) return true;
            }

            return false;
        }

        public static bool HasAccount(string input, List<BankAccount> accounts)
        {
            foreach (BankAccount account in accounts)
            {
                if (input.ToUpper() == account.AccNumber) return true;
            }

            return false;
        }

        public static void RemoveAccount(List<BankAccount> accounts, string accNumber)
        {
            int i = 0;
            foreach (BankAccount account in accounts)
            {
                if (accNumber.ToUpper() == account.AccNumber)
                {
                    accounts.RemoveAt(i);
                    break;
                }
                i++;
            }

            i = 0;
            foreach (string accountNumber in BankAccount.AccNumbers)
            {
                if (accNumber.ToUpper() == accountNumber)
                {
                    BankAccount.AccNumbers.RemoveAt(i);
                    break;
                }
                i++;
            }
        }

        public static void AddAccount(bool isValid, BankAccount account, List<BankAccount> accounts)
        {
            string accNumber;
            string accName;
            int currency;

            isValid = false;
            // Account Number
            do
            {
                Console.WriteLine("\nWrite a 6-character combination of digits and letters for your new bank account:");
                accNumber = Console.ReadLine();

                if (accNumber.ToLower() == "q") break;

                if (!IsValidInput(accNumber))
                {
                    Console.WriteLine("\nAccount Number must be valid!");
                    continue;
                }
                if (Exists(accNumber))
                {
                    Console.WriteLine("\nThis Account Number exists. Write another one!");
                    continue;
                }

                isValid = true;
            } while (!isValid);

            isValid = false;
            // Account Name
            do
            {
                Console.WriteLine("\nWrite the name of your bank account:");
                accName = Console.ReadLine();

                if (accName.ToLower() == "q") break;

                if (string.IsNullOrEmpty(accName))
                {
                    Console.WriteLine("\nName must not be empty!");
                    continue;
                }

                isValid = true;
            } while (!isValid);

            isValid = false;
            // Currency
            do
            {
                Console.WriteLine("\nChoose one of these four currencies for your bank account.");
                Console.WriteLine("1 - Lek");
                Console.WriteLine("2 - Dollar");
                Console.WriteLine("3 - Euro");
                Console.WriteLine("4 - Pound");

                string res = Console.ReadLine();
                isValid = int.TryParse(res, out currency);

                if (res.ToLower() == "q") break;

                if (!isValid || !(currency >= 1 && currency <= 4))
                {
                    Console.WriteLine("\nYou must input a currency from 1 to 4!");
                    continue;
                }

                isValid = true;
            } while (!isValid || !(currency >= 1 && currency <= 4));

            account = new BankAccount(accNumber.ToUpper(), accName, currency);
            accounts.Add(account);
        }
    }
}
