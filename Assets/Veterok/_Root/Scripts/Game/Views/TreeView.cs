using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace Veterok.Views
{
    public class TreeView : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        
        [SerializeField] private bool _play;
        
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnValidate()
        {
            if (_play)
                _audioSource.Play();
        }

        public void PlaySound()
        {
            Debug.Log("after If checks");
            if (_audioSource.clip == null) return;
            if (_audioSource.isPlaying) return;
            _audioSource.Play();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
