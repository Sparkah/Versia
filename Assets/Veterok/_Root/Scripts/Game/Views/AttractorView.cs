using System;
using UnityEngine;

namespace Veterok.Views
{
    public class AttractorView : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _lifeTime;
        private float _startTime = 0;
        
        public Transform Target { get; set; }

        public float StartTime => _startTime;
        public float LifeTime => _lifeTime;

        private void Start()
        {
            _startTime = 0;
        }

        private void Update()
        {
            _startTime += Time.deltaTime;
            Move(Time.deltaTime);
        }

        public void Move(float deltaTime)
        {
            transform.localPosition += Vector3.forward * _moveSpeed;
        }
        
    }
}