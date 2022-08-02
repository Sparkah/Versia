using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pigeon
{
    public class SnowFollow : MonoBehaviour
    {
        [SerializeField] private Transform _character;

        private const float k_delay = 1f;

        private void Start()
        {
            if (_character != null)
            {
                StartCoroutine(FollowPlayer());
            }
        }

        private IEnumerator FollowPlayer()
        {
            while (true)
            {
                yield return new WaitForSeconds(k_delay);
                Vector3 newPos = new Vector3(_character.transform.position.x, transform.position.y, _character.transform.position.z);
                transform.position = newPos;
            }
        }
    }
}