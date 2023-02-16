using Atm.BLL.Interfaces;
using Atm.DAL.Database;
using Atm.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atm.BLL.Implementation
{
    public static class Application
    {
        //public static void MainMenuChoice()
        //{
        //    //AtmDB.CreateDatabase();
        //    BankAppDB
        //    var atm = new AtmService(new BankAppDBContext());
        //    Console.WriteLine("Choose an Option");
        //    Console.WriteLine("1.\t Login As Admin. \n2.\t Login as User\n3.\t Create new Account\n4\t Quit App");
        //    string Option = Console.ReadLine() ?? string.Empty;
        //    if (int.TryParse(Option, out int value))
        //    {



        //        switch (value)
        //        {
        //            case (int)MainMenu.LoginAdmin:
        //                Console.WriteLine("Implementation coming soon");
        //                break;
        //            case (int)MainMenu.LoginUser:
        //                IAuthService authService = new AuthService();
        //                authService.Login();
        //                //Console.WriteLine("Implementation coming soon");
        //                break;
        //            case (int)MainMenu.CreateAccount:

        //                atm.CreateAccount();
        //                // Console.WriteLine("Implementation coming soon");
        //                break;
        //            case (int)MainMenu.Logout:
        //                Console.WriteLine("Implementation coming soon");
        //                break;
        //            default:
        //                Console.Clear();
        //                Console.WriteLine("Input is incorrect");
        //                break;

        //        }

        //    }
        //}
    }
}
