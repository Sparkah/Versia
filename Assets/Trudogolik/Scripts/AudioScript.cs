using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    [RequireComponent(typeof(Collider))]
    public class AudioScript : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MainCamera"))
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }
}