using Atm.BLL.Interfaces;
using Atm.DAL.Database;
using Atm.DAL.Enums;
using AtmBLL.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.BLL.Implementation
{
    public static class ApplicationMenu
    {
        public static void Application()
        {
            IAtmService atmServices = new AtmService(new BankAppDBContext());
            Console.WriteLine("Choose an Option");
            Console.WriteLine("1.\t Check Balance \n2.\t Make Deposit \n3.\t Make Withdrawal \n4\t Make Transfer \n5\t View Transaction History \n6\t Logout ");
            string Option = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(Option, out int value))
            {



                switch (value)
                {
                    case (int)BankAppMenu.CheckBalance:
                        //atmServices.CheckBalance();
                        Console.Clear();
                        Console.WriteLine("Implementation coming soon");
                        Application();
                        break;
                    case (int)BankAppMenu.MakeDeposit:
                        //atmServices.Deposit();
                        Console.Clear();
                        Console.WriteLine("Implementation coming soon");
                        Application();
                        break;
                    case (int)BankAppMenu.MakeWithdrawal:
                        //atmServices.Withdraw();
                        Console.Clear();
                        Console.WriteLine("Implementation coming soon");
                        Application();
                        break;
                    case (int)BankAppMenu.ViewTransactionHistory:
                        Console.Clear();
                        Console.WriteLine("Implementation coming soon");
                        Application();
                        break;
                    case (int)BankAppMenu.Logout:
                        LogoutProgress();
                        AtmAppMenu.MainMenuChoice();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Input is incorrect");
                        Application();
                        break;

                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please Insert a valid input");
                Application();
            }
        }

        public static void LogoutProgress()
        {
            Console.WriteLine("Logged out successfully...");
            Utility.DisplayDotAnimation();
            Console.Clear();
        }
    }
}
