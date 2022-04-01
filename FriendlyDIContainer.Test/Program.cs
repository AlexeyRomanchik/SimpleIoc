using FriendlyDIContainer;
using FriendlyDIContainer.Test.Interfaces;
using FriendlyDIContainer.Test.Services;

var serviceProvider = new ServiceProvider();

serviceProvider.RegisterService<ILogger, Logger>();
serviceProvider.RegisterService<IDbConnector, DbConnector>(() => new DbConnector("localhost\\Sql"));
serviceProvider.RegisterService<IRepository, Repository>();
serviceProvider.RegisterService<INotifier, Notifier>();
serviceProvider.RegisterService<ISerializer, Serializer>();
serviceProvider.RegisterService<Manager>();

var manager = serviceProvider.GetRequiredService<Manager>();

manager.Run();