using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Services.EventBus.EvetBis
{
    public class EventBus 
    {
        private Dictionary<string, List<object>> _eventBus = new Dictionary<string, List<object>>();
        public static EventBus Current;

        private static void Initalization()
        {
            Current = new EventBus();
        }

        public void Register<T>(Action<T> registerEvent)
        {
            string key = typeof(T).Name;
            if (_eventBus.ContainsKey(key))
            {
                _eventBus[key].Add(registerEvent);
            }
            else
            {
                _eventBus.Add(key, new List<object>() { registerEvent});
            }
        }

        public void Unregister<T>(Action<T> unRegister) 
        { 
            string key = typeof(T).Name;
            if (!_eventBus.ContainsKey(key))
            {
                _eventBus.Remove(key);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }


        public void Invoke<T>(T invoke)
        {
            string key = typeof(T).Name;
            if(_eventBus.ContainsKey(key))
            {
                foreach(var item in _eventBus[key]) 
                {
                    var callback = item as Action<T>;
                    callback?.Invoke(invoke);
                }
            }

        }
    }
}


