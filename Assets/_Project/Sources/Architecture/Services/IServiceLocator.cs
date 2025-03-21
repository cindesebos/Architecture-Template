namespace Sources.Architecture.Services
{
    public interface IServiceLocator
    {
        static ServiceLocator Instance;

        T Register<T>(T newService) where T : IService;

        void Unregister<T>(T newService) where T : IService;

        T Get<T>() where T : IService;
    }
}
