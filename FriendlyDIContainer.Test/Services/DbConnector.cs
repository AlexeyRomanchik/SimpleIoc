using FriendlyDIContainer.Test.Interfaces;

namespace FriendlyDIContainer.Test.Services
{
    internal class DbConnector : IDbConnector
    {
        private readonly string _connectionString;

        public DbConnector(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            Console.WriteLine($"Сonnect to db by string {_connectionString}");
        }
    }
}
