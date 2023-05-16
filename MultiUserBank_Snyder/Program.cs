// Anthony Snyder
// IT112
// NOTES: Hope this is alright
// BEHAVIORS NOT IMPLIMENTED AND WHY: none that i know of!
namespace MultiUserBank_Snyder
{
    internal class Program
    {
        private static decimal bankBalance;

        static void Main(string[] args)
        {
            Bank bank = Bank.GetInstance();
            decimal balance;

            while (true)
            {
                Console.WriteLine("Welcome to the bank. Please select an option:");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Exit");

                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    if (bank.Login(username, password, out balance))
                    {
                        Console.WriteLine("Logged in as" + username +  "Balance: $" + balance);

                        while (true)
                        {
                            Console.WriteLine("Please select an option:");
                            Console.WriteLine("1. Check balance");
                            Console.WriteLine("2. Deposit");
                            Console.WriteLine("3. Withdraw");
                            Console.WriteLine("4. Log out");

                            string selection = Console.ReadLine();

                            if (selection == "1")
                            {
                                Console.WriteLine("Current balance: $" + balance);
                            }
                            else if (selection == "2")
                            {
                                Console.Write("Amount to deposit: ");
                                decimal amount = decimal.Parse(Console.ReadLine());
                                balance += amount;
                                Console.WriteLine("New balance: $" + balance);
                            }
                            else if (selection == "3")
                            {
                                Console.Write("Amount to withdraw: ");
                                decimal amount = decimal.Parse(Console.ReadLine());

                                if (amount > 500.00M)
                                {
                                    Console.WriteLine("Withdrawals of greater than 500 at one time are not allowed.");
                                    continue;
                                }

                                if (amount > balance)
                                {
                                    Console.WriteLine("Insufficient funds. Withdrawal limited to &" + balance);
                                    balance = 0.00M;
                                }
                                else
                                {
                                    balance -= amount;
                                    Console.WriteLine($"New balance: {balance:C}");
                                }
                            }
                            else if (selection == "4")
                            {
                                Console.WriteLine($"Logging out "+ username + "Balance: " + balance);
                                bankBalance += balance;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection. Please try again.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Username or Password, please try again.");


                    }
                }
            }
        }
    }
}
