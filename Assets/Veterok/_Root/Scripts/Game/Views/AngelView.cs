using System;
using UnityEngine;

namespace Veterok.Views
{
    public class AngelView : MonoBehaviour
    {
        public event Action<AngelView> AngelFadeOut;
        [SerializeField] private float _timeTofade;
        [SerializeField] private ParticleSystem _particleSystem;
        private float _startTime = 0;

        public ParticleSystem Particle => _particleSystem;
        
        public float StartTime => _startTime;
        public float TimeToFade => _timeTofade;

        private void Awake()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }
    }
}