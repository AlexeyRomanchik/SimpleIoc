namespace FriendlyDIContainer
{
    public static class ServiceProviderExtension
    {
        public static ServiceProvider RegisterService<TInterfaceType, TInstanceType>(this ServiceProvider serviceProvider, 
            Func<object>? implementationFactory = null)
            where TInstanceType : class, TInterfaceType
        {
            serviceProvider.RegisterService<TInterfaceType, TInstanceType>(false, implementationFactory);
            return serviceProvider;
        }

        public static ServiceProvider RegisterService<TInstanceType>(this ServiceProvider serviceProvider, 
            Func<object>? implementationFactory = null)
            where TInstanceType : class
        {
            serviceProvider.RegisterService<TInstanceType, TInstanceType>(false, implementationFactory);
            return serviceProvider;
        }

        public static ServiceProvider RegisterSingletonService<TInstanceType>(this ServiceProvider serviceProvider, 
            Func<object>? implementationFactory = null)
            where TInstanceType : class
        {
            serviceProvider.RegisterService<TInstanceType, TInstanceType>(true, implementationFactory);
            return serviceProvider;
        }

        public static ServiceProvider RegisterSingletonService<TInterfaceType, TInstanceType>(this ServiceProvider serviceProvider, 
            Func<object>? implementationFactory = null)
            where TInstanceType : class, TInterfaceType
        {
            serviceProvider.RegisterService<TInstanceType, TInstanceType>(true, implementationFactory);
            return serviceProvider;
        }
    }
}
