using Atm.BLL;
using Atm.BLL.Interfaces;
using System.Data.SqlClient;
using System;
using Atm.DAL.Database;
using System.Net.NetworkInformation;

namespace AtmBLL.Implementation
{

    public class AtmService : IAtmService
    {
        private ATM _atm;
        private readonly IAdminService _adminService;
        private readonly BankAppDBContext _dbContext;
        private bool _disposed; 
        public AtmService(BankAppDBContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public void Start()
        {
            CreateAccount();
        }
        public  void CreateAccount()
        {
            try
            {
                // ask for user input

                Console.WriteLine("Enter your first name: ");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter your last name: ");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter your account type: ");
                string accountType = Console.ReadLine();

                Console.WriteLine("Enter your email: ");
                string email = Console.ReadLine();

                Console.WriteLine("Enter your phone number: ");
                string phoneNumber = Console.ReadLine();

                Console.WriteLine("Enter your address: ");
                string address = Console.ReadLine();


                // Generate random card number, account number, and PIN
                Random rand = new Random();
                string cardNumber = "";
                for (int i = 0; i < 16; i++)
                {
                    cardNumber += rand.Next(0, 10).ToString();
                }
                string accountNumber = "";
                for (int i = 0; i < 10; i++)
                {
                    accountNumber += rand.Next(0, 10).ToString();
                }
                string cardPin = rand.Next(1000, 9999).ToString();

                string connectionString = @"Data Source=DESKTOP-L9HB1OU\SQLEXPRESS;Integrated Security=True;Initial Catalog=BankAtmDB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                // insert the user details into the database
                string insertSql = $"INSERT INTO Users ( FirstName, LastName,  AccountNumber, AccountType, Email, PhoneNumber, CardNumber, CardPin, Address )" +
                    $" VALUES (@FirstName, @LastName, @AccountNumber, @AccountType, @email, @PhoneNumber,  @CardNumber, @CardPin, @Address )";
                SqlCommand insertCommand = new SqlCommand(insertSql, connection);
                insertCommand.Parameters.AddWithValue("@FirstName", firstName);
                insertCommand.Parameters.AddWithValue("@LastName", lastName);
                insertCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                insertCommand.Parameters.AddWithValue("@AccountType", accountType);
                insertCommand.Parameters.AddWithValue("@Email", email);
                insertCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                insertCommand.Parameters.AddWithValue("@CardNumber", cardNumber);
                insertCommand.Parameters.AddWithValue("@CardPin", cardPin);
                insertCommand.Parameters.AddWithValue("@Address", address);
                insertCommand.ExecuteNonQuery();

                // close the connection
                connection.Close();

                Console.WriteLine("Your account has been created");

                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void PayBill()
        {

        }

        public void ReloadCash()
        {

        }

        

        public void Withdraw()
        {
            throw new NotImplementedException();
        }

        public void CheckBalance()
        {
            throw new NotImplementedException();
        }

        public void Transfer()
        {
            throw new NotImplementedException();
        }

        public void Deposit()
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
