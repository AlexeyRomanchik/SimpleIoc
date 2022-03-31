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

        #endregion public methods

        private void RegisterService<TInterfaceType, TInstanceType>(bool isSingleton = false,
            Func<object>? implementationFactory = null) where TInstanceType : class, TInterfaceType
        {
            _services.Add(typeof(TInterfaceType),
                          new Service(typeof(TInterfaceType), isSingleton, implementationFactory));
        }
    }
}
