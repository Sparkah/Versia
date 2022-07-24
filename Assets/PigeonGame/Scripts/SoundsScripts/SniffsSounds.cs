using System.Collections;
using UnityEngine;

namespace Pigeon
{
    public class SniffsSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip[] _sniffs;
        [SerializeField] private float _minDelay = 0.3f;
        [SerializeField] private float _maxDelay = 10f;

        private void Start()
        {
            StartCoroutine(SniffsCorutine());
        }

        private IEnumerator SniffsCorutine()
        {
            while (true)
            {
                float r = Random.Range(_minDelay, _maxDelay);
                yield return new WaitForSeconds(r);
                int i = Random.Range(0, _sniffs.Length);
                _source.clip = _sniffs[i];
                _source.Play();
            }
        }
    }
}