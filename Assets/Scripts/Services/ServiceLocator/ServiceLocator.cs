using System;
using System.Collections.Generic;


namespace Scripts.Services.ServiceLocator 
{
    public class ServiceLocator 
    {
        private Dictionary<string, IService> _service = new Dictionary<string, IService>();

        public static ServiceLocator Current;

        public static  void Initialization()
        {
            Current  = new ServiceLocator();
        }

        public T Get<T>() where T : IService
        {
            string key = typeof(T).Name;

            if (!_service.ContainsKey(key))
            {
                throw new InvalidOperationException();
            }

            return(T)_service[key];
        }

        public void Registration<T>(T Service) where T : IService
        {
            string key = typeof(T).Name;

            if(_service.ContainsKey(key))
            {
                return;
            }

            _service.Add(key, Service);
        }

        public void UnRegistration<T>() where T : IService
        {
            string key = typeof(T).Name;

            if (!_service.ContainsKey(key)) 
            {
                return;
            }

            _service.Remove(key);              
        }
    }

}

