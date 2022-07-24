using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigeon
{
    public class StartingSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource _throwSound;
        [SerializeField] private AudioSource _trashSound;


        void Start()
        {
            StartCoroutine(ThrowSoundCor());
        }

        private IEnumerator ThrowSoundCor()
        {
            yield return new WaitForSeconds(1f);
            _throwSound.Play();
            StartCoroutine(TrashSoundCor());
        }

        private IEnumerator TrashSoundCor()
        {
            yield return new WaitForSeconds(0.5f);
            _trashSound.Play();
        }
    }
}