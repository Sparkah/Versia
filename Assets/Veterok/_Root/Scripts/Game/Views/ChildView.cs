using System;
using System.Collections;
using UnityEngine;

namespace Veterok.Views
{
    public class ChildView : MonoBehaviour
    {
        [SerializeField] private float _timeDelay;
        [SerializeField] private AudioSource _audioSource;
        private float _firstPlay;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            _firstPlay += Time.deltaTime;
            if(_firstPlay >= _timeDelay)
                PlaySound();
        }

        private void PlaySound()
        {
            _audioSource.Play();
            _firstPlay = 0;
        }
        
    }
}