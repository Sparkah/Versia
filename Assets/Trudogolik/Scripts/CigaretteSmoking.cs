using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trudogolik
{
    public class CigaretteSmoking : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _smoke;
        [SerializeField] private ParticleSystem _fire;
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("MainCamera"))
            {
                var emission = _smoke.emission;
                emission.enabled = false;
                var fire = _fire.emission;
                fire.enabled = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("MainCamera"))
            {
                var emission = _smoke.emission;
                emission.enabled = true;
                var fire = _fire.emission;
                fire.enabled = false;
            }
        }
    }
}