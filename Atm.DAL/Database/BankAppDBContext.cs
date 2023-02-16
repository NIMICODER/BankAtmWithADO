using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Atm.DAL.Database
{
    public class BankAppDBContext : IDisposable
    {
        private readonly string _connString;

        private SqlConnection _dbConnection = null;

        public BankAppDBContext() : this(@"Data Source=DESKTOP-L9HB1OU\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        public BankAppDBContext(string connString)
        {
            _connString = connString;

        }


        public SqlConnection OpenConnection()
        {
            _dbConnection = new SqlConnection(_connString);
            _dbConnection.Open();
            return _dbConnection;
        }

        public void CloseConnection()
        {
            if (_dbConnection?.State != System.Data.ConnectionState.Closed)
            {
                _dbConnection?.Close();
            }
        }

        bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _dbConnection.Dispose();
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
