using UnityEngine;
using Scripts.Services.PoolObject;
using Unity.VisualScripting;


namespace Scripts.Logica.Weapon 
{
    public class Gun : AbstractWepon
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private int CountAmmo;

        private PoolObject<Ammo> _poolObject;

        private Ammo _prefabsAmmo;

        private void Start()
        {
            var _prefabs = Resources.Load("AmmoPrefabs/Ammo");
            _prefabsAmmo = _prefabs.GetComponent<Ammo>();
        
            _poolObject = new PoolObject<Ammo>(_prefabsAmmo, CountAmmo);
        }


        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Shot();
            }
        }

        protected override void Rechaege()
        {
            throw new System.NotImplementedException();
        }

        protected override void Shot()
        {
            var Ammo = _poolObject.Get();
            Ammo.transform.position = _shootPoint.position;
        }
    }
}

