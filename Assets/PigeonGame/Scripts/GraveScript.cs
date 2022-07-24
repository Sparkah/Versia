using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualGrasp.VG_Helpers;

namespace Pigeon
{
    public class GraveScript : MonoBehaviour
    {
        [SerializeField] private GameObject _graveGround;

        private void Start()
        {
            _graveGround.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pigeon"))
            {
                other.gameObject.SetActive(false);
                _graveGround.SetActive(true);
            }
        }

    }
}