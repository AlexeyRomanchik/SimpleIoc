using FriendlyDIContainer.Test.Interfaces;

namespace FriendlyDIContainer.Test.Services
{
    internal class Repository : IRepository
    {
        private readonly IDbConnector _dbConnector;
        public Repository(IDbConnector dbConnector) 
        {
            _dbConnector = dbConnector;
        }
        public void GetData()
        {
            _dbConnector.Connect();
            Console.WriteLine("Get data from DB");
        }
    }
}
