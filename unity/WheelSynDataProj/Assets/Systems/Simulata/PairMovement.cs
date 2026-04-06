using System;
using Systems.Help;
using UnityEngine;

namespace Systems.Simulata
{
    public class PairMovement : MonoBehaviour
    {
        GameObject _wheelPrefab;
        Rigidbody _rb;
        
        [SerializeField]
        private float _speed = 2;
        
        [SerializeField]
        private Vector3 _direction = new Vector3(0, 0, 1);
        
        public void Initialize(GameObject wheelPrefab)
        {
            _wheelPrefab = wheelPrefab;
            _rb = wheelPrefab.GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {
            if (_wheelPrefab == null) return;
            
            _rb.linearVelocity = _direction.normalized * _speed;
        }
    }
}