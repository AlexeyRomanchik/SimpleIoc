using FriendlyDIContainer.Test.Interfaces;

namespace FriendlyDIContainer.Test.Services
{
    internal class Notifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
