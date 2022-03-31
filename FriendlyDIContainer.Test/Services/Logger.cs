using FriendlyDIContainer.Test.Interfaces;

namespace FriendlyDIContainer.Test.Services
{
    internal class Logger : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}
