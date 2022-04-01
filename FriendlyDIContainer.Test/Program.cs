using FriendlyDIContainer;
using FriendlyDIContainer.Test.Interfaces;
using FriendlyDIContainer.Test.Services;

var serviceProvider = new ServiceProvider();

serviceProvider.RegisterService<ILogger, Logger>()
    .RegisterService<IDbConnector, DbConnector>(() => new DbConnector("localhost\\Sql"))
    .RegisterService<IRepository, Repository>()
    .RegisterSingletonService<INotifier, Notifier>()
    .RegisterService<ISerializer, Serializer>()
    .RegisterService<Manager>();

var manager = serviceProvider.GetRequiredService<Manager>();

manager.Run();