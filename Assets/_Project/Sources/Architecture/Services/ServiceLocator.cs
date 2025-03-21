using System;
using System.Collections.Generic;

namespace Sources.Architecture.Services
{
    public class ServiceLocator : IServiceLocator
    {
        private static readonly Lazy<ServiceLocator> _instance = new(() => new ServiceLocator());

        public static ServiceLocator Instance => _instance.Value;

        protected Dictionary<Type, IService> _itemsMap { get; private set; }

        public ServiceLocator()
        {
            _itemsMap = new Dictionary<Type, IService>();
        }

        public T Register<T>(T newService) where T : IService
        {
            var type = typeof(T);

            if (_itemsMap.ContainsKey(type))
            {
                throw new Exception($"Cannot add item of type {type}. This type already exists.");
            }

            _itemsMap[type] = newService;

            return newService;
        }

        public void Unregister<T>(T newService) where T : IService
        {
            var type = typeof(T);

            if (_itemsMap.ContainsKey(type))
            {
                _itemsMap.Remove(type);
            }
        }

        public T Get<T>() where T : IService
        {
            var type = typeof(T);

            if (!_itemsMap.TryGetValue(type, out var service))
            {
                throw new Exception($"There is no object with type {type}.");
            }

            return (T)service;
        }
    }
}
