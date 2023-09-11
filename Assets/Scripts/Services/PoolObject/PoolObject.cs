using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Services.PoolObject
{
    public class PoolObject<T> where T: MonoBehaviour
    {
        private T _prefabs;
        public  List<T> _pools { get; private set; }

        public PoolObject(T prefabs, int CoutObjectInPool)
        {
            _prefabs = prefabs;
            _pools = new List<T>();

            for(int i =0; i< CoutObjectInPool; i++)
            {
                var CreatPrefabs = GameObject.Instantiate(_prefabs);
                CreatPrefabs.gameObject.SetActive(false);
                _pools.Add(CreatPrefabs);
            }
        }

        public T Get()
        {
            var obj = _pools.FirstOrDefault(x => !x.isActiveAndEnabled);

            if(obj == null) 
            {
                obj = Creat();
            }
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Releas(T obj )
        {
            obj.gameObject.SetActive(false);
        }

        private T Creat()
        {
            var obj = GameObject.Instantiate(_prefabs);
            _pools.Add(obj);
            return obj;
        }
    }
}

