using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Ammo : MonoBehaviour
    {
        [SerializeField] float _speed;
        void Update()
        {
            transform.Translate(transform.forward * _speed);
        }
    }   


