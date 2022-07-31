using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Pigeon
{
    public class Barking : MonoBehaviour
    {
        [SerializeField] private AudioSource _barking;
        [SerializeField] private float _maxDistance;
        [SerializeField] private float _minDistance;

        private const float k_delay = 0.1f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _barking.loop = true;
                _barking.Play();
                StartCoroutine(FollowPlayer(other.transform));
            }
        }

        private IEnumerator FollowPlayer(Transform character)
        {
            while (_barking.loop == true)
            {
                yield return new WaitForSeconds(k_delay);
                if (character.transform.position.z < _maxDistance || character.transform.position.z > _minDistance)
                {
                    Vector3 newPos = new Vector3(_barking.transform.position.x, _barking.transform.position.y, character.transform.position.z);
                    _barking.transform.position = newPos;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _barking.loop = false;
            }
        }
    }
}