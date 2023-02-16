using System;
using System.Data.SqlClient;

namespace Atm.DAL.Database
{
    public class BankAppDB
    {
        private readonly BankAppDBContext _dbContext;
        private bool _disposed;
        public BankAppDB()
        {

        }

        public BankAppDB(BankAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateDatabase()
        {
            // string serverName = "DESKTOP-L9HB1OU\\SQLEXPRESS";
            string databaseName = "BankAtmDB";
            string connectionString = $"Data Source=DESKTOP-L9HB1OU\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string createDatabaseSql = $"CREATE DATABASE {databaseName}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the database already exists
                bool databaseExists;
                using (SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM sys.databases WHERE name = '{databaseName}'", connection))
                {
                    int count = (int)command.ExecuteScalar();
                    databaseExists = count > 0;
                }

                // Create the database if it does not exist
                if (!databaseExists)
                {
                    using (SqlCommand command = new SqlCommand(createDatabaseSql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Database created successfully.");
                }
                else
                {
                    Console.WriteLine("Database already exists.");
                }
            }
        }

        public void CreateTable()
        {
            // Connection string for the SQL Server database
            string connectionString = "Data Source=DESKTOP-L9HB1OU\\SQLEXPRESS;Integrated Security=True;Initial Catalog=BankAtmDB;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            // SQL command to check if the table exists
            string checkCustomersTable = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
                                     WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Users';";
            string checkAccountsTable = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
                                     WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Accounts';";
            string checkTransactionsTable = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
                                     WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Transactions';";
            string checkAdminTable = @"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES 
                                     WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Admin';";

            // SQL command to create a new table
            string CustomersTable = @"CREATE TABLE Users (
                                        User_id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                                        FirstName VARCHAR(50) NOT NULL,
                                        LastName VARCHAR(50) NOT NULL,
                                        AccountNumber VARCHAR(10) NOT NULL UNIQUE,
                                        AccountType VARCHAR(20) NOT NULL,
                                        Email VARCHAR(100) NOT NULL UNIQUE,
                                        PhoneNumber VARCHAR(14) NOT NULL UNIQUE,
                                        CardNumber VARCHAR(16) NOT NULL UNIQUE,
                                        CardPin VARCHAR(4) NOT NULL UNIQUE,
                                        Balance DECIMAL(18, 2) NULL,
                                        Address VARCHAR(100) NULL
                                    );";
            string AccountsTable = @"CREATE TABLE Accounts (
                                        account_id INT IDENTITY(1,1) PRIMARY KEY,
                                        account_number INT NOT NULL UNIQUE, 
                                        account_type VARCHAR(10) NOT NULL, 
                                        balance DECIMAL(18,2) NOT NULL, 
                                        customer_id INT NOT NULL
                                        
                                    );";
            string TransactionsTable = @"CREATE TABLE Transactions (
                                        transaction_id INT IDENTITY(1,1) PRIMARY KEY, 
                                        account_id INT NOT NULL, 
                                        transaction_date DATETIME NULL, 
                                        transaction_type VARCHAR(10) NULL, 
                                        amount DECIMAL(18,2) NULL 
                                       
                                    );";
            string AdminTable = @"CREATE TABLE Admin (
                                        admin_id INT IDENTITY(1,1), 
                                        username varchar(50), 
                                        password varchar(50)
                                    );";

            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SQL command to check if the table exists
                using (SqlCommand command1 = new SqlCommand(checkCustomersTable, connection))
                using (SqlCommand command2 = new SqlCommand(checkAccountsTable, connection))
                using (SqlCommand command3 = new SqlCommand(checkTransactionsTable, connection))
                using (SqlCommand command4 = new SqlCommand(checkAdminTable, connection))
                {
                    // Execute the SQL command to check if the table exists
                    int count1 = (int)command1.ExecuteScalar();
                    int count2 = (int)command2.ExecuteScalar();
                    int count3 = (int)command3.ExecuteScalar();
                    int count4 = (int)command4.ExecuteScalar();

                    // If the table does not exist, create it
                    if (count1 == 0)
                    {
                        // Create a SQL command to create the table
                        using (SqlCommand CustomersCommand = new SqlCommand(CustomersTable, connection))
                        {
                            // Execute the SQL command to create the table
                            int result1 = CustomersCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {

                    }
                    if (count2 == 0)
                    {
                        using (SqlCommand AccountsCommand = new SqlCommand(AccountsTable, connection))
                        {
                            int result2 = AccountsCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {

                    }
                    if (count2 == 0)
                    {
                        using (SqlCommand TransactionsCommand = new SqlCommand(TransactionsTable, connection))
                        {
                            int result3 = TransactionsCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {

                    }
                    if (count2 == 0)
                    {
                        using (SqlCommand AdminCommand = new SqlCommand(AdminTable, connection))
                        {
                            int result4 = AdminCommand.ExecuteNonQuery();
                            Console.WriteLine("Tables created successfully!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Tables already exists! Continue to ATM Operations");
                    }

                }
            }
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
