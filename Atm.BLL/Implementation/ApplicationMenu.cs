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
            Console.WriteLine("1.\t Login As Admin. \n2.\t Login as User\n3.\t Create new Account\n4\t Quit App");
            string Option = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(Option, out int value))
            {



                switch (value)
                {
                    case (int)BankAppMenu.CheckBalance:
                        atmServices.CheckBalance();
                        Console.WriteLine("Implementation coming soon");
                        Application();
                        break;
                    case (int)BankAppMenu.MakeDeposit:
                        atmServices.Deposit();
                        Console.WriteLine("Implementation coming soon");
                        Application();
                        break;
                    case (int)BankAppMenu.MakeWithdrawal:
                        atmServices.Withdraw();
                        Console.Clear();
                        Console.WriteLine("Implementation coming soon");
                        Application();
                        break;
                    case (int)BankAppMenu.ViewTransactionHistory:
                        Console.WriteLine("Implementation coming soon");
                        break;
                    case (int)BankAppMenu.Logout:
                        LogoutProgress();
                        Application();
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
