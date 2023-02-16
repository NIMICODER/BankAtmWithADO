using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Atm.BLL.Interfaces;
using Atm.DAL.Database;

namespace Atm.BLL.Implementation
{
    public class AuthService : IAuthService
    {
        //private readonly BankAppDBContext _dbContext;
        //private bool _disposed;
        //public AuthService(BankAppDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public void Login()
        //{
        //    Console.WriteLine("Enter your card number: ");
        //    string cardNumber = Console.ReadLine();

        //    Console.WriteLine("Enter your PIN: ");
        //    string pin = Console.ReadLine();

        //    SqlConnection sqlConn = _dbContext.OpenConnection();

        //        string query = "SELECT COUNT(*) FROM Customers WHERE card_number = @card_number AND card_pin = @card_pin";
        //        using (SqlCommand command = new SqlCommand(query, sqlConn))
        //        {
        //            command.Parameters.AddWithValue("@card_number", cardNumber);
        //            command.Parameters.AddWithValue("@card_pin", pin);
        //            int result = (int)command.ExecuteScalar();
        //            if (result > 0)
        //            {
        //                Console.WriteLine("Login successful");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Login failed. Invalid card number or PIN.");
        //            }
        //        }
            
        //}

        public void Login()
        {

        }
        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public void ResetPin()
        {
            throw new NotImplementedException();
        }

       

    }
}
