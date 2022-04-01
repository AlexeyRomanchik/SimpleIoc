using System.Reflection;

namespace FriendlyDIContainer
{
    public class ServiceProvider
    {
        private readonly Dictionary<Type, Service> _services = new Dictionary<Type, Service>();

        #region public methods

        public TInterface GetRequiredService<TInterface>() 
        {
            var serviceInstance =  ResolveService(typeof(TInterface));

            return (TInterface)serviceInstance;
        }

        internal void RegisterService<TInterfaceType, TInstanceType>(bool isSingleton = false,
            Func<object>? implementationFactory = null) where TInstanceType : class, TInterfaceType
        {
            _services.Add(typeof(TInterfaceType),
                          new Service(typeof(TInstanceType), isSingleton, implementationFactory));
        }

        #endregion public methods

        #region private methods

        private object ResolveService(Type type) 
        {
            var service = _services[type];

            if (service is null)
                throw new ArgumentNullException("Service not registered");

            if (service.ImplementationFactory is not null)
                return service.ImplementationFactory();

            return GetInstance(service);
        }

        private object GetInstance(Service service) 
        {
            var parameters =  GetConstructorParameters(service);
            return service.CreateInstance(parameters?.ToArray());
        }

        private IEnumerable<object>? GetConstructorParameters(Service service)
        {
            var constructorsInfo = service.ServiceType.GetConstructors();

            ConstructorInfo constructorInfo;

            if (constructorsInfo.Length > 0)
                constructorInfo = constructorsInfo.First();
            else
                return null;

            return constructorInfo.GetParameters().Select(parameter => ResolveService(parameter.ParameterType));
        }

        #endregion private methods
    }
}
