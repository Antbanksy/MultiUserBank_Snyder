using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Snyder
{
    internal class Bank
    {
        public const decimal INITIAL_BALANCE = 10000.00M;

        public static Bank instance = null;
        public decimal bankBalance;

        public Bank()
        {
            bankBalance = INITIAL_BALANCE;
        }

        public static Bank GetInstance()
        {
            if (instance == null)
            {
                instance = new Bank();
            }
            return instance;
        }
        

        public decimal BankBalance
        {
            get { return bankBalance; }
        }

        public bool Login(string username, string password, out decimal balance)
        {
            switch (username)
            {
                case "jlennon":
                    if (password == "johnny")
                    {
                        balance = 1250.00M;
                        return true;
                    }
                    break;
                case "pmccartney":
                    if (password == "pauly")
                    {
                        balance = 2500.00M;
                        return true;
                    }
                    break;
                case "gharrison":
                    if (password == "georgy")
                    {
                        balance = 3000.00M;
                        return true;
                    }
                    break;
                case "rstarr":
                    if (password == "ringoy")
                    {
                        balance = 1000.00M;
                        return true;
                    }
                    break;
            }
            balance = 0.00M;
            return false;
        }
    }

    
    }
                
