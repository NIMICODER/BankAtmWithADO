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
    }
}
