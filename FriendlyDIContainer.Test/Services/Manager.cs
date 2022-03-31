using FriendlyDIContainer.Test.Interfaces;

namespace FriendlyDIContainer.Test.Services
{
    internal class Manager
    {
        private readonly IRepository _repository;
        private readonly INotifier _notifier;
        private readonly ILogger _logger;
        private readonly ISerializer _serializer;

        public Manager(IRepository repository, INotifier notifier, ILogger logger, ISerializer serializer)
        {
            _repository = repository;
            _notifier = notifier;
            _logger = logger;
            _serializer = serializer;
        }

        public void Run() 
        {
            _logger.Info("Start");
            _serializer.Deserialize();
            _repository.GetData();
            _notifier.Notify("Send notification");
            _serializer.Serialize();
            _logger.Info("End");
        }
    }
}
