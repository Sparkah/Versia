using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigeon
{
    public class SoundsRandomizer : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _sounds;
        [SerializeField] private AudioSource _soundsSource;

        public void PlayRandom()
        {
            int r = Random.Range(0, _sounds.Length);
            _soundsSource.clip = _sounds[r];
            _soundsSource.Play();
        }
    }
}