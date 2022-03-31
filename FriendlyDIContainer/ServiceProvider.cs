namespace FriendlyDIContainer
{
    public class ServiceProvider
    {
        private readonly Dictionary<Type, Service> _services = new Dictionary<Type, Service>();

        #region public methods

        public void RegisterService<TInterfaceType, TInstanceType>(Func<object>? implementationFactory = null)  
            where TInstanceType : class, TInterfaceType
        {
            RegisterService<TInterfaceType, TInstanceType>(implementationFactory);
        }

        public void RegisterService<TInstanceType>(Func<object>? implementationFactory = null)
            where TInstanceType : class
        {
            RegisterService<TInstanceType, TInstanceType>(implementationFactory);
        }

        public void RegisterSingletonService<TInstanceType>(Func<object>? implementationFactory = null)
            where TInstanceType : class
        {
            RegisterService<TInstanceType, TInstanceType>(true, implementationFactory);
        }

        public void RegisterSingletonService<TInterfaceType, TInstanceType>(Func<object>? implementationFactory = null)
            where TInstanceType : class, TInterfaceType
        {
            RegisterService<TInstanceType, TInstanceType>(true, implementationFactory);
        }

        public TInterface GetRequiredService<TInterface>() 
        {
            var service = _services[typeof(TInterface)];

            if (service.ImplementationFactory is not null) 
                return (TInterface)service.ImplementationFactory();

            var serviceInstance = service.CreateInstance();

            if (serviceInstance is null)
                throw new ArgumentNullException("Failed to create service instance");

            return (TInterface)serviceInstance;
        }

        #endregion public methods

        #region private methods

        private void RegisterService<TInterfaceType, TInstanceType>(bool isSingleton = false,
            Func<object>? implementationFactory = null) where TInstanceType : class, TInterfaceType
        {
            _services.Add(typeof(TInterfaceType),
                          new Service(typeof(TInterfaceType), isSingleton, implementationFactory));
        }

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
            return service.CreateInstance(parameters.ToArray());
        }

        private IEnumerable<object> GetConstructorParameters(Service service)
        {
            var constructorInfo = service.ServiceType.GetConstructors().First();
            return constructorInfo.GetParameters().Select(parameter => ResolveService(parameter.ParameterType));
        }

        #endregion private methods
    }
}
