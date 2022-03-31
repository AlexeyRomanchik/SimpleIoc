namespace FriendlyDIContainer
{
    internal class Service
    {
        private readonly bool _isSingleton;

        public Type ServiceType { get; }
        public object? SingletonInstance { get; private set; }
        public Func<object>? ImplementationFactory { get; }

        public Service(Type serviceType, bool isSingleton = false, Func<object>? implementationFactory = null) 
        {
            _isSingleton = isSingleton;
            ServiceType = serviceType;
            ImplementationFactory = implementationFactory;
        }

        public object CreateInstance(params object[] parameters) 
        {
            if (_isSingleton) 
            {
                SingletonInstance = Activator.CreateInstance(ServiceType, parameters);

                if (SingletonInstance is null)
                    throw new ArgumentNullException("Failed to create service instance");

                return SingletonInstance;
            }

            return Activator.CreateInstance(ServiceType, parameters);
        }
    }
}
