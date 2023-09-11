using UnityEngine;

namespace Scripts.Logica.Weapon 
{
    public abstract class AbstractWepon : MonoBehaviour
    {
        protected abstract void Shot();
        protected abstract void Rechaege();
        
    }
}

