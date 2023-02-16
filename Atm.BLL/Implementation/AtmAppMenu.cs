using Atm.BLL.Interfaces;
using Atm.DAL.Database;

using AtmBLL.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.BLL.Implementation
{
    public static class AtmAppMenu
    {

        public static void MainMenuChoice()
        {
            //AtmDB.CreateDatabase();
            
            var atm = new AtmService(new BankAppDBContext());
            Console.WriteLine("Choose an Option");
            Console.WriteLine("1.\t Login As Admin. \n2.\t Login as User\n3.\t Create new Account\n4\t Quit App");
            string Option = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(Option, out int value))
            {



                switch (value)
                {
                    case (int)MainMenu.LoginAdmin:
                        Console.WriteLine("Implementation coming soon");
                        MainMenuChoice();
                        break;
                    case (int)MainMenu.LoginUser:
                        IAuthService authService = new AuthService();
                        authService.Login();
                        Console.WriteLine("Implementation coming soon");
                        MainMenuChoice();
                        break;
                    case (int)MainMenu.CreateAccount:
                        atm.CreateAccount();
                        Console.Clear();
                        MainMenuChoice();
                        // Console.WriteLine("Implementation coming soon");
                        break;
                    case (int)MainMenu.Exit:
                        LogoutProgress();
                        //Console.WriteLine("Implementation coming soon");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Input is incorrect");
                        break;

                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please Insert a valid input");
                MainMenuChoice();
            }
        }
        public static void Welcome()
        {
            // Console.WriteLine("Hello, World!"); 
            Console.Clear();
            Console.Title = "Genesys ATM App";
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\n------ Welcome to Genesys Bank-----\n\n");

            //prompt user to insert card
            Console.WriteLine("Please insert your card");

            // Utility.PressEnterToContinue();
        }
        public  static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("----Welcome to Genesys Bank----");
            Console.WriteLine(":                             :");
            Console.WriteLine("1. Check Balance              :");
            Console.WriteLine("2. Cash Deposit               :");
            Console.WriteLine("3. Withdrawal                 :");
            Console.WriteLine("4. Transfer                   :");
            Console.WriteLine("5. Transactions               :");
            Console.WriteLine("6. Logout                     :");
        }
       
        public static void LogoutProgress()
        {
            Console.WriteLine("Thank you for Banking with us");
            Utility.DisplayDotAnimation();
            Console.Clear();
        }
    }
}
