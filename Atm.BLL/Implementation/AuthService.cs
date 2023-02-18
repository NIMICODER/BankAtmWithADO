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
        private readonly BankAppDBContext _dbContext;
        private bool _disposed;
        public AuthService(BankAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Login()
        { 
            
                Console.WriteLine("Enter your card number: ");
                string cardNumber = Console.ReadLine();

                Console.WriteLine("Enter your PIN: ");
                string cardPin = Console.ReadLine();
                bool isValid = false;
                Console.Clear();

                //SqlConnection sqlConn = _dbContext.OpenConnection();
                string connectionString = @"Data Source=DESKTOP-L9HB1OU\SQLEXPRESS;Integrated Security=True;Initial Catalog=BankAtmDB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();


                string query = "SELECT COUNT(*) FROM Users WHERE CardNumber = @CardNumber AND CardPin = @CardPin";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {

                    
                        command.Parameters.AddWithValue("@CardNumber", cardNumber);
                        command.Parameters.AddWithValue("@CardPin", cardPin);
                        int result = (int)command.ExecuteScalar();

                        if (result > 0)
                        {
                            Console.WriteLine("Login successful");
                            ApplicationMenu.Application();
                        }

                    } catch(Exception)
                    {
                        Console.WriteLine("Login failed");
                    } finally
                    {
                        connection.Close();
                    }
                    if(isValid)
                    {
                        Console.WriteLine("Login successful");
                        Console.Clear() ;
                        ApplicationMenu.Application();
                    }
                    else
                    {
                        Console.WriteLine("");
                        Login();
                    }
                }
               // _dbContext.CloseConnection();

               

        }

        //public void LoginB()
        //{

        //}
        //public void Login()
        //{
        //    Console.WriteLine("Enter your card number: ");
        //    string cardNumber = Console.ReadLine();

        //    Console.WriteLine("Enter your PIN: ");
        //    string pin = Console.ReadLine();

        //    // Query the database to check if the entered card number and PIN match a record in the database
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT COUNT(*) FROM Customers WHERE CardNumber = @CardNumber AND PIN = @PIN";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@CardNumber", cardNumber);
        //            command.Parameters.AddWithValue("@PIN", pin);
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
        //    }
        //}
        public void LogOut()
        {
            throw new NotImplementedException();
        }

        public void ResetPin()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {

            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
