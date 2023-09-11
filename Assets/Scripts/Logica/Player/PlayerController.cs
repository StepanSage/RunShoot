using UnityEngine;

namespace Scripts.Logica
{ 
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbodyPlayer;
        [SerializeField] private float _speed;
        [SerializeField] private float _maxPosition;

        private float MoveX;
             
        void Start()
        {
            if(_rigidbodyPlayer == null)
                _rigidbodyPlayer= GetComponent<Rigidbody>();

            
        }

       
        void Update()
        {
            MoveX= Input.GetAxis("Horizontal");
          
        }
        private void FixedUpdate()
        {
            _rigidbodyPlayer.velocity = new Vector3(MoveX * _speed, 0, 0);

            if (MoveX > 0 && transform.position.x >= _maxPosition)
            {
                _rigidbodyPlayer.velocity = Vector3.zero; 
                transform.position = new Vector3(_maxPosition, transform.position.y, transform.position.z);
                //MoveX = 0; 
            }
            else if (MoveX < 0 && transform.position.x <= -_maxPosition)
            {
                _rigidbodyPlayer.velocity = Vector3.zero; 
                transform.position = new Vector3(-_maxPosition, transform.position.y, transform.position.z);
                //MoveX = 0; 
            }
        }
    }
}

